using AutoMapper;
using Google.Apis.Auth;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Train_D.DTO.resetPasswordDto;
using Train_D.Helper;
using Train_D.Models;
using Train_D.Templates;

namespace Train_D.Services
{
    public class Auth : IAuth
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;
        private readonly MailSettings _mailSettings;

        public Auth(UserManager<User> userManager, IOptions<JWT> jwt, IMapper mapper, RoleManager<IdentityRole> roleManager, IOptions<MailSettings> mailSettings)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _mapper = mapper;
            _roleManager = roleManager;
            _mailSettings = mailSettings.Value;
        }

        public async Task<AuthModel> Register(RegisterModel model)
        {
            if (await _userManager.Users.AnyAsync(e => (e.NormalizedUserName == model.UserName) || (e.Email == model.Email)))
                return new AuthModel { Message = "Email or Username are already Registered" };

            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            
            return new AuthModel
            {
                IsAuthenticated = true,
                Token = token,
                Message = "Register Successfully"
            };
        }

        public async Task<AuthModel> Login(LoginModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == model.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "UserName or Password is incorrect!";
                return authModel;
            }
            if(!user.EmailConfirmed)
            {
                authModel.Message = "You must verfiy your email";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);


            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Message = "Login Successfully";

            return authModel;
        }

        public async Task<string> AddRole(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.RoleName))
                return "Invalid User ID OR Role !";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "User Alread Assigned This Role";

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? String.Empty : "Somthing Went Wrong";
        }

        public async Task<AuthModel> LoginGoogle(string credential)
        {
            var authModel = new AuthModel();
            try
            {

                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { this._jwt.GoogleClientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == payload.Email);

                if (user is null)
                {
                    return (await RegisterGoogle(payload));
                }

                var jwtSecurityToken = await CreateJwtToken(user);

                authModel.IsAuthenticated = true;
                authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authModel.Message = "Login Successfully";

                return authModel;
            }
            catch
            {

                authModel.Message = "invaild token ";
                return authModel;
            }

        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("UserId", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),


            }
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        private async Task<AuthModel> RegisterGoogle(GoogleJsonWebSignature.Payload payload)
        {


            var user = _mapper.Map<User>(payload);
            user.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");
            
            
            var jwtSecurityToken = await CreateJwtToken(user);


            return new AuthModel
            {
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Message = "Register Successfully"
            };

        }

        public async Task<bool> SendEmailAsync(string mailTo, string subject, string body)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSettings.Email),
                    Subject = subject
                };

                email.To.Add(MailboxAddress.Parse(mailTo));

                var builder = new BodyBuilder();

                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
                await smtp.SendAsync(email);

                smtp.Disconnect(true);
                return true;
            }
            catch 
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == mailTo);
                if (user == null) return false;
                await _userManager.DeleteAsync(user);
                return false;
            }
        }

        public async Task<bool> confirmEmail(string token, string email)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user is null)
                    return false;

                var result = await _userManager.ConfirmEmailAsync(user, token);
                return result.Succeeded;
            }
            catch
            {
                return false;
            }
        }

        public string prepareBody(string firstName, string confirmationlink)
        {
            var mailText = HtmlContent.EmailTemplate;
            mailText = mailText.Replace("[username]", firstName).Replace("https://www.youtube.com",confirmationlink);

            return mailText;
        }

        public async Task<AuthModel> forgetPassword(string email)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user is null)
                {
                    return new AuthModel { Message = "invaild Email" };
                }
                    

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                return new AuthModel
                {
                    IsAuthenticated = true,
                    Token = token,
                    UserName=user.FirstName
                };
            }
            catch
            {
                return new AuthModel { Message = "something goes wrong, try again later!" };
            }
        }

        public string prepareResetPasswordBody(string userName, string resetPasswordlink)
        {
            var mailText = HtmlContent.ResetEmailTemplate;
            mailText = mailText.Replace("{{name}}", userName).Replace("{{action_url}}", resetPasswordlink);
            return mailText;
        }

        public async Task<bool> resetPassword(resetPasswordDto request)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (user is null)
                    return false;

                var result = await _userManager.ResetPasswordAsync(user, request.Token,request.Password);
                return result.Succeeded;
            }
            catch
            {
                return false;
            }
        }
    }
}
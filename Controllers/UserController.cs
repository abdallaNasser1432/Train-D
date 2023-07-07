using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Train_D.DTO.changePasswordDtos;
using Train_D.DTO.resetPasswordDto;
using Train_D.Models;
using Train_D.Models.AuthenticationModels;
using Train_D.Services;
using Train_D.Templates;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAuth _auth;

        public UserController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _auth.Register(model);

            if (!Result.IsAuthenticated)
                return BadRequest(new { Message = Result.Message });

            var confirmationlink = Url.Action(nameof(ConfirmEmail), "User", new { token = Result.Token, email = model.Email }, Request.Scheme);

            var body = _auth.prepareBody(model.FirstName, confirmationlink);

            if (await _auth.SendEmailAsync(model.Email, "Email Verification", body))
                return Ok(new { Message = "Please check your email to verfaiy account " });

            return BadRequest(new { Message = "somthing goes wrong, try again later !" });

        }

        [HttpGet("ConfirmEmail")]
        public async Task<ContentResult> ConfirmEmail(string token, string email)
        {
            if (await _auth.confirmEmail(token, email))
            {
                var mailText = HtmlContent.verification_success;

                return base.Content(mailText, "text/html");
            }
            return base.Content("Your email is not confirmed, please try again later", "text/html");
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto email)
        {
            var result = await _auth.forgetPassword(email.Email);

            if (!result.IsAuthenticated)
                return BadRequest(new { Message = result.Message });

            var ResetPasswordlink = Url.Action(nameof(ResetPassword), "User", new { token = result.Token, email = email.Email }, Request.Scheme);

            var body = _auth.prepareResetPasswordBody(result.UserName, ResetPasswordlink);

            if (await _auth.SendEmailAsync(email.Email, "Reset Password", body))
                return Ok(new { Message = "Please check your email to Reset your Password " });

            return BadRequest(new { Message = "somthing goes wrong, try again later !" });

        }

        [HttpGet("reset-password")]
        public ContentResult ResetPassword(string token, string email)
        {
            var mailText = HtmlContent.ResetPasswordForm;
            return base.Content(mailText, "text/html");
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<ContentResult> ResetPassword(resetPasswordDto request)
        {
            if (await _auth.resetPassword(request))
            {
                var mailText = HtmlContent.verification_success;
                mailText = mailText.Replace("your account has been successfully created!", "Your Password has changed Successfully!");

                return base.Content(mailText, "text/html");
            }
            return base.Content("something goes wrong,Please try again later", "text/html");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _auth.Login(model);

            if (!Result.IsAuthenticated)
                return BadRequest(new { Message = Result.Message });

            return Ok(new { Result.Token, Result.Message });
        }

        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleTokenModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _auth.LoginGoogle(request.idToken);

            if (!Result.IsAuthenticated)
                return BadRequest(new { Message = Result.Message });


            return Ok(new { Result.Token, Result.Message });

        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> changePassword([FromBody] ChangePasswrodRequest request)
        {
            
            var userId = HttpContext.User.FindFirstValue("UserId");
            var response = await _auth.changePassword(request.CurrentPassword, request.NewPassword, userId);

            return response.Success ? Ok(new { Message = response.Message })
                          : BadRequest(new { Message = response.Message });
        }

        [HttpPost("AddRole")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.AddRole(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }


    }
}

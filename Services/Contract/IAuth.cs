using Train_D.DTO.resetPasswordDto;
using Train_D.Models;

namespace Train_D.Services
{
    public interface IAuth
    {
        public Task<AuthModel> Register(RegisterModel model);
        public Task<AuthModel> Login(LoginModel model);
        public Task<string> AddRole(AddRoleModel model);
        public Task<AuthModel> LoginGoogle(string credential);
        public Task<bool> SendEmailAsync(string mailTo, string subject, string body);
        public Task<bool> confirmEmail(string token,string email);
        public string prepareBody(string firstName, string confirmationlink);
        public Task<AuthModel> forgetPassword(string email);
        public string prepareResetPasswordBody(string userName, string resetPasswordlink);
        public Task<bool> resetPassword(resetPasswordDto request);
    }

}

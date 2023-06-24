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
    }

}

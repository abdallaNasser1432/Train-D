using Train_D.Models;

namespace Train_D.Services
{
    public interface IAuth
    {
        public Task<AuthModel> Register(RegisterModel model);
       
        public Task<AuthModel> Login(LoginModel model);
        
        public Task<AuthModel> RefreshToken(string token);
        
        public Task<bool> RevokeToken(string token);
      

    }
}

using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Train_D.DTO;
using Train_D.Models;
using Train_D.Services;

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
                return BadRequest(Result.Message);
            
            return Ok(new {Result.Token , Result.Message});
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            var Result = await _auth.Login(model);
            
            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);
           
            return Ok(new {Result.Token});
        }

        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _auth.LoginGoogle(credential);

            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);

            return Ok(new { Result.Token });

        }

        [HttpPost("AddRole")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var result =  await _auth.AddRole(model);

            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);
          
            return Ok(model);
        }

    }
}

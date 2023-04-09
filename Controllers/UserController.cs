using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            {
                return BadRequest(ModelState);
            }
            var Result = await _auth.Register(model);
            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);
            return Ok(Result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _auth.Login(model);
            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);
            return Ok(Result);
        }
    }
}

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
            {
                return BadRequest(ModelState);
            }
            var Result = await _auth.Register(model);
            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);

            SetRefreshTokenInCookie(Result.RefreshToken, Result.RefreshTokenExpiration);
            return Ok(new { Result.Token, Result.RefreshTokenExpiration }); // return RefreshToken and RefreshTokenExpiration
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

            if (!string.IsNullOrEmpty(Result.RefreshToken))
                SetRefreshTokenInCookie(Result.RefreshToken, Result.RefreshTokenExpiration);
            return Ok(new { Result.Token, Result.RefreshTokenExpiration }); // return RefreshToken and RefreshTokenExpiration
        }


        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var Result = await _auth.RefreshToken(refreshToken);

            if(!Result.IsAuthenticated)
                return BadRequest(Result);
            SetRefreshTokenInCookie(Result.RefreshToken, Result.RefreshTokenExpiration);

            return Ok(Result);
        }

        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeDTO dto)
        {

            var token = dto.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token Is Required!");
            var Result = await _auth.RevokeToken(token);
            if(!Result)
                return BadRequest("Token Is Invalid!");
            return Ok();
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var CookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

            Response.Cookies.Append("refreshToken", refreshToken, CookieOptions);
        }

    }
}

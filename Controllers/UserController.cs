using Microsoft.AspNetCore.Authorization;
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
                return BadRequest(ModelState);

            var Result = await _auth.Register(model);

            if (!Result.IsAuthenticated)
                return BadRequest(new { Message = Result.Message });

            var confirmationlink = Url.Action(nameof(ConfirmEmail), "User", new { token = Result.Token, email = model.Email },Request.Scheme);

            var body = _auth.prepareBody(model.FirstName, confirmationlink);

            if(await _auth.SendEmailAsync(model.Email, "Email Verification", body))
                return Ok(new { Message="Please check your email to verfaiy account " });

            return BadRequest(new { Message = "somthing goes wrong, try again later !" });

        }

        [HttpGet("ConfirmEmail")]
        public async Task<ContentResult> ConfirmEmail(string token, string email)
        {
            if(await _auth.confirmEmail(token, email))
            {
                var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\verification success.html";
                var str = new StreamReader(filePath);

                var mailText = str.ReadToEnd();
                str.Close();
                return base.Content(mailText, "text/html");
            }
            return base.Content("Your email is not confirmed, please try again later", "text/html");
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
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _auth.LoginGoogle(credential);

            if (!Result.IsAuthenticated)
                return BadRequest(new { Message = Result.Message });


            return Ok(new { Result.Token, Result.Message });

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

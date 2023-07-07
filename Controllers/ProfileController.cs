using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Train_D.DTO.ProfileDtos;
using Train_D.Services.Contract;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profile;
        private long _maxSize = 1048576;
        public ProfileController(IProfileService profile)
        {
            _profile = profile;
        }

       
        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserData([FromBody] ProfileWriteDto data)
        {
            if (data.Image.Length > _maxSize)
                return BadRequest(new { Massage = "The image size is more than 1MB" });

            var username = HttpContext.User.FindFirstValue("UserName");

            var UserUpdated = await _profile.UpdateUserData(username, data);

            if (UserUpdated is null)
                return BadRequest(new { Massage = "something goes wrong, try again" });

            return Ok(UserUpdated);
        }

        [HttpGet("UserData")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {

            var username = HttpContext.User.FindFirstValue("UserName");

            var Userdata = await _profile.GetData(username);

            if (Userdata is null)
                return BadRequest(new { Massage = "something goes wrong, try again" });

            return Ok(Userdata);
        }


        [HttpGet("GetUserNameAndPicture")]
        [Authorize]
        public IActionResult GetUserNameAndPicture()
        {
            var username = HttpContext.User.FindFirstValue("UserName");
            var picture = HttpContext.User.FindFirstValue("Image");

            return Ok(new { username, picture });
        }
    }
}

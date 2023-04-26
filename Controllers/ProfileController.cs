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

        [HttpPut("Upload")]
        [Authorize]
        public async Task<IActionResult> UpdateImage([FromBody] byte[] Image)
        {
            if (Image.Length > _maxSize)
                return BadRequest("The image size is more than 1MB");

            var username = HttpContext.User.FindFirstValue("UserName");

            var image = await _profile.Upload(Image, username);

            if (image.IsNullOrEmpty())
                return BadRequest("something goes wrong, try again");

            return Ok(image);
        }

        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserData([FromBody] ProfileWriteDto data)
        {

            var username = HttpContext.User.FindFirstValue("UserName");

            var UserUpdated = await _profile.UpdateUserData(username,data);

            if (UserUpdated is null)
                return BadRequest("something goes wrong, try again");

            return Ok(UserUpdated);
        }

        [HttpGet("UserData")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {

            var username = HttpContext.User.FindFirstValue("UserName");

            var Userdata = await _profile.GetData(username);

            if (Userdata is null)
                return BadRequest("something goes wrong, try again");

            return Ok(Userdata);
        }

    }
}

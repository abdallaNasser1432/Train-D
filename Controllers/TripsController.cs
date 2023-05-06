using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Train_D.DTO.TripDtos;
using Train_D.Services.Contract;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet("FromTo")]
        public async Task<IActionResult> GetAll()
        {
            var FromTo = await _tripService.GetFromToStations();
            return Ok(FromTo);
        }

        [HttpPost("TripTimes")]
        public async Task<IActionResult> GetTripTimes([FromBody] SearchTripWriteDTO dto)
        {
            if (!_tripService.Isvalid(dto.Date))
                return BadRequest(new { Message = "Invalid Date!" });

            var result = await _tripService.TripTimes(dto);

            if (result.IsNullOrEmpty())
                return BadRequest(new { Message = "Somthing goes wrong ,try again!" });


            return Ok(result);
        }
        [HttpPost("TrainInfo")]
        public async Task<IActionResult> GetTrainInfo([FromBody] TrainInfoRequest request)
        {
            if (!_tripService.Isvalid(request.Date))
                return BadRequest(new { Message = "Invalid Date!" });

            var TrainInfo = await _tripService.GetTrainInfoAsync(request);

            if (TrainInfo is null)
                return BadRequest(new { Message = "Something goes wrong ,try again!" });

            return Ok(TrainInfo);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Train_D.DTO;
using Train_D.Models;
using Train_D.Services;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationsServices _StationServices;

        public StationsController(IStationsServices stationsServices)
        {
            _StationServices = stationsServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Stations = await _StationServices.GetAll();
            return Ok(Stations);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string StationName)
        {
            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
            {
                return NotFound();
            }
            return Ok(Station);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string StationName)
        {
            var movie = await _StationServices.GetByName(StationName);
            if (movie == null)
                return NotFound();
            _StationServices.Delete(movie);
            return Ok(movie);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(string StationName, [FromBody] StationDTO Dto)
        {
            var Station = await _StationServices.GetByName(StationName);
            if (Station is null)
                return NotFound($"No Station was found with {StationName}");

            Station.StationInfo = Dto.StationInfo;
            Station.Latitude = Dto.Latitude;
            Station.Longitude = Dto.Longitude;
            Station.HoursOpen = Dto.HoursOpen;
            Station.Address = Dto.Address;
            Station.Phone = Dto.Phone;
            
             _StationServices.Update(Station);
            return Ok(Station);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Station Model)
        {
            var Station = await _StationServices.GetByName(Model.StationName);
            if (Station is not null)
                return BadRequest("Station Is Already Added");

            var newStation = new Station
            {
                StationName = Model.StationName,
                StationInfo = Model.StationInfo,
                HoursOpen = Model.HoursOpen,
                Longitude = Model.Longitude,
                Latitude = Model.Latitude,
                Address = Model.Address,
                Phone = Model.Phone
            };
            await _StationServices.Add(newStation);
            return Ok("Station Is Added");
        }
    }
}

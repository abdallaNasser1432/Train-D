using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Train_D.DTO;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Stations = await _StationServices.GetAll();
            return Ok(Stations);
        }

        [HttpGet("{StationName}")]
        public async Task<IActionResult> GetByName(string StationName)
        {
            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
            {
                return NotFound();
            }
            return Ok(Station);

        }

        [HttpDelete("{StationName}")]
        public async Task<IActionResult> Delete(string StationName)
        {
            var movie = await _StationServices.GetByName(StationName);
            if (movie == null)
                return NotFound();
            _StationServices.Delete(movie);
            return Ok(movie);
        }

        [HttpPut("{StationName}")]
        public async Task<IActionResult> Update(string StationName, [FromForm] StationDTO Dto)
        {
            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
                return NotFound($"No Station was found with {StationName}");

            Station.StationInfo = Dto.StationInfo;
            Station.HoursOpen = Dto.HoursOpen;
            Station.Longitude = Dto.Longitude;
            Station.Latitude = Dto.Latitude;
            Station.Phone = Dto.Phone;

            return Ok(_StationServices.Update(Station));

        }
    }
}

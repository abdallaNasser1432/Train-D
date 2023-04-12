using AutoMapper;
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
        private readonly IMapper _mapper; // add Interface IMapper 

        public StationsController(IStationsServices stationsServices, IMapper mapper = null)
        {
            _StationServices = stationsServices;
            _mapper = mapper;
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
                return NotFound();
            
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
            Station.Longitude = Dto.Longitude;                      // can't mapping and update together
            Station.HoursOpen = Dto.HoursOpen;       // automapper mapped dto from scoure model but can't save it in var Station and updated it
            Station.Address = Dto.Address;
            Station.Phone = Dto.Phone;
            
             _StationServices.Update(Station);
            return Ok(Station);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] StationDTO DTO)
        {
            var Station = await _StationServices.GetByName(DTO.StationName);
            if (Station is not null)
                return BadRequest("Station Is Already Added");

            var result = _mapper.Map<Station>(DTO);
            await _StationServices.Add(result);
            
            return Ok("Station Is Added");
        }
    }
}

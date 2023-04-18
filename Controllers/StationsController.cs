using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Stations = await _StationServices.GetAll();
            return Ok(Stations);
        }

        [HttpGet("{StationName}")]
        public async Task<IActionResult> GetByName([FromRoute]string StationName)
        {
            if (StationName is null)
                return BadRequest("you didn't enter StationName");
            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
                return NotFound();
            
            return Ok(Station);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] StationDTO DTO)
        {
            var Station = await _StationServices.GetByName(DTO.StationName);
            if (Station is not null)
                return BadRequest("Station Is Already Added");

            var newStation = _mapper.Map<Station>(DTO);
            await _StationServices.Add(newStation);

            return Ok("Station Is Added");
        }

        [HttpPut("{StationName}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update([FromRoute]string StationName, [FromBody] StationDTO DTO)
        {
            if(StationName is null )
                return BadRequest("you didn't enter StationName");
            var Station = await _StationServices.GetByName(StationName);
            if (Station is null)
                return NotFound($"No Station was found with {StationName}");

            Station.Latitude = DTO.Latitude;
            Station.Longitude = DTO.Longitude;
            Station.HoursOpen = DTO.HoursOpen;
            Station.Address = DTO.Address;
            Station.StationInfo = DTO.StationInfo;
            Station.Phone = DTO.Phone;
            _StationServices.Update(Station);


            return Ok(Station);
        }

        [HttpDelete("{StationName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]string StationName)
        {
            if (StationName is null)
                return BadRequest("you didn't enter StationName");

            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
                return NotFound();

            _StationServices.Delete(Station);

            return Ok(Station);
        }
    }
}

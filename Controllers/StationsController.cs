using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Train_D.DTO;
using Train_D.DTO.StationDtos;
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
            var SationNamesGroup = _StationServices.GroupedSations(Stations.ToList());
            return Ok(SationNamesGroup);
        }

        [HttpGet("{StationName}")]
        public async Task<IActionResult> GetByName([FromRoute] string StationName)
        {
            if (StationName is null)
                return BadRequest(new { massage = "you didn't enter StationName" });
            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
                return NotFound();

            return Ok(Station);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] StationAddDto DTO)
        {
            if (!_StationServices.IsExist(DTO.StationName))
                return BadRequest(new { massage = "Station Is Already Added" });

            var newStation = _mapper.Map<Station>(DTO);
            await _StationServices.Add(newStation);

            string Message = "Station Is Added";

            return Ok(new {Message});
        }

        [HttpPut("{StationName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] string StationName, [FromBody] StationDTO DTO)

        {
            if (StationName is null)
                return BadRequest("you didn't enter StationName");

            var station = await _StationServices.GetByName(StationName);

            if (station is null)
                return NotFound($"No Station was found with {StationName}");

             _mapper.Map(DTO,station);

            if (!await _StationServices.Update())
                return BadRequest("something goes wrong ,try again!");

            return Ok(station);
        }

        [HttpDelete("{StationName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string StationName)
        {
            if (StationName is null)
                return BadRequest(new { massage = "you didn't enter StationName" });

            var Station = await _StationServices.GetByName(StationName);
            if (Station == null)
                return NotFound();

            _StationServices.Delete(Station);

            string Message = $"Station {StationName} Is Deleted";

            return Ok(new { Message });
        }
    }
}

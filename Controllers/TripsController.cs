using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trips = await _tripService.GetFromandToStations();
            var FromTo = _tripService.GroupedSations(trips.ToList());
            return Ok(FromTo);
        }
    }
}

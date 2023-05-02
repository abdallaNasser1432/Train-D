﻿using Microsoft.AspNetCore.Mvc;
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
    }
}

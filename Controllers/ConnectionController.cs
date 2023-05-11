using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Train_D.Data;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConnectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> BuiltConnection()
        {
            try
            {
                var FromTo = await _context.Trains.FindAsync(12);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

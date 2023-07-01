using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Train_D.DTO.TicketDTO;
using Train_D.Services.Contract;

namespace Train_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("Book")]
        [Authorize]
        public async Task<IActionResult> bookTicket([FromBody] TicketBookRequest dto)
        {
            if (await _ticketService.IsExist(dto) || !_ticketService.Isvaild(dto.PaymentId))
                return BadRequest(new { Message = "seat is aleardy booked " });

            var username = HttpContext.User.FindFirstValue("UserName");
            var UserId = HttpContext.User.FindFirstValue("UserId");
            var newTicket = await _ticketService.Book(dto, UserId, username);
            if (newTicket is null)
                return BadRequest(new { Message = "Something goes wroing ,try again !" });

            return Ok(newTicket);
        }

        [HttpGet("myTickets")]
        [Authorize]
        public async Task<IActionResult> GetTicketForUser()
        {
            var UserId = HttpContext.User.FindFirstValue("UserId");
            var Username = HttpContext.User.FindFirstValue("UserName");
            var UserTicket = await _ticketService.GetTickets(UserId, Username);
            if (UserTicket.IsNullOrEmpty())
                return BadRequest(new { Message = "There Are No Tickets Reserved For This User" });
            return Ok(new { Tickets = UserTicket });
        }

        [HttpGet("Tracking/{TicketId}")]
        public async Task<IActionResult> TrackingTrain([FromRoute] int TicketId)
        {
            var response = await _ticketService.getTrackingInfo(TicketId);

            if (response is null)
                return BadRequest(new { Message = "TickedId doesn't exist!" });

            return Ok(response);
        }
    }
}

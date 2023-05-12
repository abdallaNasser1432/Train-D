using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetTripTimes([FromBody] TicketBookRequest dto)
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

        [HttpGet("Ticket")]
        [Authorize]
        public async Task<IActionResult> GetTicketForUser()
        {
            var UserId = HttpContext.User.FindFirstValue("UserId");
            if (!_ticketService.IsFound(UserId))
                return BadRequest(new { message = "There Are No Tickets Reserved For This User" });
            var UserTicket = await _ticketService.GetTickets(UserId);

            return Ok(UserTicket);
        }
    }
}

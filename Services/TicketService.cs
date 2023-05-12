using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Train_D.Data;
using Train_D.DTO.TicketDTO;
using Train_D.Models;
using Train_D.Services.Contract;

namespace Train_D.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TicketService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TicketReadDTO> Book(TicketBookRequest dto, string userid, string username)
        {
            try
            {
                var newTicket = _mapper.Map<Ticket>(dto);
                newTicket.UserId = userid;
                await _context.AddAsync(newTicket);
                await _context.SaveChangesAsync();
                return new TicketReadDTO { PassangerName = username, TicketId = newTicket.TicketId };
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> IsExist(TicketBookRequest dto)
        {
            var trip = await _context.Trips
                                 .Where(t => t.TripId == dto.TripId)
                                 .AsNoTracking()
                                 .Select(t => new
                                 {
                                     StartTime = t.StartTime,
                                     ArrivalTime = t.ArrivalTime,
                                     TrainId = t.TrainId
                                 }).FirstOrDefaultAsync();

            var ticket = await _context.Tickets
                                 .Include(t => t.Trip)
                                 .AsNoTracking()
                                 .Where(t => t.Date == dto.Date.Date)
                                 .ToListAsync();

            return ticket.Any(t => (t.Trip.TrainId == trip.TrainId) &&
                                  ((t.Trip.StartTime <= trip.StartTime && t.Trip.ArrivalTime > trip.StartTime) ||
                                  (t.Trip.StartTime < trip.ArrivalTime && t.Trip.ArrivalTime >= trip.ArrivalTime) ||
                                  (t.Trip.StartTime >= trip.StartTime && t.Trip.ArrivalTime <= trip.ArrivalTime)) &&
                                  (t.Class == dto.Class && t.Coach == dto.Coach && t.SeatNumber == dto.SeatNumber)
                                   );

        }

        public async Task<IEnumerable<TicketDTO>> GetTickets(string userId)
        {
            var UserTicket = await _context.Tickets
                .Where(t => t.UserId == userId)
                .Select(t => new TicketDTO
                {
                    From = t.Trip.StartStation,
                    To = t.Trip.EndStaion,
                    StartTime = t.Trip.StartTime,
                    EndTime = t.Trip.ArrivalTime,
                    TicketId = t.TicketId,
                    PassengerName = t.User.UserName,
                    Date = t.Date,
                    ClassName = t.Class,
                    CoachNumber = t.Coach,
                    SeatNumber = t.SeatNumber,
                    Price = t.Amount
                }).ToListAsync();

            return UserTicket;
        }


        public bool Isvaild(string pay)
        {
            return pay.StartsWith("ch");
        }

        public bool IsFound(string userId)
        {
            return _context.Tickets.Any(t => t.UserId == userId);
        }
    }
}

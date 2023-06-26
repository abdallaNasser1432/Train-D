using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
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

        public async Task<TicketDTO> Book(TicketBookRequest dto, string userid, string username)
        {
            try
            {
                var newTicket = _mapper.Map<Ticket>(dto);
                newTicket.UserId = userid;
                await _context.AddAsync(newTicket);
                await _context.SaveChangesAsync();
                return await _context.Tickets
                    .Where(t => t.TicketId == newTicket.TicketId)
                    .Select(t => new TicketDTO
                    {
                        From = t.Trip.StartStation,
                        To = t.Trip.EndStaion,
                        StartTime = t.Trip.StartTime,
                        EndTime = t.Trip.ArrivalTime,
                        Duration = (t.Trip.ArrivalTime - t.Trip.StartTime).ToString(@"hh\:mm"),
                        TicketId = t.TicketId,
                        PassengerName = username,
                        Date = t.Date,
                        ClassName = t.Class,
                        CoachNumber = t.Coach,
                        SeatNumber = t.SeatNumber,
                        Price = t.Amount
                    }).SingleOrDefaultAsync();
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
                                     t.StartTime,
                                     t.ArrivalTime,
                                     t.TrainId
                                 }).FirstOrDefaultAsync();

            var ticket = await _context.Tickets
                                 .Include(t => t.Trip)
                                 .AsNoTracking()
                                 .Where(t => (t.Date == dto.Date.Date) && (t.Trip.TrainId == trip.TrainId))
                                 .ToListAsync();

            return ticket.Any(t =>
                                  ((t.Trip.StartTime <= trip.StartTime && t.Trip.ArrivalTime > trip.StartTime) ||
                                  (t.Trip.StartTime < trip.ArrivalTime && t.Trip.ArrivalTime >= trip.ArrivalTime) ||
                                  (t.Trip.StartTime >= trip.StartTime && t.Trip.ArrivalTime <= trip.ArrivalTime)) &&
                                  (t.Class == dto.Class && t.Coach == dto.Coach && t.SeatNumber == dto.SeatNumber)
                                   );

        }

        public async Task<IEnumerable<TicketDTO>> GetTickets(string userId, string username)
        {
            try
            {
                var UserTicket = await _context.Tickets
                    .Where(t => t.UserId == userId)
                    .Select(t => new TicketDTO
                    {
                        From = t.Trip.StartStation,
                        To = t.Trip.EndStaion,
                        StartTime = t.Trip.StartTime,
                        EndTime = t.Trip.ArrivalTime,
                        Duration = (t.Trip.ArrivalTime - t.Trip.StartTime).ToString(@"hh\:mm"),
                        TicketId = t.TicketId,
                        PassengerName = username,
                        Date = t.Date,
                        ClassName = t.Class,
                        CoachNumber = t.Coach,
                        SeatNumber = t.SeatNumber,
                        Price = t.Amount
                    }).ToListAsync();

                return UserTicket;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool Isvaild(string pay)
        {
            return pay.StartsWith("ch");
        }

        public async Task<TrackingResponse> getTrackingInfo(int ticketId)
        {
            try
            {
                var location = await _context.Tickets
                    .Where(t => t.TicketId == ticketId)
                    .Select(t => new TrackingResponse
                    {
                        FromStation = t.Trip.StartStation,
                        StartTime = t.Trip.StartTime,
                        ArrivalTime = t.Trip.ArrivalTime,
                        TrainId = t.Trip.TrainId,
                        Latitude = t.Trip.StationBegain.Latitude,
                        Longitude = t.Trip.StationBegain.Longitude,
                    }).FirstOrDefaultAsync();

                return location;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

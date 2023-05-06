using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Train_D.Data;
using Train_D.DTO.TripDtos;
using Train_D.Services.Contract;

namespace Train_D.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TripService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Dictionary<string, object>> GetFromToStations()
        {
            var trips = await _context.Trips.AsNoTracking()
                .Select(t => new FromTo { From = t.StartStation, To = t.EndStaion }).Distinct().ToListAsync();

            var values = new Dictionary<string, object>();

            var StartStation = trips.GroupBy(f => f.From)
                .OrderBy(t => t.Key);

            foreach (var from in StartStation)
            {
                values.Add(from.Key, from.Select(x => x.To));
            }
            return values;
        }

        public async Task<TrainInfoDTO> GetTrainInfoAsync(TrainInfoRequest request)
        {
            try
            {
                var classTrip = await _context.ClassTrips
                              .Include(t => t.Trip)
                              .Include(c => c.Class)
                              .AsNoTracking()
                              .Where(t => t.TripId == request.TripId)
                              .ToListAsync();

                if (classTrip.IsNullOrEmpty())
                    return null;

                // list of classes in Train
                var classes = _mapper.Map<List<ClaassDTO>>(classTrip);

                // to used in searsh (information about trip )
                var TrainId = classTrip.FirstOrDefault().TrainId;
                var tripStartTime = classTrip.FirstOrDefault().Trip.StartTime;
                var tripArrivalTime = classTrip.FirstOrDefault().Trip.ArrivalTime;

                // list of booked seats in Train
                var seats = await _context.Tickets
                                .Include(t => t.Trip)
                                .AsNoTracking()
                                .Where(t => (t.Date.Date == request.Date.Date) &&
                                            (t.TrainId == TrainId) &&
                                            ((t.Trip.StartTime <= tripStartTime && t.Trip.ArrivalTime > tripStartTime) ||
                                             (t.Trip.StartTime < tripArrivalTime && t.Trip.ArrivalTime >= tripArrivalTime) ||
                                             (t.Trip.StartTime >= tripStartTime && t.Trip.ArrivalTime <= tripArrivalTime)))
                                .Select(t => new SeatDTO
                                {
                                    SeatNumber = t.SeatNumber,
                                    Coach = t.Coach,
                                    Class = t.Class,
                                })
                                .ToListAsync();

                return new TrainInfoDTO { Classes = classes, Seats = seats };
            }
            catch (Exception)
            {
                return null;
            }
        }

        // return false if date in the past or bigger than the date of today about 20 days
        public bool Isvalid(DateTime d)
        {
            return (d.Year != 1) && (d.Date >= DateTime.Now.Date) && ((d.Date - DateTime.Now.Date).Days <= 20);
        }

        public async Task<List<SearchTripResultDTO>> TripTimes(SearchTripWriteDTO dTO)
        {
            try
            {
                var Trips = await _context.Trips
                              .Include(t => t.Train)
                              .ThenInclude(c => c.Classes)
                              .AsNoTracking()
                              .Where(t => t.StartStation == dTO.FromStation && t.EndStaion == dTO.ToStation)
                              .Select(t => new SearchTripReadDTO
                              {
                                  TrainId = t.TrainId,
                                  TripId = t.TripId,
                                  StartTime = t.StartTime,
                                  ArrivalTime = t.ArrivalTime,
                                  totalseats = t.Train.Classes.Sum(s => s.Coaches * s.NumberOfSeatsCoach)
                              }).ToListAsync();

                if (Trips.IsNullOrEmpty())
                    return null;

                var ticktes = await _context.Tickets
                                .Include(t => t.Trip)
                                .AsNoTracking()
                                .Where(t => t.Date.Date == dTO.Date.Date)
                                .Select(t => new
                                {
                                    t.TrainId,
                                    t.Trip.StartTime,
                                    t.Trip.ArrivalTime
                                })
                                .ToListAsync();

                if (ticktes.IsNullOrEmpty())
                    return _mapper.Map<List<SearchTripResultDTO>>(Trips.Where(t => t.totalseats > 0));


                foreach (var trip in Trips)
                {
                    trip.totalseats -= ticktes.Where(s =>
                          (s.TrainId == trip.TrainId) &&
                          checkesTimes(s.StartTime, s.ArrivalTime, trip.StartTime, trip.ArrivalTime)
                    ).Count();
                }
                return _mapper.Map<List<SearchTripResultDTO>>(Trips.Where(t => t.totalseats > 0));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool checkesTimes(TimeSpan ticketStartTime, TimeSpan ticketArrivalTime, TimeSpan tripStartTime, TimeSpan tripArrivalTime)
        {
            return
            (ticketStartTime <= tripStartTime && ticketArrivalTime > tripStartTime) ||
            (ticketStartTime < tripArrivalTime && ticketArrivalTime >= tripArrivalTime) ||
            (ticketStartTime >= tripStartTime && ticketArrivalTime <= tripArrivalTime);
        }

    }
}

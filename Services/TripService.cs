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
                          ((s.StartTime <= trip.StartTime && s.ArrivalTime > trip.StartTime) ||
                         (s.StartTime < trip.ArrivalTime && s.ArrivalTime >= trip.ArrivalTime) ||
                        (s.StartTime >= trip.StartTime && s.ArrivalTime <= trip.ArrivalTime))
                    ).Count();
                }
                return _mapper.Map<List<SearchTripResultDTO>>(Trips.Where(t => t.totalseats > 0));
            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Train_D.Data;
using Train_D.DTO.TripDtos;
using Train_D.Models;
using Train_D.Services.Contract;

namespace Train_D.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext _context;

        public TripService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FromTo>> GetFromandToStations()
        {
            var trips = await _context.Trips
                .Select(t => new FromTo{ From = t.StartStation,To = t.EndStaion }).Distinct().ToListAsync();  
            return trips;
        }


        public Task<Trip> GetSearchofTrip()
        {
            throw new NotImplementedException();
        }

        public Dictionary<object, object> GroupedSations(List<FromTo> FromTo)
        {
            var values = new Dictionary<object, object>();
            var StartStation = FromTo.GroupBy(f => f.From)
                .OrderBy(t => t.Key);

            foreach (var from in StartStation)
            {
                values.Add(from.Key, from.Select(x => x.To));
            }
            return values;
        }
    }
}

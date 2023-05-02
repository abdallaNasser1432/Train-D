using Microsoft.EntityFrameworkCore;
using Train_D.Data;
using Train_D.DTO.TripDtos;
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
    }
}

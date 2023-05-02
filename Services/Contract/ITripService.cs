using Train_D.DTO.TripDtos;
using Train_D.Models;

namespace Train_D.Services.Contract
{
    public interface ITripService
    {
        Task<IEnumerable<FromTo>> GetFromandToForTrip();
        Task<Trip> GetSearchofTrip();
        Dictionary<object, object> GroupedSations(List<FromTo> FromTo);
    }
}

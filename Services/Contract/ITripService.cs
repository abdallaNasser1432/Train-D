using Train_D.DTO.TripDtos;
using Train_D.Models;

namespace Train_D.Services.Contract
{
    public interface ITripService
    {
        Task<Dictionary<string, object>> GetFromToStations();
    }
}

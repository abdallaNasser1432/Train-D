using Train_D.DTO.TripDtos;
using Train_D.Models;

namespace Train_D.Services.Contract
{
    public interface ITripService
    {
        Task<Dictionary<string, object>> GetFromToStations();
        bool Isvalid(DateTime d);
        Task<List<SearchTripResultDTO>> TripTimes(SearchTripWriteDTO dTO);
        Task<TrainInfoDTO> GetTrainInfoAsync(TrainInfoRequest request);

    }
}

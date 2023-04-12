using Train_D.DTO;
using Train_D.Models;
using static System.Collections.Specialized.BitVector32;

namespace Train_D.Services
{
    public interface IStationsServices
    {

        Task<IEnumerable<StationDTO>> GetAll();
        Task<Station> GetByName(string stationName);
        Task<Station> Add(Station movie);
        Station Update(Station movie);
        Station Delete(Station movie);
    }
}

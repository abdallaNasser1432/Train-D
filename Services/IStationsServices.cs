using Train_D.DTO;
using Train_D.Models;
using static System.Collections.Specialized.BitVector32;

namespace Train_D.Services
{
    public interface IStationsServices
    {

        Task<IEnumerable<Station>> GetAll();
        Task<Station> GetByName(string stationName);
        Task<Station> Add(Station station);
        Station Update(Station station);
        Station Delete(Station station);
        bool IsExist(string stationName);
    }
}

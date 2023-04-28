using Train_D.DTO;
using Train_D.Models;
using static System.Collections.Specialized.BitVector32;

namespace Train_D.Services
{
    public interface IStationsServices
    {

        Task<IEnumerable<string>> GetAll();
        Task<Station> GetByName(string stationName);
        Task<Station> Add(Station station);
        Task<bool> Update();
        Station Delete(Station station);
        Dictionary<char, object> GroupedSations(List<string> stations);
        bool IsExist(string stationName);
    }
}

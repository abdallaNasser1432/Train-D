using AutoMapper;
using Train_D.DTO;
using Train_D.Models;

namespace Train_D.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Station, StationDTO>().ReverseMap();
            CreateMap<RegisterModel, User>().ReverseMap();
            CreateMap<RegisterModel, AuthModel>().ReverseMap();
        }
    }
}

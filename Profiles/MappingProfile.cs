using AutoMapper;
using Google.Apis.Auth;
using Train_D.DTO;
using Train_D.DTO.ProfileDtos;
using Train_D.DTO.StationDtos;
using Train_D.DTO.TicketDTO;
using Train_D.DTO.TripDtos;
using Train_D.Models;

namespace Train_D.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region StationMap

            CreateMap<Station, StationAddDto>().ReverseMap();
            CreateMap<Station, StationDTO>().ReverseMap();

            #endregion

            #region AuthMap

            CreateMap<RegisterModel, User>().ReverseMap();
            CreateMap<RegisterModel, AuthModel>().ReverseMap();
            CreateMap<GoogleJsonWebSignature.Payload, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email.Substring(0, src.Email.IndexOf("@"))))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(src => src.GivenName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(src => src.FamilyName));

            #endregion

            #region ProfileMap

            CreateMap<ProfileWriteDto, User>();
            CreateMap<User, ProfileReadDto>();

            #endregion

            #region TripsMAp
            CreateMap<ClassTripDTO, ClaassDTO>();
            CreateMap<Ticket, SeatDTO>();
            CreateMap<SearchTripReadDTO, SearchTripResultDTO>();
            #endregion

            #region TicketMap
            CreateMap<TicketBookRequest, Ticket>();

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.StartTime, src => src.MapFrom(src => src.Trip.StartTime))
                .ForMember(dest => dest.EndTime, src => src.MapFrom(src => src.Trip.ArrivalTime))
                .ForMember(dest => dest.From, src => src.MapFrom(src => src.Trip.StartStation))
                .ForMember(dest => dest.To, src => src.MapFrom(src => src.Trip.EndStaion))
                .ForMember(dest => dest.TicketId, src => src.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.PassengerName, src => src.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Date, src => src.MapFrom(src => src.Date))
                .ForMember(dest => dest.ClassName, src => src.MapFrom(src => src.Class))
                .ForMember(dest => dest.CoachNumber, src => src.MapFrom(src => src.Coach))
                .ForMember(dest => dest.SeatNumber, src => src.MapFrom(src => src.SeatNumber))
                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.Amount))
                
                .ReverseMap();

            #endregion
        }
    }
}

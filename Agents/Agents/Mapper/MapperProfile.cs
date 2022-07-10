using Agents.DTO;
using Agents.Model;
using AutoMapper;

namespace Agents.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<CompanyRegistrationRequestDTO, CompanyRegistrationRequest>().ReverseMap();
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ReverseMap();
            CreateMap<PaymentDTO, Payment>().ReverseMap();
            CreateMap<InterviewDTO, Interview>().ReverseMap();
        }
    }
}

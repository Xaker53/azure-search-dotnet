using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Core.Models;
namespace Core.Entities.MappingProfiles
{
    public class MapperUser : Profile
    {
        public MapperUser()
        {
            CreateMap<UserRequest, UserDTO>()
                .ForMember(dest => dest.UserName, opt =>opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserGmail,opt => opt.MapFrom(src => src.Gmail))
                .ForMember (dest => dest.OtherEmail, opt => opt.MapFrom(src => src.OtherGmail));


            CreateMap<UserRequest, User>()
                 .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserGmail,
                opt => opt.MapFrom(src => src.Gmail))
                .ForSourceMember(src => src.OtherGmail, opt => opt.DoNotValidate());

            CreateMap<User, UserRequest>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Gmail, opt => opt.MapFrom(src => src.UserGmail))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src=> (string?)"Why do you need a password? Go on your way, stalker."))
            .ForMember(dest => dest.OtherGmail, opt => opt.Ignore());
        }
    }
}

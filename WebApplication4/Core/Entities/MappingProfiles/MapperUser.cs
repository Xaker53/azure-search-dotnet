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
                .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserGmail,
                opt => opt.MapFrom(src => src.Gmail));


            CreateMap<UserRequest, User>()
                 .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserGmail,
                opt => opt.MapFrom(src => src.Gmail))
                .ForSourceMember(src => src.OtherGmail, opt => opt.DoNotValidate());
        }
    }
}

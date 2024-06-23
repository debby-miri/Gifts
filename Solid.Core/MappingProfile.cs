using AutoMapper;
using Gifts;
using Solid.Core.DTO;
using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Gift, GiftDTO>()
                .ForMember(a=>a.EventName, bv=>bv.MapFrom(x=>x.Events.Name))
                .ForMember(a => a.GenderName, bv => bv.MapFrom(x => x.Gender.Name))
                .ForMember(a => a.CategoryName, bv => bv.MapFrom(x => x.Categry.Name))
                .ReverseMap();
            CreateMap<Opinion, OpinionDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Events1, EventsDTO>().ReverseMap();
            CreateMap<Categry, CategryDTO>().ReverseMap();
        }
    }
}

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
            CreateMap<Gift, GiftDTO>().ReverseMap();
            CreateMap<Opinion, OpinionDTO>().ReverseMap();
            CreateMap<Gender, OpinionDTO>().ReverseMap();
            CreateMap<Events1, OpinionDTO>().ReverseMap();
            CreateMap<Categry, OpinionDTO>().ReverseMap();
        }
    }
}

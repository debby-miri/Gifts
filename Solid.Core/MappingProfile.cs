using AutoMapper;
using Gifts;
using Solid.Core.DTO;
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
        }
    }
}

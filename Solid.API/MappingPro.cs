using AutoMapper;
using Gifts;
using Solid.API.PostModels;
using Solid.Core.DTO;

namespace Solid.API
{
    public class MappingPro:Profile
    {
        public MappingPro()
        {
            CreateMap<User,UserPostModel>().ReverseMap();
            CreateMap<Gift,GiftPostModel>().ReverseMap();
            CreateMap<Opinion,OpinionPostModel>().ReverseMap();
        }
    }
}

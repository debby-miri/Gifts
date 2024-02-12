using AutoMapper;
using Gifts;
using Solid.Core.DTO;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class OpinionService : IOpinionService
    {
        private readonly IOpinionRepository _repository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public OpinionService(IOpinionRepository repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<OpinionDTO> AddOpinion(Opinion opinion)
        {

            Opinion res= await _repository.AddOpinion(opinion);
            int UserId = res.Gift.User.UserId;

            ///למחוק מתנה
            int count =await _userService.GetCountOfOpinionsAsync(UserId);
            if (count >= 10)
            {
                Console.WriteLine(await _userService.BlockUser(UserId));
            }
            else
            {
                if (count >= 5)
                {
                    Console.WriteLine(await _userService.SuspendUser(UserId));
                }
            }
            return _mapper.Map<OpinionDTO>(res);
        }
    }
}

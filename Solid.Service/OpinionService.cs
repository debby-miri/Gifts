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
        private readonly IGiftService _giftService;
        private readonly IMapper _mapper;
        public OpinionService(IOpinionRepository repository, IMapper mapper, IUserService userService, IGiftService giftService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
            _giftService = giftService;
        }
        public async Task<OpinionDTO> AddOpinion(Opinion opinion)
        {

            Opinion res = await _repository.AddOpinion(opinion);
            GiftDTO gift = await _giftService.GetByIdAsync(res.GiftId);
            int UserId = gift.UserId;
            int[] op = await _userService.GetCountOfOpinionsAsync(UserId);
            if (op[1] >= 10 && (op[0]==0|| op[1] / op[0] > 0.4))
            {
                Console.WriteLine(await _userService.BlockUser(UserId));
            }
            else
            {
                if (op[1] >= 5 &&(op[0]==0|| op[1] / op[0] > 0.25))
                {
                    Console.WriteLine(await _userService.SuspendUser(UserId));
                }
            }
            return _mapper.Map<OpinionDTO>(res);
        }
    }
}

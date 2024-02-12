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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> SignIn(User user)
        {
            return _mapper.Map<UserDTO>(await _repository.SignIn(user));
        }
        public async Task<UserDTO> SignUp(User user)
        {
            return _mapper.Map<UserDTO>(await _repository.SignUp(user));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<int> GetCountOfOpinionsAsync(int id)
        {
            var gifts = await _repository.GetListOfGiftsAsync(id);
            int count = 0;
            foreach (var item in gifts)
            {
                foreach (var op in item.OpinionsList)
                {
                    if(!op.PositiveOpinion)
                        count++;
                }
               
            }
            return count;
        }

        public async Task<List<UserDTO>> GetListAsync()
        {
            var list = await _repository.GetListAsync();
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var item in list)
            {
                userDTOs.Add(_mapper.Map<UserDTO>(item));
            }
            return userDTOs;
        }

        public async Task<List<GiftDTO>> GetListOfGiftsAsync(int id)
        {
            var list = await _repository.GetListOfGiftsAsync(id);
            List<GiftDTO> giftDTOs = new List<GiftDTO>();
            foreach (var item in list)
            {
                giftDTOs.Add(_mapper.Map<GiftDTO>(item));
            }
            return giftDTOs;
        }

        public async Task<UserDTO> UpdateAsync(int id, User user)
        {
            return _mapper.Map<UserDTO>(await _repository.UpdateAsync(id, user));
        }

        public async Task<string> BlockUser(int id)
        {
            return await _repository.BlockUser(id);
        }

        public async Task<string> SuspendUser(int id)
        {
            return await _repository.SuspendUser(id);
        }

        public async Task<string> UnSuspendUser(int id)
        {
            return await _repository.UnSuspendUser(id);
        }
    }
}

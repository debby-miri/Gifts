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
            if(user == null) { return null; }
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
        //מחזיר מערך של חוות דעת כאשר הראשון זה החיובי והשני זה השלילי
        public async Task<int[]> GetCountOfOpinionsAsync(int id)
        {
           return new int[] { (await _repository.GetListOfGiftsAsync(id)).Sum(item => item.OpinionsList.Count(op => op.PositiveOpinion)), (await _repository.GetListOfGiftsAsync(id)).Sum(item => item.OpinionsList.Count(op => !op.PositiveOpinion)) };
        }
        public async Task<List<UserDTO>> GetListAsync()
        {
            return _mapper.Map<List<UserDTO>>(await _repository.GetListAsync());
        }

        public async Task<List<GiftDTO>> GetListOfGiftsAsync(int id)
        {
            return _mapper.Map<List<GiftDTO>>(await _repository.GetListOfGiftsAsync(id));
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

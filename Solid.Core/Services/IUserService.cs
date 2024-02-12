using Gifts;
using Solid.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetListAsync();
        Task<List<GiftDTO>> GetListOfGiftsAsync(int id);
        Task<int> GetCountOfOpinionsAsync(int id);

        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> SignIn(User user);
        Task<UserDTO> SignUp(User user);

        Task<UserDTO> UpdateAsync(int id,User user);

        Task DeleteAsync(int id);
        //לחסום
        Task<string> BlockUser(int id);
        //להשהות
        Task<string> SuspendUser(int id);
        Task<string> UnSuspendUser(int id);
    }
}

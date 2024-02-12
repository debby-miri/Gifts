using Gifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetListAsync();
        Task<List<Gift>> GetListOfGiftsAsync(int id);
        Task<User> GetByIdAsync(int id);

        Task<User> SignIn(User user);
        Task<User> SignUp(User user);

        Task<User> UpdateAsync(int id,User user);

        Task DeleteAsync(int id);
        //לחסום
        Task<string> BlockUser(int id);
        //להשהות
        Task<string> SuspendUser(int id);
        Task<string> UnSuspendUser(int id);
    }
}

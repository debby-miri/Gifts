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

        Task<User> AddAsync(User role);

        Task<User> UpdateAsync(int id,User role);

        Task DeleteAsync(int id);
    }
}

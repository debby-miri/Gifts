using Gifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IGiftsRepository
    {
        Task<Gift> UpdateViews(int id);
        Task<List<Gift>> GetListAsync();
        Task<List<Opinion>> GetOpinionAsync(int giftId);
        Task<Gift> GetByIdAsync(int id);

        Task DeleteAsync(int id);
        Task<Gift> AddAsync(Gift gift);
    }
}

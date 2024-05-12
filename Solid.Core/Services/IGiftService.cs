using Gifts;
using Solid.Core.DTO;
using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IGiftService
    {
        Task<List<GiftDTO>> GetListAsync();
        Task<GiftDTO> GetByIdAsync(int id);
        Task<List<OpinionDTO>> GetOpinionAsync(int giftId);

        Task DeleteAsync(int id);
        Task<GiftDTO> AddAsync(Gift gift);
        Task<List<GiftDTO>> GetFilteredGifts(double Age, double EstimatedPrice, int Gender, int Events, int Categry);
    }
}

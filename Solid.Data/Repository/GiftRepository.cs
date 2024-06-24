using Gifts;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repository
{
    public class GiftRepository : IGiftsRepository
    {
        private readonly DataContext _context;
        public GiftRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Gift> AddAsync(Gift gift)
        {
            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();
            return gift;
        }

        public async Task DeleteAsync(int id)
        {
            Gift g = _context.Gifts.FirstOrDefault(g => g.GiftId == id);
            _context.Gifts.Remove(g);
            _context.SaveChanges();
        }
        //0778841673
        //9855
        //73

        public async Task<Gift> GetByIdAsync(int id)
        {
            return (await GetListAsync()).FirstOrDefault(g => g.GiftId == id);
        }

        public async Task<List<Gift>> GetListAsync()
        {
            return await _context.Gifts.Include(g => g.OpinionsList).ToListAsync();
        }

        public async Task<List<Opinion>> GetOpinionAsync(int giftId)
        {
            return await _context.Opinions.Where(op => op.Gift.GiftId == giftId).ToListAsync();
        }

        public async Task<Gift> UpdateViews(int id)
        {
            Gift gift = _context.Gifts.FirstOrDefault(x => x.GiftId == id);
            if (gift != null)
            {
                gift.NumberOfViews++;
            }
            await _context.SaveChangesAsync();
            return gift;
        }
    }
}

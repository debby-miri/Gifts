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
            var g = await GetByIdAsync(id);
            _context.Gifts.Remove(g);
        }

        public async Task<Gift> GetByIdAsync(int id)
        {
           return (await GetListAsync()).FirstOrDefault(g=>g.GiftId == id);
        }

        public async Task<List<Gift>> GetListAsync()
        {
            return await _context.Gifts.Include(g=>g.OpinionsList).ToListAsync();        }

        public async Task<List<Opinion>> GetOpinionAsync(int giftId)
        {
            return await _context.Opinions.Where(op => op.Gift.GiftId == giftId).ToListAsync();
        }
    }
}

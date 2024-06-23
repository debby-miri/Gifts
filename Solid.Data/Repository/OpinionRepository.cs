using Gifts;
using Solid.Core.DTO;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repository
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly DataContext _context;
        public OpinionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Opinion> AddOpinion(Opinion opinion)
        {
            _context.Opinions.Add(opinion);
            await _context.SaveChangesAsync();
            return opinion;
        }
    
    }
}

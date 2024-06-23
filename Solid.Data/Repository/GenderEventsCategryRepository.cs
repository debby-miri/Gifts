using Gifts;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entity;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repository
{
    public class GenderEventsCategryRepository : IGenderEventsCategryRepository
    {
        private readonly DataContext _context;
        public GenderEventsCategryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Categry> AddCategry(Categry categry)
        {
            _context.Categrys.Add(categry);
            await _context.SaveChangesAsync();
            return categry;
        }

        public async Task<Events1> AddEvents(Events1 event1)
        {
            _context.Events11.Add(event1);
            await _context.SaveChangesAsync();
            return event1;
        }

        public async Task<Gender> AddGender(Gender gender)
        {
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
        public async Task<List<Categry>> GetCategriesAsync()
        {
            return await _context.Categrys.ToListAsync();
        }

        public async Task<List<Events1>> GetEvents1Async()
        {
            return await _context.Events11.ToListAsync();
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}

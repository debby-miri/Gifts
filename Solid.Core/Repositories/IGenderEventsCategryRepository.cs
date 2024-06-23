using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IGenderEventsCategryRepository
    {
        Task<List<Gender>> GetGendersAsync();
        Task<List<Events1>> GetEvents1Async();
        Task<List<Categry>> GetCategriesAsync();
        Task<Gender> AddGender(Gender gender);
        Task<Events1> AddEvents(Events1 event1);
        Task<Categry> AddCategry(Categry categry);
    }
}

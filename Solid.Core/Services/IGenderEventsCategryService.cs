using Solid.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IGenderEventsCategryService
    {
        Task<List<Gender>> GetGendersAsync();
        Task<List<Events1>> GetEvents1Async();
        Task<List<Categry>> GetCategriesAsync();
    }
}

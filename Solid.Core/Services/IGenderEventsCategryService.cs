using Solid.Core.DTO;
using Solid.Core.Entity;

namespace Solid.Core.Services
{
    public interface IGenderEventsCategryService
    {
        Task<List<GenderDTO>> GetGendersAsync();
        Task<List<EventsDTO>> GetEvents1Async();
        Task<List<CategryDTO>> GetCategriesAsync();
        Task<GenderDTO> AddGender(Gender gender);
        Task<EventsDTO> AddEvents(Events1 event1);
        Task<CategryDTO> AddCategry(Categry categry);
    }
}

using AutoMapper;
using Gifts;
using Solid.Core.DTO;
using Solid.Core.Entity;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class GenderEventsCategryService : IGenderEventsCategryService
    {
        private readonly IGenderEventsCategryRepository _repository;
        private readonly IMapper _mapper;
        public GenderEventsCategryService(IGenderEventsCategryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategryDTO> AddCategry(Categry categry)
        {
            return _mapper.Map<CategryDTO>(await _repository.AddCategry(categry));
        }

        public async Task<EventsDTO> AddEvents(Events1 event1)
        {
            return _mapper.Map<EventsDTO>(await _repository.AddEvents(event1));
        }

        public async Task<GenderDTO> AddGender(Gender gender)
        {
            return _mapper.Map<GenderDTO>(await _repository.AddGender(gender));
        }

        public async Task<List<CategryDTO>> GetCategriesAsync()
        {
            return _mapper.Map<List<CategryDTO>>(await _repository.GetCategriesAsync());
        }

        public async Task<List<EventsDTO>> GetEvents1Async()
        {
            return _mapper.Map<List<EventsDTO>>(await _repository.GetEvents1Async());
        }

        public async Task<List<GenderDTO>> GetGendersAsync()
        {
            return _mapper.Map<List<GenderDTO>>(await _repository.GetGendersAsync());
        }
    }
}

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
            var list = await _repository.GetCategriesAsync();
            List<CategryDTO> categryDTOs = new List<CategryDTO>();
            foreach (var item in list)
            {
                categryDTOs.Add(_mapper.Map<CategryDTO>(item));
            }
            return categryDTOs;
        }

        public async Task<List<EventsDTO>> GetEvents1Async()
        {
            var list = await _repository.GetEvents1Async();
            List<EventsDTO> eventsDTOs = new List<EventsDTO>();
            foreach (var item in list)
            {
                eventsDTOs.Add(_mapper.Map<EventsDTO>(item));
            }
            return eventsDTOs;
        }

        public async Task<List<GenderDTO>> GetGendersAsync()
        {
            var list = await _repository.GetGendersAsync();
            List<GenderDTO> genderDTOs = new List<GenderDTO>();
            foreach (var item in list)
            {
                genderDTOs.Add(_mapper.Map<GenderDTO>(item));
            }
            return genderDTOs;
        }
    }
}

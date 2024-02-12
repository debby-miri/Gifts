using AutoMapper;
using Gifts;
using Solid.Core.DTO;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class OpinionService : IOpinionService
    {
        private readonly IOpinionRepository _repository;
        private readonly IMapper _mapper;
        public OpinionService(IOpinionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<OpinionDTO> AddOpinion(Opinion opinion)
        {
            return _mapper.Map<OpinionDTO>(await _repository.AddOpinion(opinion));
        }
    }
}

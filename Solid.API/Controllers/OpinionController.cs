using AutoMapper;
using Gifts;
using Microsoft.AspNetCore.Mvc;
using Solid.API.PostModels;
using Solid.Core.DTO;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionService _service;
        private readonly IMapper _mapper;
        public OpinionController(IOpinionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // POST api/<OpinionController>
        [HttpPost]
        public async Task<OpinionDTO> Post([FromBody] OpinionPostModel opinion)
        {
            var res = await _service.AddOpinion(_mapper.Map<Opinion>(opinion));
            return res;
        }       
    }
}

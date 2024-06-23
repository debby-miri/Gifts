using AutoMapper;
using Gifts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solid.Core.DTO;
using Solid.Core.Entity;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendetEventsCategryController : ControllerBase
    {
        private readonly IGenderEventsCategryService _service;
        private readonly IMapper _mapper;
        public GendetEventsCategryController(IGenderEventsCategryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/<GendetEventsCategryController>
        [HttpGet("Gender")]
        public async Task<List<GenderDTO>> GetGender()
        {
            return await _service.GetGendersAsync();
        }
        [HttpGet("Events")]
        public async Task<List<EventsDTO>> GetEvents()
        {
            return await _service.GetEvents1Async();
        }
        [HttpGet("Category")]
        public async Task<List<CategryDTO>> GetCategory()
        {
            return await _service.GetCategriesAsync();
        }
        // POST api/<GendetEventsCategryController>
        [HttpPost("Gender")]
        public async Task<GenderDTO> PostGender([FromBody] string value)
        {
            Gender gender = new Gender { Name = value };
            return await _service.AddGender(gender);

        }
        [HttpPost("Category")]
        public async Task<CategryDTO> PostCategory([FromBody] string value)
        {
            Categry gender = new Categry { Name = value };
            return await _service.AddCategry(gender);

        }     
        [HttpPost("Events")]
        public async Task<EventsDTO> PostEvents([FromBody] string value)
        {
            Events1 gender = new Events1 { Name = value };
            return await _service.AddEvents(gender);

        }
    }
}

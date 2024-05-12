using AutoMapper;
using Gifts;
using Microsoft.AspNetCore.Mvc;
using Solid.API.PostModels;
using Solid.Core.DTO;
using Solid.Core.Services;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _service;
        private readonly IMapper _mapper;
        public GiftController(IGiftService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("filter")]
        public async Task<List<GiftDTO>> GetFilteredGifts([FromQuery][SwaggerParameter(Required = false)] double? Age, [FromQuery][SwaggerParameter(Required = false)] double? EstimatedPrice, [FromQuery][SwaggerParameter(Required = false)] bool? Gender, [FromQuery][SwaggerParameter(Required = false)] EEvents? Events, [FromQuery][SwaggerParameter(Required = false)] ECategory? Categry)
        {
            double Age2 = Age == null ? -1 : (double)Age;
            double ep = EstimatedPrice == null ? -1 : (double)EstimatedPrice;
            return await _service.GetFilteredGifts(Age2, ep, Gender == null ? false : (bool)Gender, Events == null ? 0 : (EEvents)Events, Categry == null ? 0 : (ECategory)Categry);
        }
        // GET: api/<GiftController>
        [HttpGet]
        public async Task<List<GiftDTO>> GetAll()
        {
            return await _service.GetListAsync();
        }
        [HttpGet("opinionOfGift")]
        public async Task<List<OpinionDTO>> GetOpinionAsync(int giftId)
        {
            return await _service.GetOpinionAsync(giftId);
        }
        // GET api/<GiftController>/5
        [HttpGet("{id}")]
        public async Task<GiftDTO> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }
        // POST api/<GiftController>
        [HttpPost]
        public async Task<GiftDTO> Post([FromBody] GiftPostModel g)
        {
            var res = await _service.AddAsync(_mapper.Map<Gift>(g));
            return res;
        }
        /*
                // PUT api/<GiftController>/5
                [HttpPut("{id}")]
                public void Put(int id, [FromBody] string value)
                {
                }*/
        // DELETE api/<GiftController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
    
}

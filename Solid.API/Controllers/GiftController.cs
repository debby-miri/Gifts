using AutoMapper;
using Gifts;
using Microsoft.AspNetCore.Mvc;
using Solid.API.PostModels;
using Solid.Core.DTO;
using Solid.Core.Entity;
using Solid.Core.Services;
using Solid.Service;
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
        public async Task<List<GiftDTO>> GetFilteredGifts([FromQuery][SwaggerParameter(Required = false)] double? Age, [FromQuery][SwaggerParameter(Required = false)] double? EstimatedPrice, [FromQuery][SwaggerParameter(Required = false)] int? Gender, [FromQuery][SwaggerParameter(Required = false)] int? Events, [FromQuery][SwaggerParameter(Required = false)] int? Categry)
        {
            double Age2 = Age == null ? -1 : (double)Age;
            double ep = EstimatedPrice == null ? -1 : (double)EstimatedPrice;
            return await _service.GetFilteredGifts(Age2, ep, Gender == null ? 1 : (int)Gender, Events == null ? 1 : (int)Events, Categry == null ? 1 : (int)Categry);
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
            Gift gift = _mapper.Map<Gift>(g);
            gift.DateOfEntry = DateTime.Now;
            gift.NumberOfViews = 0;
            var res = await _service.AddAsync(gift);
            return res;
        }
        [HttpPut("{id}")]
        public async Task<GiftDTO> UpdateViews(int id)
        {

            var res = await _service.UpdateViews(id);
            return res;
        }
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }

}

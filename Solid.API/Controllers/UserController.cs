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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService service,IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            return await _userService.GetListAsync();
        }
        [HttpGet("Gifts/{id}")]
        public async Task<List<GiftDTO>> GetUserGifts(int id)
        {
            return await _userService.GetListOfGiftsAsync(id);
        }
        [HttpGet("Opinions/{id}")]
        public async Task<int> GetUserOpinions(int id)
        {
            return await _userService.GetCountOfOpinionsAsync(id);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var User= await _userService.GetByIdAsync(id);
            if(User is  null)
            {
                return NotFound();
            }
            return User;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserPostModel user)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            return await _userService.AddAsync(_mapper.Map<User>(user));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserPostModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return await _userService.UpdateAsync(id,_mapper.Map<User>(user));

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteAsync(id);
        }

    }
}

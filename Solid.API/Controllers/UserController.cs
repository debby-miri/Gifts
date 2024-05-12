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
        //enter after there is an acount
        // POST api/<UserController>
        [HttpPost("signIn")]
        public async Task<ActionResult<UserDTO>> SignIn([FromBody] UserPostModel user)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var res= await _userService.SignIn(new User { Mail=user.Mail ,Password=user.Password});
            if (res is null)
                return StatusCode(400);
            if (res.Status == 0)
            {
                //פעיל 1
                //מושהה 0
                //חסום 2

                int totalDays = (int)(DateTime.Now - res.DateOfStatusChange).TotalDays;
                if (totalDays > 7)
                {
                    Console.WriteLine( await _userService.UnSuspendUser(res.UserId));
                }
                else
                {
                    return StatusCode(300);
                }
                
            }
            if(res.Status == 2)
            {
                return StatusCode(301);
            }
            return res;
        }
        //login
        [HttpPost("signUp")]
        public async Task<ActionResult<UserDTO>> SignUp([FromBody] SignUpModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            User u = _mapper.Map<User>(user);
            u.Status = 1;
            u.DateOfStatusChange = DateTime.Now;
            var res = await _userService.SignUp(u);
            if (res is null)
                return StatusCode(400);
            return res;
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

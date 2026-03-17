using AutoMapper;
using clean.API.Models;
using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Services;
using clean.Service.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService _userService;
        private readonly IMapper _mapper;

        public UserController(IuserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var list = await _userService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound($"User {id} not found");

            var userDto = _mapper.Map<UserDetailsDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserPostModel userModel)
        {
            var userEntity = _mapper.Map<User>(userModel);
            var createdUser = await _userService.AddUserAsync(userEntity);
            var userDto = _mapper.Map<UserDto>(createdUser);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserPostModel userModel)
        {
            var userEntity = _mapper.Map<User>(userModel);
            var updatedUser = await _userService.UpdateUserAsync(id, userEntity);

            if (updatedUser == null)
                return NotFound($"Update failed: User {id} not found");

            var userDto = _mapper.Map<UserDetailsDto>(updatedUser);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var userDeleted = await _userService.DeleteUserAsync(id);
            if (userDeleted == null)
                return NotFound();

            return NoContent();
        }
    }
}
using AutoMapper;
using clean.API.Models;
using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Models;
using clean.Core.Services;
using clean.Service.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var list = await _userProfileService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<UserProfileDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var profile = await _userProfileService.GetProfileByIdAsync(id);
            if (profile == null)
                return NotFound($"Profile {id} not found");

            var profileDto = _mapper.Map<ProfileDetailsDto>(profile);
            return Ok(profileDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserProfilePostModel profileModel)
        {
            var profileEntity = _mapper.Map<UserProfile>(profileModel);
            var createdProfile = await _userProfileService.AddProfileAsync(profileEntity);

            if (createdProfile == null)
                return BadRequest("User not found or profile already exists");

            var profileDto = _mapper.Map<ProfileDetailsDto>(createdProfile);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = profileDto.Id }, profileDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserProfilePostModel profileModel)
        {
            var profileEntity = _mapper.Map<UserProfile>(profileModel);
            var updatedProfile = await _userProfileService.UpdateProfileAsync(id, profileEntity);

            if (updatedProfile == null)
                return NotFound($"Profile {id} not found");

            var profileDto = _mapper.Map<ProfileDetailsDto>(updatedProfile);
            return Ok(profileDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedProfile = await _userProfileService.DeleteProfileAsync(id);
            if (deletedProfile == null)
                return NotFound();

            return NoContent();
        }
    }
}

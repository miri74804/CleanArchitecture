using AutoMapper;
using clean.API.Models;
using clean.Core.DTOs;
using clean.Core.Models;
using clean.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var list = await _categoryService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<CategoryDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            var categoryDto = _mapper.Map<CategoryDetailsDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryPostModel category)
        {
            var c = _mapper.Map<Category>(category);
            var newCategory = await _categoryService.AddCategoryAsync(c);
            var categoryDto = _mapper.Map<CategoryDto>(newCategory);
            //nameof מפנה לשם הפונקציה החדש GetByIdAsync
            return CreatedAtAction(nameof(GetByIdAsync), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CategoryPostModel category)
        {
            var c = _mapper.Map<Category>(category);
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, c);

            if (updatedCategory == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(_mapper.Map<CategoryDetailsDto>(updatedCategory));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(id);
            if (deleted == null)
                return NotFound();

            return NoContent();
        }
    }
}

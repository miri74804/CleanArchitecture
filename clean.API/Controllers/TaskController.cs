using AutoMapper;
using clean.API.Models;
using clean.Core;
using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Services;
using clean.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAsync()
        {
            var list = await _taskService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<TaskDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (task.userId.ToString() != userIdFromToken)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "You can only view your own tasks." });
            }

            var taskDto = _mapper.Map<TaskDetailsDto>(task);
            return Ok(taskDto);
        }

        [HttpPost]
        [Authorize] 
        public async Task<ActionResult> PostAsync([FromBody] TaskPostModel taskModel)
        {
            var userIdFromToken = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdFromToken))
                return Unauthorized();

            var taskItem = _mapper.Map<TaskItem>(taskModel);
            taskItem.userId = int.Parse(userIdFromToken);
            var createdTask = await _taskService.AddTaskAsync(taskItem);

            if (createdTask == null)
                return BadRequest("User not found or validation failed");

            var taskCreatedDto = _mapper.Map<TaskDetailsDto>(createdTask);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = taskCreatedDto.Id }, taskCreatedDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> PutAsync(int id, [FromBody] TaskPostModel taskModel)
        {
            var taskItem = _mapper.Map<TaskItem>(taskModel);

            var userIdFromToken = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (taskItem.userId.ToString() != userIdFromToken)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "You can only update your own tasks." });
            }

            var updatedTask = await _taskService.UpdateTaskAsync(id, taskItem);

            if (updatedTask == null)
                return NotFound("Task or User not found");

            var taskUpdatedDto = _mapper.Map<TaskDetailsDto>(updatedTask);
            return Ok(taskUpdatedDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            var userIdFromToken = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (task.userId.ToString() != userIdFromToken)
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "You are not authorized to delete this task." });
           
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}

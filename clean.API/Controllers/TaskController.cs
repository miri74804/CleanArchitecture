using AutoMapper;
using clean.API.Models;
using clean.Core;
using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Services;
using clean.Service.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetAsync()
        {
            var list = await _taskService.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<TaskDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            var taskDto = _mapper.Map<TaskDetailsDto>(task);
            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TaskPostModel taskModel)
        {
            var taskItem = _mapper.Map<TaskItem>(taskModel);
            var createdTask = await _taskService.AddTaskAsync(taskItem);

            if (createdTask == null)
                return NotFound("User not found or validation failed");

            var taskCreatedDto = _mapper.Map<TaskDetailsDto>(createdTask);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = taskCreatedDto.Id }, taskCreatedDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] TaskPostModel taskModel)
        {
            var taskItem = _mapper.Map<TaskItem>(taskModel);
            var updatedTask = await _taskService.UpdateTaskAsync(id, taskItem);

            if (updatedTask == null)
                return NotFound("Task or User not found");

            var taskUpdatedDto = _mapper.Map<TaskDetailsDto>(updatedTask);
            return Ok(taskUpdatedDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedTask = await _taskService.DeleteTaskAsync(id);
            if (deletedTask == null)
                return NotFound();

            return NoContent();
        }
    }
}

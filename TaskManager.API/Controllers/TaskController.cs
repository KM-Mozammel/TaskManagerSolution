// TaskManager.API/Controllers/TaskController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Application.Services;
using TaskManager.Core.Models;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetById(int id)
        {
            var task = _taskService.GetTaskById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] TaskModel task)
        {
            _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}

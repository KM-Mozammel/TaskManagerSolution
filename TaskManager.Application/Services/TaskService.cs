using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public TaskModel GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }
        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public void CreateTask(TaskModel task)
        {
            _taskRepository.Add(task);
        }

        public void UpdateTask(TaskModel task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models;

namespace TaskManager.Application.Services
{
    public interface ITaskService
    {
        TaskModel GetTaskById(int id);
        IEnumerable<TaskModel> GetAllTasks();
        void CreateTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(int id);
    }
}

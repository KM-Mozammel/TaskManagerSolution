using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models;

namespace TaskManager.Core.Repositories
{
    public interface ITaskRepository
    {
        TaskModel GetById(int id);
        IEnumerable<TaskModel> GetAll();
        void Add(TaskModel task);
        void Update(TaskModel task);
        void Delete(int id);
    }
}

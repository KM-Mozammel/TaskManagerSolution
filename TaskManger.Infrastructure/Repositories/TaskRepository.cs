using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;
using System.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public TaskModel GetById(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<TaskModel>("SELECT * FROM Tasks WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<TaskModel> GetAll()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<TaskModel>("SELECT * FROM Tasks");
            }
        }
        public void Add(TaskModel task)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                connection.Execute("INSERT INTO Tasks (Title, Description, DueDate, IsCompleted) VALUES (@Title, @Description, @DueDate, @IsCompleted)", task);
            }
        }

        public void Update(TaskModel task)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                connection.Execute("UPDATE Tasks SET Title = @Title, Description = @Description, DueDate = @DueDate, IsCompleted = @IsCompleted WHERE Id = @Id", task);
            }
        }
        public void Delete(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                connection.Execute("DELETE FROM Tasks WHERE Id = @Id", new { Id = id });
            }
        }
    }
}

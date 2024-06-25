using TaskManager.Application.Services;
using TaskManager.Core.Repositories;
using TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Getting The Connection String
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the repository with the connection string
builder.Services.AddScoped<ITaskRepository>(provider => new TaskRepository(connectionString));
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

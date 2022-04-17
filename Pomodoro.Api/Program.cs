using Microsoft.EntityFrameworkCore;
using Pomodoro.Api;
using Pomodoro.BL;
using Pomodoro.Core;
using Pomodoro.DAL.Postgres;
using Pomodoro.DAL.Postgres.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services.AddScoped<ITaskCategoriesService, TaskCategoriesService>();

builder.Services.AddScoped<ITaskCategoryRepository, TaskCategoryRepository>();

builder.Services.AddScoped<ITasksService, TaskService>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfle), typeof(MappingDBProfile));

builder.Services.AddDbContext<PomodoroDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PomodoroConnection"),
        x => x.MigrationsAssembly("Pomodoro.DAL.Postgres")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}

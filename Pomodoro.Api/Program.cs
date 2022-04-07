using Microsoft.EntityFrameworkCore;
using Pomodoro.Api;
using Pomodoro.BL;
using Pomodoro.Core;
using Pomodoro.DAL.MSSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskCategoriesService, TaskCategoriesService>();
builder.Services.AddAutoMapper(typeof(TaskCategoriesProfile));

builder.Services.AddDbContext<PomodoroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PomodoroConnection"),
        x => x.MigrationsAssembly("Pomodoro.DAL.MSSQL")));

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

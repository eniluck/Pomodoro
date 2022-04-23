using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Pomodoro.Api;
using Pomodoro.BL;
using Pomodoro.Core;
using Pomodoro.DAL.Postgres;
using Pomodoro.DAL.Postgres.Repositories;
using Serilog;

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

builder.Services.AddOpenTelemetryTracing(b=>
{
    // uses the default Jaeger settings
    b.AddJaegerExporter();

    // receive traces from our own custom sources
    b.AddSource(TelemetryConstants.MyAppTraceSource);

    // decorate our service name so we can find it when we look inside Jaeger
    b.SetResourceBuilder(ResourceBuilder.CreateDefault()
        .AddService("AspNetCore", "Pomodoro"));

    // receive traces from built-in sources
    b.AddHttpClientInstrumentation();
    b.AddAspNetCoreInstrumentation();
    b.AddSqlClientInstrumentation();
});

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();

builder.Logging.AddSerilog(logger);

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

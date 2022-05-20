using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Core;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class TimerController : ControllerBase
    {
        private readonly ITimerService _timerService;
        private readonly IMapper _mapper;
        private readonly ILogger<TimerController> _logger;

        public TimerController(
            ILogger<TimerController> logger,
            IMapper mapper,
            ITimerService timerService)
        {
            _timerService = timerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("taskId:int")]
        public async Task<IActionResult> Start(int taskId)
        {
            await _timerService.StartAsync(taskId);
            return Ok();
        }
    }
}

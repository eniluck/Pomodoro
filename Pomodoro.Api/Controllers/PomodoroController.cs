using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Core;

namespace Pomodoro.Api.Controllers
{
    public class PomodoroController : BaseController
    {
        private readonly ITimerService _timerService;
        private readonly IMapper _mapper;
        private readonly ILogger<PomodoroController> _logger;

        public PomodoroController(
            ILogger<PomodoroController> logger,
            IMapper mapper,
            ITimerService timerService)
        {
            _timerService = timerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{taskId:int}")]
        public async Task<IActionResult> Start(int taskId)
        {
            var result = await _timerService.StartAsync(taskId);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
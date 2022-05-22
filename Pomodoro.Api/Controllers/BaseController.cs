using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {
    }
}

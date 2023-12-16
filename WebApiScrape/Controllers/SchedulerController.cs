using Microsoft.AspNetCore.Mvc;

namespace WebApiScrape.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {

        private readonly ILogger<SchedulerController> _logger;

        public SchedulerController(ILogger<SchedulerController> logger)
        {
            _logger = logger;
        }

    }
}
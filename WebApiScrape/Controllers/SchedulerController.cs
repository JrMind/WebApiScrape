using Microsoft.AspNetCore.Mvc;
using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {

        private readonly ICronScheduler cronScheduler;

        public SchedulerController(ICronScheduler cronScheduler)
        {
            this.cronScheduler = cronScheduler;
        }

        [HttpPost("api/tasks/scrape")]
        public async Task<ActionResult<TaskCronScheduleResultDto>> CreateTaskScrape([FromBody] TaskScrapeCreationRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await cronScheduler.ScheduleJob(requestDto);
                return Ok(new { cronTaskResult = result.CronTaskResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
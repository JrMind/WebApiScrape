using Microsoft.AspNetCore.Mvc;
using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulerController : ControllerBase
    {

        private readonly IScrapeService scrapeService;

        public SchedulerController(IScrapeService scrapeService)
        {
            this.scrapeService = scrapeService;
        }

        [HttpPost("api/tasks/scrape")]
        public async Task<ActionResult<TaskScrapeResultDto>> CreateTaskScrape([FromBody] TaskScrapeCreationRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await scrapeService.GetHeadersAsync(requestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
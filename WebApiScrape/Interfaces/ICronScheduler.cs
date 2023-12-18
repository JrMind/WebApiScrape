using WebApiScrape.DTOs;

namespace WebApiScrape.Interfaces
{
    public interface ICronScheduler
    {
        Task<TaskCronScheduleResultDto> ScheduleJob(TaskScrapeCreationRequestDto request);
    }
}

using WebApiScrape.DTOs;

namespace WebApiScrape.Interfaces
{
    public interface ICronScheduler
    {
        Task ScheduleJob(TaskScrapeCreationRequestDto request);
    }
}

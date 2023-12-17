using WebApiScrape.DTOs;

namespace WebApiScrape.Interfaces
{
    public interface IScrapeService
    {
        Task<TaskScrapeResultDto> GetHeadersAsync(TaskScrapeCreationRequestDto request);
    }
}

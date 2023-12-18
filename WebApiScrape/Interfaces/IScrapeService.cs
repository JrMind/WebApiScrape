using WebApiScrape.DTOs;

namespace WebApiScrape.Interfaces
{
    public interface IScrapeService
    {
        Task GetAndSaveCSVHeaders(TaskScrapeCreationRequestDto request);
        Task<TaskScrapeResultDto> GetHeaders(TaskScrapeCreationRequestDto request);
    }
}

using WebApiScrape.DTOs;

namespace WebApiScrape.Interfaces
{
    public interface IScrapePage
    {
        Task<Dictionary<string, string>> GetHeadersAsync(TaskScrapeCreationRequestDto url);
    }
}

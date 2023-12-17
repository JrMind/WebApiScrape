using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Services
{
    public class ScrapeService : IScrapePage
    {
        public Task<Dictionary<string, string>> GetHeadersAsync(TaskScrapeCreationRequestDto url)
        {
            throw new NotImplementedException();
        }
    }
}

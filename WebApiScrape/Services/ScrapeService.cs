using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Services
{
    public class ScrapeService : IScrapeService
    {
        public async Task<TaskScrapeResultDto> GetHeadersAsync(TaskScrapeCreationRequestDto request)
        {
            var headers = new Dictionary<string, string>();

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(request.Url);
            
                foreach(var header in response.Headers)
                {
                    headers.Add(header.Key, string.Join(",", header.Value));
                }
            }
            catch (Exception ex)            { 

            }
            var resultDto = new TaskScrapeResultDto
            {
                Url = request.Url,
                Headers = headers
            };

            return resultDto;
        }
    }
}

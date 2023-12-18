using System.Text;
using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Services
{
    public class ScrapeService : IScrapeService
    {
        public async Task GetAndSaveCSVHeaders(TaskScrapeCreationRequestDto request)
        {
            var resultDto = await GetHeaders(request);

            var csv = new StringBuilder();
            foreach (var header in resultDto.Headers)
            {
                csv.AppendLine($"{header.Key},{header.Value}");
            }

            string filePath = "headers.csv"; 
            File.WriteAllText(filePath, csv.ToString());
        }

        public async Task<TaskScrapeResultDto> GetHeaders(TaskScrapeCreationRequestDto request)
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

using System.ComponentModel.DataAnnotations;

namespace WebApiScrape.DTOs
{
    public class TaskScrapeCreationRequestDto
    {
        [Required]
        public string CronExpression { get; set; }
        [Required]
        public string Url { get; set; }
    }

    public class TaskScrapeResultDto
    {
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }

    public class TaskCronScheduleResultDto
    {
        public string CronTaskResult { get; set; }
    }
}

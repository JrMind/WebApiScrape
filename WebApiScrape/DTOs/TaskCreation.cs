using System.ComponentModel.DataAnnotations;

namespace WebApiScrape.DTOs
{
    public class TaskCreation
    {
        [Required]
        public string CronExpression { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

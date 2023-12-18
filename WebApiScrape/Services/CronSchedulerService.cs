using Hangfire;
using System.Security.Policy;
using WebApiScrape.DTOs;
using WebApiScrape.Interfaces;

namespace WebApiScrape.Services
{
    public class CronSchedulerService : ICronScheduler
    {
        private readonly IScrapeService scrapeService;
        private readonly IRecurringJobManager recurringJobManager;

        public CronSchedulerService(IScrapeService scrapeService, IRecurringJobManager recurringJobManager)
        {
            this.scrapeService = scrapeService;
            this.recurringJobManager = recurringJobManager;

        }

        public async Task<TaskCronScheduleResultDto> ScheduleJob(TaskScrapeCreationRequestDto request)
        {
            try
            {
                recurringJobManager.AddOrUpdate(
                 "ScrapeJob",
                 () => scrapeService.GetAndSaveCSVHeaders(request),
                 request.CronExpression,
                 TimeZoneInfo.Local);

                return new TaskCronScheduleResultDto
                {
                    CronTaskResult = "Tarea agendada con éxito."
                };
            }
        catch (Exception ex)
        {
                return new TaskCronScheduleResultDto
                {
                    CronTaskResult = $"Error al agendar la tarea: {ex.Message}"
                };
            }
}
        
    }
}

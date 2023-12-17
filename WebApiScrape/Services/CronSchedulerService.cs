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

        public async Task ScheduleJob(TaskScrapeCreationRequestDto request)
        {
            recurringJobManager.AddOrUpdate(
             "ScrapeJob", 
             () => scrapeService.GetHeadersAsync(request), 
             request.CronExpression,
             TimeZoneInfo.Local);
        }
    }
}

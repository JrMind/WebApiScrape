using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using WebApiScrape;
using WebApiScrape.Interfaces;
using WebApiScrape.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IScrapeService, ScrapeService>();
builder.Services.AddScoped<ICronScheduler, CronSchedulerService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));
//cors -- validate correct configuration
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                            builder => builder.AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()));

builder.Services.AddHangfireServer();
builder.Services.AddScoped<CronSchedulerService>();
var app = builder.Build();

app.UseCors("AllowWebapp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();

app.MapControllers();

app.Run();

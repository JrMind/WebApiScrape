Scrape and CRON Expressions API
This project is for scheduling a programmed task with a CRON expression, and at this specific moment, perform SCRAPING on the specified webpage. For this, 2 input parameters are received, which are CRON EXPRESSION and URL.

Regarding the API:

The application is developed in .net6.
I used Hangfire for carrying out the scheduled tasks. EntityFramework is used to track the scheduled and executed Jobs in SQL SERVER, but also in the last version, the migration was made towards Azure SQL Database. Both options can be used if the default connection is changed, and Hangfire will create the tables when the application is launched for the first time.

To perform the SCRAPE, I used HtmlAgilityPack, saving the headers in a dictionary, and to provide evidence that this process is being carried out correctly, I decided to create a method to save the headers in a CSV file.

Servers:

The application was published on Azure, and this is its address for direct execution from swagger:
https://webapiscrape20231218182326.azurewebsites.net/swagger/index.html

Recommendations:

For testing purposes, it is recommended to run the application locally if you want to see if the Headers are being saved. Look for the headers.csv file within the project.
To view the scheduled tasks in your local host path, add HangFire, for example: https://localhost:7075/hangfire

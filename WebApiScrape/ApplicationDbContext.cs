using Microsoft.EntityFrameworkCore;

namespace WebApiScrape
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}

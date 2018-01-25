using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class RESTContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTContext(DbContextOptions<RESTContext> options) : base(options) { }

        public DbSet<Review> Entries { get; set; }
    }
}
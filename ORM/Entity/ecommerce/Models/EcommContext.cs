using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models
{
    public class EcommContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public EcommContext(DbContextOptions<EcommContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
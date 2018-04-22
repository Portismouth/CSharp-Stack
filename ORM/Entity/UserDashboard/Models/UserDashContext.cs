using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserDashboard.Models
{
    public class UserDashContext : IdentityDbContext<User>
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserDashContext(DbContextOptions<UserDashContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
    }
}
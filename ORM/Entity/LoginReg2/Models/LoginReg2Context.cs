using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LoginReg2.Models
{
    public class LoginReg2Context : IdentityDbContext<User>
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LoginReg2Context(DbContextOptions<LoginReg2Context> options) : base(options) { }
        public DbSet<User> users { get; set; }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rayverz.Data.Entities;

namespace rayverz.Data.Contexts
{
    public class DatabaseContext :IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<NewsletterUserState> NewletterState { get; set;}
    }
}

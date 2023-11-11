using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using System.Security;
using rayverz.Data.Entities;

namespace rayverz.Data.Contexts
{
    public interface IDatabaseContext
    {
        DbSet<Newsletter> Newsletters  { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellation = default);
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}

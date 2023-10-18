using Microsoft.EntityFrameworkCore;
using wsj.Domain.Entities;

namespace wsj.Persistence.Contexts;

public class WsjDbContext : DbContext
{
    public WsjDbContext(DbContextOptions<WsjDbContext> options) : base(options)
    {
        
    }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ChangeTracker.DetectChanges();
        var date = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
        {
            entry.Property("UpdatedAt").CurrentValue = date;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
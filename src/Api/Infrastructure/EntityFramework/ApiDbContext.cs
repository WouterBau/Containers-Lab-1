using ContainerLabs1.Api.Models;
using ContainerLabs1.Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContainerLabs1.Infrastructure.EntityFramework;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }

    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<LogEntry>(new LogEntryConfiguration());
    }

}
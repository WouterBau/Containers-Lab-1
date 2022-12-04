using Api.Models;
using ContainerLabs1.Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.EntityFramework;

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
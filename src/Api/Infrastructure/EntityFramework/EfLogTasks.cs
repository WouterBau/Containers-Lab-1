using ContainerLabs1.Api.Domain;
using ContainerLabs1.Api.Models;

namespace ContainerLabs1.Infrastructure.EntityFramework;

public class EfLogTasks : ILogTasks
{
    private readonly ApiDbContext _context;

    public EfLogTasks(ApiDbContext context)
    {
        _context = context;
    }

    public async Task AddLogEntry(string message)
    {
        var logEntry = new LogEntry{
            Message = message,
            CreationDateTime = DateTime.UtcNow
        };
        await _context.LogEntries.AddAsync(logEntry);
        await _context.SaveChangesAsync();
    }

    public LogEntry? GetLastLogEntry()
    {
        return _context.LogEntries
            .OrderByDescending(x => x.CreationDateTime)
            .FirstOrDefault();
    }
}
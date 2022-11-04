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

    public async Task AddLogEntry(LogEntry logEntry)
    {
        _context.LogEntries.Add(logEntry);
        await _context.SaveChangesAsync();
    }

    public LogEntry GetLastLogEntry()
    {
        throw new NotImplementedException();
    }
}
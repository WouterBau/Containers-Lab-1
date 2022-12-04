using ContainerLabs1.Api.Models;

namespace ContainerLabs1.Api.Domain;

public interface ILogTasks
{
    Task AddLogEntry(string message);
    LogEntry? GetLastLogEntry();
}
using ContainerLabs1.Api.Models;

namespace ContainerLabs1.Api.Domain;

public interface ILogTasks
{
    Task AddLogEntry(LogEntry logEntry);
    LogEntry GetLastLogEntry();
}
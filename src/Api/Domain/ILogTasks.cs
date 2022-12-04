using Api.Models;

namespace Api.Domain;

public interface ILogTasks
{
    Task AddLogEntry(string message);
    LogEntry? GetLastLogEntry();
}
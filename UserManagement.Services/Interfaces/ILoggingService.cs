using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface ILoggingService
{
    void LogAction(long Id, string action);
    IEnumerable<LogEntry> GetAllLogs();
    IEnumerable<LogEntry> GetLogsByUserId(long id);
}


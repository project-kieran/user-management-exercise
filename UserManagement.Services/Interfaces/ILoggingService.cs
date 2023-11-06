using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface ILoggingService
{
    void LogAction(string userId, string action);
    IEnumerable<LogEntry> GetAllLogs();
}


using System;
using System.Collections.Generic;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Implementations;
public class LoggingService : ILoggingService
{
    private readonly List<LogEntry> _logs;

    public LoggingService()
    {
        _logs = new List<LogEntry>();
    }

    public void LogAction(long id, string action)
    {
        var logEntry = new LogEntry
        {
            Id = id,
            Timestamp = DateTime.Now,
            Action = action
        };
        _logs.Add(logEntry);
    }

    public IEnumerable<LogEntry> GetAllLogs()
    {
        return _logs;
    }
}


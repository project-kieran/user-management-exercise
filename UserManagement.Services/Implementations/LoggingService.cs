using System;
using System.Collections.Generic;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Implementations;
public class LoggingService : ILoggingService
{
    private readonly IDataContext _logs;

    public LoggingService(IDataContext logs) => _logs = logs;
    
    public void LogAction(long id, string action)
    {
        var logEntry = new LogEntry
        {
            Id = id,
            Timestamp = DateTime.Now,
            Action = action
        };
        _logs.Create(logEntry);
    }

    public IEnumerable<LogEntry> GetAllLogs()
    {
        return _logs.GetAll<LogEntry>();
    }
}


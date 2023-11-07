using System;

namespace UserManagement.Web.Models.Users;

public class LogListViewModel
{
    public List<LogEntryViewModel> Items { get; set; } = new();
}

public class LogEntryViewModel
{
    public long Id { get; set; }
    public string Action { get; set; }
    public DateTime Timestamp { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models;
public class LogEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public string Action { get; set; } = default!;
}

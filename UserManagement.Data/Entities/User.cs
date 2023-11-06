using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required(ErrorMessage = "Forename is required.")]
    public string Forename { get; set; } = default!;
    [Required(ErrorMessage = "Surname is required.")]
    public string Surname { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; }
}

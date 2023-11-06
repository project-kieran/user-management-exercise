using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class AddUserViewModel
{
    [Required(ErrorMessage = "Forename is required.")]
    public string? Forename { get; set; }
    [Required(ErrorMessage = "Surname is required.")]
    public string? Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }
    public bool IsActive { get; set; }
}

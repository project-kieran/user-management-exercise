using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    /// <summary>
    /// [Required(ErrorMessage = "Forename is required.")]
    /// </summary>
    public string Forename { get; set; } = default!;
    /// <summary>
    /// [Required(ErrorMessage = "Surname is required.")]
    /// </summary>
    public string Surname { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    /// <summary>
    ///[Required(ErrorMessage = "Email is required.")]
    /// </summary>
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; }
}

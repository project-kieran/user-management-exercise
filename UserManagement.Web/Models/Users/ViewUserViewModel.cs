using System;

namespace UserManagement.Web.Models.Users;

public class ViewUserViewModel
{
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}

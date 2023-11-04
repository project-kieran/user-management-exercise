using System;

namespace UserManagement.Web.Models.Users;

public class DeleteUserViewModel
{
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
}

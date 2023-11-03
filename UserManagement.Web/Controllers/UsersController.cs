using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    public ViewResult List(string filter)
    {
        IEnumerable<User> users;
        if (filter == "active")
        {
            users = _userService.FilterByActive(true);
        }
        else if (filter == "nonactive")
        {
            users = _userService.FilterByActive(false);
        }
        else
        {
            users = _userService.GetAll();
        }
        var items = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Dob = p.Dob,
            Email = p.Email,
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }
}

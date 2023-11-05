using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;
using UserManagement.Models;
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
            DateOfBirth = p.DateOfBirth,
            Email = p.Email,
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View(new AddUserViewModel());
    }

    [HttpPost]
    public IActionResult Add(AddUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Convert AddUserViewModel to User entity and save to the database
            var user = new User
            {
                Forename = model.Forename,
                Surname = model.Surname,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                IsActive = model.IsActive
            };
            _userService.Add(user);
            return RedirectToAction("List");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult View(long id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return RedirectToAction("List");
        }

        var viewModel = new ViewUserViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            IsActive = user.IsActive
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Edit(long id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return RedirectToAction("List");
        }

        var viewModel = new EditUserViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            IsActive = user.IsActive
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(EditUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Id = model.Id,
                Forename = model.Forename!,
                Surname = model.Surname!,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email!,
                IsActive = model.IsActive
            };
            _userService.Update(user);
            return RedirectToAction("List");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Delete(long id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return RedirectToAction("List");
        }

        var viewModel = new DeleteUserViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Delete(DeleteUserViewModel model)
    {
        _userService.Delete(model.Id);
        return RedirectToAction("List");
    }
}

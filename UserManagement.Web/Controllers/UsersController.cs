﻿using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;
using UserManagement.Models;
using System;

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
    [Route("AddUser")]
    public IActionResult AddUser()
    {
        return View(new AddUserViewModel());
    }

    [HttpPost]
    [Route("AddUser")]
    public IActionResult AddUser(AddUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Convert AddUserViewModel to User entity and save to the database
            var user = new User
            {
                Forename = model.Forename!,
                Surname = model.Surname!,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email!,
                IsActive = model.IsActive
            };
            try
            {
                _userService.Add(user);
                return RedirectToAction("List");
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == nameof(user.Forename))
                {
                    ModelState.AddModelError("Forename", ex.Message);
                }
                else if (ex.ParamName == nameof(user.Surname))
                {
                    ModelState.AddModelError("Surname", ex.Message);
                }
                else if (ex.ParamName == nameof(user.Email))
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
        }
        return View(model);
    }

    [HttpGet]
    [Route("ViewUser/{id}")]
    public IActionResult ViewUser(long id)
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
    [Route("EditUser/{id}")]
    public IActionResult EditUser(long id)
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
    [Route("EditUser/{id}")]
    public IActionResult EditUser(EditUserViewModel model)
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
            try
            {
                _userService.Update(user);
                return RedirectToAction("List");
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == nameof(user.Forename))
                {
                    ModelState.AddModelError("Forename", ex.Message);
                }
                else if (ex.ParamName == nameof(user.Surname))
                {
                    ModelState.AddModelError("Surname", ex.Message);
                }
                else if (ex.ParamName == nameof(user.Email))
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
        }
        return View(model);
    }

    [HttpGet]
    [Route("DeleteUser/{id}")]
    public IActionResult DeleteUser(long id)
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
    [Route("DeleteUser/{id}")]
    public IActionResult DeleteUser(DeleteUserViewModel model)
    {
        _userService.Delete(model.Id);
        return RedirectToAction("List");
    }
}

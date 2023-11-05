using System.Linq;
using System.Collections.Generic;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using System;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive) => _dataAccess.GetAll<User>().Where(user => user.IsActive == isActive);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public void Add(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        if (string.IsNullOrEmpty(user.Forename))
        {
            throw new ArgumentException("Please enter a forename.", nameof(user.Forename));
        }

        if (string.IsNullOrEmpty(user.Surname))
        {
            throw new ArgumentException("Please enter a surname.", nameof(user.Surname));
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("Please enter an email address.", nameof(user.Email));
        }

        _dataAccess.Create(user);
    }

    public void Update(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        if (string.IsNullOrEmpty(user.Forename))
        {
            throw new ArgumentException("Please enter a forename.", nameof(user.Forename));
        }

        if (string.IsNullOrEmpty(user.Surname))
        {
            throw new ArgumentException("Please enter a surname.", nameof(user.Surname));
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("Please enter an email address.", nameof(user.Email));
        }
        _dataAccess.Update(user);
    }

    public User? GetById(long id) => _dataAccess.GetAll<User>().FirstOrDefault(u => u.Id == id);

    public void Delete(long id)
    {
        var user = _dataAccess.GetAll<User>().FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _dataAccess.Delete(user);
        }
    }

}

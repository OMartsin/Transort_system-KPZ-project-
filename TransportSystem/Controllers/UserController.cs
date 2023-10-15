using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;

namespace TransportSystem.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController {
    private TransportSystemContext _transportSystemContext;
    
    public UserController(TransportSystemContext transportSystemContext) {
        _transportSystemContext = transportSystemContext;
    }
    
    [HttpPost(Name = "AddUser")]
    public User AddUser(string name, string password, string role) {
        if (role is not ("agent" or "driver" or "administrator")) 
            throw new Exception("Invalid role");
        if (_transportSystemContext.Users.Any(user => user.Username == name))
            throw new Exception("User with this name already exists");
        var user = new User {
            Username = name,
            Password = password,
            Role = role
        };
        _transportSystemContext.Users.Add(user);
        _transportSystemContext.SaveChanges();
        return user;
    }

}
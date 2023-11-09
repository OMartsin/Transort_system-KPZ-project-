using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;
using TransportSystem.Services;

namespace TransportSystem.Controllers; 

[ApiController]
[Route("[controller]")]
public class AuthorizationController 
{
    private IConfiguration _config;
    private readonly IAuthenticationService _authenticationService;

    public AuthorizationController(IConfiguration config,
        IAuthenticationService authenticationService)
    {
        _config = config;
        _authenticationService = authenticationService;
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password) {
        string token;
        try {
            token = _authenticationService.AuthenticateUser(username, password);
        }
        catch (AuthenticationException e) {
            return new UnauthorizedObjectResult(new {message = e.Message});
        }
        if (!string.IsNullOrEmpty(token)) {
            return new OkObjectResult(new { token = token });
        }
        return new UnauthorizedResult();
    }
}
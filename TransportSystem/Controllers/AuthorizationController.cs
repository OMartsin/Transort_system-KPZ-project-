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
    private readonly IRegistrationService _registrationService;

    public AuthorizationController(IConfiguration config, IRegistrationService registrationService, 
        IAuthenticationService authenticationService)
    {
        _config = config;
        _authenticationService = authenticationService;
        _registrationService = registrationService;
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string username, string password) {
        string token;
        try {
            token = await _authenticationService.AuthenticateUserAsync(username, password);
        }
        catch (AuthenticationException e) {
            return new UnauthorizedObjectResult(new {message = e.Message});
        }
        if (!string.IsNullOrEmpty(token)) {
            return new OkObjectResult(new { token = token });
        }
        return new UnauthorizedResult();
    }
    
    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(string username, string password, string companyName, 
        string edrpou, string? ipn, string companyAddress, string? companyPhone, string account) {
        string token;
        try {
            token = await _registrationService.RegisterAgentAsync(username, password, companyName, edrpou, 
                ipn, companyAddress, companyPhone, account);
        }
        catch(AuthenticationException exception) {
            return new BadRequestObjectResult(new {message = exception.Message});
        }
        return new OkObjectResult(new {token = token});
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TransportSystem.Models;

namespace TransportSystem.Services; 

public class AuthenticationService : IAuthenticationService
{
    private readonly TransportSystemContext _context;

    public AuthenticationService(TransportSystemContext context)
    {
        _context = context;
    }

    public string AuthenticateUser(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == username 
                                                                  && u.Password == password);

        if (user != null)
        {
            return GenerateJsonWebToken(user);
        }
        throw new AuthenticationException("Invalid username or password.");
    }
    
    public string GetUserRole(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token);
        var tokenS = jsonToken as JwtSecurityToken;
        var role = tokenS?.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        if(role == null)
            throw new AuthenticationException("Invalid token.");
        return role;
    }

    private string GenerateJsonWebToken(User userInfo)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userInfo.Username),
            new Claim(ClaimTypes.Role, userInfo.Role) 
        };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));
            
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TransportSystem.Models;

namespace TransportSystem.Services; 

public class UserTokenGenerator: IUserTokenGenerator {
    public string GenerateToken(User user) {
        var claims = new List<Claim> {new Claim(ClaimTypes.Name, user.Username) };
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
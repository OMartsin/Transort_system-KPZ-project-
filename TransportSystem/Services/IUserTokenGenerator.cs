using TransportSystem.Models;

namespace TransportSystem.Services; 

public interface IUserTokenGenerator {
    string GenerateToken(User user);
}
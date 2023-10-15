namespace TransportSystem.Services; 

public interface IAuthenticationService {
    Task<string> AuthenticateUserAsync(string username, string password);
}
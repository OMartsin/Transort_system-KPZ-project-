namespace TransportSystem.Services; 

public interface IAuthenticationService {
    string AuthenticateUser(string username, string password);
}
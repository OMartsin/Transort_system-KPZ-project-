namespace TransportSystem.Services; 

public interface IRegistrationService {
    Task<string> RegisterAgentAsync(string username, string password, string companyName, 
        string edrpou, string? ipn, string companyAddress, string? companyPhone, string account);
}
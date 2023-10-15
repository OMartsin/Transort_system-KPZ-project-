using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using TransportSystem.Models;

namespace TransportSystem.Services; 

public class RegistrationService : IRegistrationService {
    private readonly TransportSystemContext _context;
    private readonly IUserTokenGenerator _tokenGenerator;

    public RegistrationService(TransportSystemContext context, IUserTokenGenerator tokenGenerator)
    {
        _context = context;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> RegisterAgentAsync(string username, string password, string companyName, 
        string edrpou, string? ipn, string companyAddress, string? companyPhone, string account)
    {
        var agent = new Agent
        {
            AgentName = companyName,
            AgentEdrpou = edrpou,
            AgentAddress = companyAddress,
            AgentPhone = companyPhone,
            AgentIpn = ipn,
            AgentAccount = account
        };

        if (await IsUserExistAsync(username))         
            throw new AuthenticationException("User with this username already exists.");

        if (await IsAgentExistAsync(agent))
            throw new AuthenticationException("Agent with this EDRPOU code already exists.");

        _context.Agents.Add(agent);
        await _context.SaveChangesAsync();

        var user = new User
        {
            Username = username,
            Password = password,
            Role = "agent",
            AgentId = agent.AgentId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var tokenString = _tokenGenerator.GenerateToken(user);

        return tokenString;
    }

    private async Task<bool> IsUserExistAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    private async Task<bool> IsAgentExistAsync(Agent agent)
    {
        return await _context.Agents.AnyAsync(a => a.AgentEdrpou == agent.AgentEdrpou);
    }
}
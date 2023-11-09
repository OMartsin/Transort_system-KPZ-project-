using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.AgentService; 

public interface IAgentService
{
    IEnumerable<Agent> GetAgents();
    Agent GetAgentById(int id);
    Agent AddAgent(AgentInputDto agent);
    void UpdateAgent(int id, Agent agent);
    void DeleteAgent(int id);
}

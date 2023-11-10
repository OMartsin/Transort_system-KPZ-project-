using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.AgentService; 

public interface IAgentService
{
    IEnumerable<AgentDto> GetAgents();
    AgentDto GetAgentById(int id);
    AgentDto AddAgent(AgentDto agent);
    AgentDto UpdateAgent(AgentDto agent);
    void DeleteAgent(int id);
}

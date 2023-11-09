using System;
using System.Collections.Generic;
using TransportSystem.DTO;
using TransportSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TransportSystem.Services.AgentService
{
    public class AgentService : IAgentService
    {
        private readonly TransportSystemContext _context;

        public AgentService(TransportSystemContext context)
        {
            _context = context;
        }

        public IEnumerable<Agent> GetAgents()
        {
            return _context.Agents.ToList();
        }

        public Agent GetAgentById(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                throw new Exception("Agent not found");
            }
            return agent;
        }

        public Agent AddAgent(AgentInputDto agentInputDto)
        {
            var user = new User
            {
                Username = agentInputDto.AgentName,
                Password = agentInputDto.AgentEdrpou,
                Role = "agent",
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var agent = new Agent()
            {
                AgentName = agentInputDto.AgentName,
                AgentEdrpou = agentInputDto.AgentEdrpou,
                AgentAddress = agentInputDto.AgentAddress,
                AgentAccount = agentInputDto.AgentAccount,
                AgentPhone = agentInputDto.AgentPhone,
                AgentEmail = agentInputDto.AgentEmail,
                AgentIpn = agentInputDto.AgentIpn,
                UserId = user.UserId
            };
            _context.Agents.Add(agent);
            _context.SaveChanges();
            return agent;
        }

        public void UpdateAgent(int id, Agent agent)
        {
            var existingAgent = _context.Agents.Find(id);
            if (existingAgent == null)
            {
                throw new Exception("Agent not found");
            }

            existingAgent.AgentName = agent.AgentName;
            existingAgent.AgentEdrpou = agent.AgentEdrpou;
            existingAgent.AgentAddress = agent.AgentAddress;
            existingAgent.AgentAccount = agent.AgentAccount;
            existingAgent.AgentPhone = agent.AgentPhone;
            existingAgent.AgentEmail = agent.AgentEmail;
            existingAgent.AgentIpn = agent.AgentIpn;

            _context.SaveChanges();
        }

        public void DeleteAgent(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                throw new Exception("Agent not found");
            }
            _context.Agents.Remove(agent);
            _context.SaveChanges();
        }
    }
}

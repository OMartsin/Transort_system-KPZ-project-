using System;
using System.Collections.Generic;
using AutoMapper;
using TransportSystem.DTO;
using TransportSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TransportSystem.Services.AgentService
{
    public class AgentService : IAgentService
    {
        private readonly TransportSystemContext _context;
        private readonly IMapper _mapper;

        public AgentService(TransportSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AgentDto> GetAgents()
        {
            return _mapper.Map<IEnumerable<AgentDto>>(_context.Agents.ToList());
        }

        public AgentDto GetAgentById(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null)
            {
                throw new Exception("Agent not found");
            }
            return _mapper.Map<AgentDto>(agent);
        }

        public AgentDto AddAgent(AgentDto agentInputDto)
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
            return _mapper.Map<AgentDto>(agent);
        }

        public AgentDto UpdateAgent(AgentDto agent)
        {
            var existingAgent = _context.Agents.Find(agent.AgentId);
            if (existingAgent == null) {
                throw new Exception("Agent not found");
            }
            
            _context.Entry(existingAgent).CurrentValues.SetValues(agent);

            _context.SaveChanges();
            return _mapper.Map<AgentDto>(existingAgent);
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

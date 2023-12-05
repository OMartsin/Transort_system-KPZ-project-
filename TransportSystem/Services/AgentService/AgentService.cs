using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using TransportSystem.DTO;
using TransportSystem.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

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
            using (var connection = new MySqlConnection("Server=" +
                                                        "localhost;Port=3306;Database=" +
                                                        "transport_system;User=root;Password=12345678;"
            ))
            {
                connection.Open();

                using (var command = new MySqlCommand("AddAgent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@p_AgentName", agentInputDto.AgentName);
                    command.Parameters.AddWithValue("@p_AgentEdrpou", agentInputDto.AgentEdrpou);
                    command.Parameters.AddWithValue("@p_AgentAddress", agentInputDto.AgentAddress);
                    command.Parameters.AddWithValue("@p_AgentAccount", agentInputDto.AgentAccount);
                    command.Parameters.AddWithValue("@p_AgentPhone", agentInputDto.AgentPhone);
                    command.Parameters.AddWithValue("@p_AgentEmail", agentInputDto.AgentEmail);
                    command.Parameters.AddWithValue("@p_AgentIpn", agentInputDto.AgentIpn);

                    command.ExecuteNonQuery();
                }
            }

            return agentInputDto;
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

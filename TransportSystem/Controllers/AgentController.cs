using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Models;
using TransportSystem.Services.AgentService;
using System;
using System.Collections.Generic;

namespace TransportSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet(Name = "GetAgents")]
        public IEnumerable<AgentDto> GetAgents()
        {
            return _agentService.GetAgents();
        }

        [HttpGet("{id}", Name = "GetAgent")]
        public ActionResult<AgentDto> GetAgent(int id)
        {
            try
            {
                var agent = _agentService.GetAgentById(id);
                return Ok(agent);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost(Name = "AddAgent")]
        public ActionResult<AgentDto> AddAgent([FromBody] AgentDto agent)
        {
            try
            {
                var addedAgent = _agentService.AddAgent(agent);
                return CreatedAtAction("GetAgent", new { id = addedAgent.AgentId }, addedAgent);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}", Name = "UpdateAgent")]
        public ActionResult<AgentDto> UpdateAgent([FromBody] AgentDto agent)
        {
            try
            {
                var newAgent = _agentService.UpdateAgent(agent);
                return Ok(newAgent);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("{id}", Name = "DeleteAgent")]
        public IActionResult DeleteAgent(int id)
        {
            try
            {
                _agentService.DeleteAgent(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

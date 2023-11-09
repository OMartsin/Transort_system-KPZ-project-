using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class Agent
{
    public int AgentId { get; set; }

    public string AgentName { get; set; } = null!;

    public string AgentEdrpou { get; set; } = null!;
    
    public string AgentAddress { get; set; } = null!;
    
    public string AgentAccount { get; set; } = null!;
    
    public string? AgentPhone { get; set; }
    
    public string? AgentEmail { get; set; }

    public string? AgentIpn { get; set; }
    
    public int UserId { get; set; }
    
    public virtual User User { get; set; } = null!;

    public virtual ICollection<Accounting> Accounting { get; set; } = new List<Accounting>();

    public virtual ICollection<TransportInsurance> TransportInsurances { get; set; } = new List<TransportInsurance>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}

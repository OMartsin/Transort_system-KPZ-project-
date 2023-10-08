using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Agent
{
    public int AgentId { get; set; }

    public string AgentName { get; set; } = null!;

    public string AgentEdrpou { get; set; } = null!;

    public string? AgentIpn { get; set; }

    public virtual ICollection<Accounting> Accounting { get; set; } = new List<Accounting>();

    public virtual ICollection<TransportInsurance> TransportInsurances { get; set; } = new List<TransportInsurance>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

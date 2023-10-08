using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? AgentId { get; set; }

    public int? DriverId { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual Driver? Driver { get; set; }
}

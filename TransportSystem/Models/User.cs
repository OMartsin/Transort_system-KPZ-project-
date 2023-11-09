using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
    
    public virtual Agent Agent { get; set; } = null!;
    
    public virtual Driver Driver { get; set; } = null!;
}

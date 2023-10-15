using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class Cargo
{
    public int CargoId { get; set; }

    public string CargoName { get; set; } = null!;

    public int CargoWeight { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}

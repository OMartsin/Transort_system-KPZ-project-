using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Trailer
{
    public int TrailerId { get; set; }

    public string TrailerNumberPlate { get; set; } = null!;

    public string TrailerVendor { get; set; } = null!;

    public string TrailerModel { get; set; } = null!;

    public int TrailerWeight { get; set; }

    public int TrailerCapacity { get; set; }

    public string? TrailerTyresType { get; set; }

    public string TrailerType { get; set; } = null!;

    public virtual ICollection<Transportinsurance> Transportinsurances { get; set; } = new List<Transportinsurance>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}

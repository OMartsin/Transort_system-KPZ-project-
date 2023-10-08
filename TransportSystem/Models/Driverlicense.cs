using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Driverlicense
{
    public int LicenseId { get; set; }

    public int? DriverId { get; set; }

    public string? LicenseNumber { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<Licensecategory> Categories { get; set; } = new List<Licensecategory>();
}

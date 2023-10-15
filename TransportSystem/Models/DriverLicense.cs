using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class DriverLicense
{
    public int LicenseId { get; set; }

    public int? DriverId { get; set; }

    public string? LicenseNumber { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<LicenseCategory> Categories { get; set; } = new List<LicenseCategory>();
}

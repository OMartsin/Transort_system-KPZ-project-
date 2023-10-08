using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LicenseCategory
{
    public int CategoryId { get; set; }

    public string? CategoryCode { get; set; }
    
    public string? CategoryDescription { get; set; }

    public virtual ICollection<DriverLicense> Licenses { get; set; } = new List<DriverLicense>();
}

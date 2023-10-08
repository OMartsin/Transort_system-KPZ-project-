using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Licensecategory
{
    public int CategoryId { get; set; }

    public string? CategoryCode { get; set; }
    
    public string? CategoryDescription { get; set; }

    public virtual ICollection<Driverlicense> Licenses { get; set; } = new List<Driverlicense>();
}

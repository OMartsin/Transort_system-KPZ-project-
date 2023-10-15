using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class TransportInsurance
{
    public int TransportInsuranceId { get; set; }

    public int? InsuranceTruckId { get; set; }

    public int? InsuranceTrailerId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? PolicyNumber { get; set; }

    public int InsuranceAgentId { get; set; }

    public virtual Agent InsuranceAgent { get; set; } = null!;

    public virtual Trailer? InsuranceTrailer { get; set; }

    public virtual Truck? InsuranceTruck { get; set; }
}

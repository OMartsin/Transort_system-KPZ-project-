using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public int TripDriver1Id { get; set; }

    public int TripDriver2Id { get; set; }

    public int TripTruckId { get; set; }

    public int TripTrailerId { get; set; }

    public int TripCargoId { get; set; }

    public int TripAgentId { get; set; }

    public int TripTotal { get; set; }

    public DateOnly? TripDeparture { get; set; }

    public DateOnly? TripCompletion { get; set; }

    public virtual ICollection<Deliverylog> Deliverylogs { get; set; } = new List<Deliverylog>();

    public virtual Agent TripAgent { get; set; } = null!;

    public virtual Cargo TripCargo { get; set; } = null!;

    public virtual Driver TripDriver1 { get; set; } = null!;

    public virtual Driver TripDriver2 { get; set; } = null!;

    public virtual Trailer TripTrailer { get; set; } = null!;

    public virtual Truck TripTruck { get; set; } = null!;
}

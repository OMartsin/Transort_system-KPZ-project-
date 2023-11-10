using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class Trip
{
    public int TripId { get; set; }
    
    public string TripName { get; set; } = null!;

    public int TripTruckId { get; set; }

    public int TripTrailerId { get; set; }

    public string TripCargoName { get; set; }

    public int TripAgentId { get; set; }

    public int TripTotal { get; set; }

    public DateOnly? TripDeparture { get; set; }

    public DateOnly? TripCompletion { get; set; }

    public virtual ICollection<DeliveryLog> DeliveryLog { get; set; } = new List<DeliveryLog>();

    public virtual Agent TripAgent { get; set; } = null!;

    public virtual ICollection<Driver> TripDrivers { get; set; } = null!;

    public virtual Trailer TripTrailer { get; set; } = null!;

    public virtual Truck TripTruck { get; set; } = null!;
}

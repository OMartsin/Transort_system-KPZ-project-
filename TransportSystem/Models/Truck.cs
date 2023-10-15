using System;
using System.Collections.Generic;

namespace TransportSystem.Models;

public partial class Truck
{
    public int TruckId { get; set; }

    public string TruckNumberPlate { get; set; } = null!;

    public string TruckFuelType { get; set; } = null!;

    public string TruckVendor { get; set; } = null!;

    public string TruckModel { get; set; } = null!;

    public int? TruckEcoStandartEuro { get; set; }

    public int TruckWeight { get; set; }

    public string? TruckFrontTyresType { get; set; }

    public string? TruckRearTyperType { get; set; }

    public virtual ICollection<TransportInsurance> TransportInsurances { get; set; } = new List<TransportInsurance>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}

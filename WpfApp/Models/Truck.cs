using System.Collections.Generic;
using TransportSystem.Models;

namespace WpfApp.Models; 

public class Truck {
    public int TruckId { get; set; }
    public string TruckNumberPlate { get; set; }
    public string TruckFuelType { get; set; }
    public string TruckVendor { get; set; }
    public string TruckModel { get; set; }
    public int? TruckEcoStandartEuro { get; set; }
    public int TruckWeight { get; set; }
    public string TruckFrontTyresType { get; set; }
    public string TruckRearTyresType { get; set; }
}
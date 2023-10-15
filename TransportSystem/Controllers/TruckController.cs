using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;

namespace TransportSystem.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = "AdminOnly")]
public class TruckController {
    private TransportSystemContext _transportSystemContext;

    public TruckController(TransportSystemContext transportSystemContext) {
        _transportSystemContext = transportSystemContext;
    }

    [HttpGet("{id}", Name = "GetTruck")]

    public Truck GetTruck(int id)
    {
        var truck = _transportSystemContext.Trucks.Find(id);
        return truck;
    }
    
    [HttpGet(Name = "GetTrucks")]
    public IEnumerable<Truck> GetTrucks() {
        var trucks = _transportSystemContext.Trucks.ToList();
        return trucks;
    }

    [HttpPost(Name = "AddTruck")]
    public Truck AddTruck(string numberPlate, string fuelType, string vendor, 
        string model, int weight, string frontTyresType, string rearTyresType) {
        var truck = new Truck {
            TruckNumberPlate = numberPlate,
            TruckFuelType = fuelType,
            TruckVendor = vendor,
            TruckModel = model,
            TruckWeight = weight,
            TruckFrontTyresType = frontTyresType,
            TruckRearTyperType = rearTyresType
        };
        _transportSystemContext.Trucks.Add(truck);
        _transportSystemContext.SaveChanges();
        return truck;
    }

    [HttpDelete(Name = "DeleteTruck")]
    public void DeleteTruck(int id) {
        var truck = _transportSystemContext.Trucks.Find(id);
        _transportSystemContext.Trucks.Remove(truck);
        _transportSystemContext.SaveChanges();
    }
    
    [HttpPut(Name = "UpdateTruck")]
    public Truck UpdateTruck(int id, string numberPlate, string fuelType, string vendor, 
        string model, int weight, string frontTyresType, string rearTyresType) {
        var truck = _transportSystemContext.Trucks.Find(id);
        truck.TruckNumberPlate = numberPlate;
        truck.TruckFuelType = fuelType;
        truck.TruckVendor = vendor;
        truck.TruckModel = model;
        truck.TruckWeight = weight;
        truck.TruckFrontTyresType = frontTyresType;
        truck.TruckRearTyperType = rearTyresType;
        _transportSystemContext.SaveChanges();
        return truck;
    }
}
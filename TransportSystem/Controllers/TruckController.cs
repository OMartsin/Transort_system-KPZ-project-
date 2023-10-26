using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;
using TransportSystem.Services;

namespace TransportSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class TruckController {
    private ITruckService _truckService;

    public TruckController(ITruckService truckService) {
        _truckService = truckService;
    }

    [Authorize]
    [HttpGet("{id}", Name = "GetTruck")]
    public Truck GetTruck(int id)
    {
        return _truckService.GetTruck(id);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpGet(Name = "GetTrucks")]
    public IEnumerable<Truck> GetTrucks() {
        return _truckService.GetTrucks();
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost(Name = "AddTruck")]
    public Truck AddTruck([FromBody] Truck truck) {
        return _truckService.AddTruck(truck);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpDelete(Name = "DeleteTruck")]
    public void DeleteTruck(int id) {
        _truckService.DeleteTruck(id);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpPut(Name = "UpdateTruck")]
    public Truck UpdateTruck([FromBody] Truck truck, int id) {
        return _truckService.UpdateTruck(id, truck);
    }
}
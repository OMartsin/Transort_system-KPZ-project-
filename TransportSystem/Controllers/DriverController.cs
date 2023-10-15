using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;
using TransportSystem.Services.DriverService;

namespace TransportSystem.Controllers; 

[ApiController]
[Route("[controller]")]
[Authorize(Policy = "AdminOnly")]
public class DriverController {
    
    private IDriverService _driverService;

    public DriverController(IDriverService driverService) {
        _driverService = driverService;
    }

    [HttpGet("{id}", Name = "GetDriver")]
    public Driver GetDriver(int id) {
        return _driverService.GetDriver(id);
    }
    
    [HttpGet(Name = "GetDrivers")]
    public IEnumerable<Driver> GetDrivers() {
        return _driverService.GetDrivers();
    }   
    
    [HttpPost(Name = "AddDriver")]
    public Driver AddDriver([FromBody] Driver driver) {
        return _driverService.AddDriver(driver);
    }
    
    [HttpPut(Name = "UpdateDriver")]
    public Driver UpdateDriver(int id, [FromBody] Driver driver) {
        return _driverService.UpdateDriver(id, driver);
    }
    
    [HttpDelete(Name = "DeleteDriver")]
    public void DeleteDriver(int id) {
        _driverService.DeleteDriver(id);
    }
}
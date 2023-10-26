using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Models;
using TransportSystem.Services.DriverService;

namespace TransportSystem.Controllers; 

[ApiController]
[Route("[controller]/")]
public class DriverController {
    
    private IDriverService _driverService;

    public DriverController(IDriverService driverService) {
        _driverService = driverService;
    }
    
    [Authorize]
    [HttpGet("{id}", Name = "GetDriver")]
    public Driver GetDriver(int id) {
        return _driverService.GetDriver(id);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpGet(Name = "GetDrivers")]
    public IEnumerable<Driver> GetDrivers() {
        return _driverService.GetDrivers();
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost(Name = "AddDriver")]
    public Driver AddDriver([FromBody] Driver driver) {
        return _driverService.AddDriver(driver);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPut(Name = "UpdateDriver")]
    public Driver UpdateDriver(int id, [FromBody] Driver driver) {
        return _driverService.UpdateDriver(id, driver);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpPost("{driverId}/licenses", Name = "AddDriverLicense")]
    public ActionResult<DriverLicense> AddDriverLicense(int driverId, [FromBody] DriverLicense driverLicense)
    {
        try
        {
            var addedLicense = _driverService.AddDriverLicense(driverId, driverLicense);
            return new OkObjectResult(addedLicense);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { message = ex.Message });
        }
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpPut("{driverId}/licenses/{licenseId}", Name = "UpdateDriverLicense")]
    public ActionResult<Driver> UpdateDriverLicense(int driverId,int licenseId,
        [FromBody] DriverLicense driverLicense)
    {
        try 
        {
            driverLicense.DriverId = driverId;
            driverLicense.LicenseId = licenseId;
            var updatedLicense = _driverService.UpdateDriverLicense(driverId, driverLicense);
            return new OkObjectResult(updatedLicense);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { message = ex.Message });
        }
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpPost("{driverId}/contracts", Name = "AddDriverContract")]
    public ActionResult<DriverContract> AddDriverContract(int driverId,
        [FromBody] DriverContractDTO driverContractDto)
    {
        try
        {
            var driver = _driverService.GetDriver(driverId);
            
            var driverContract = new DriverContract
            {
                ContractNumber = driverContractDto.ContractNumber,
                ContractIssueDate = driverContractDto.ContractIssueDate,
                ContractExpiryDate = driverContractDto.ContractExpiryDate,
                ContractDriver = driver
            };

            var addedContract = _driverService.AddDriverContract(driverId, driverContract);
            return new OkObjectResult(addedContract);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { message = ex.Message });
        }
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPut("{driverId}/contracts/{contractId}", Name = "UpdateDriverContract")]
    public ActionResult<DriverContract> UpdateDriverContract(int driverId, [FromBody] DriverContract driverContract)
    {
        try
        {
            var updatedContract = _driverService.UpdateDriverContract(driverId, driverContract);
            return new OkObjectResult(updatedContract);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { message = ex.Message });
        }
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{id}")]
    public void DeleteDriver(int id) {
        _driverService.DeleteDriver(id);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{driverId}/licenses/{licenseId}")]
    public void DeleteDriverLicense(int driverId, int licenseId) {
        _driverService.DeleteDriverLicense(driverId, licenseId);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{driverId}/contracts/{contractId}")]
    public void DeleteDriverContract(int driverId, int contractId) {
        _driverService.DeleteDriverContract(driverId, contractId);
    }
    
}
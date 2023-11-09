using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Models;
using TransportSystem.Services.DriverService;

namespace TransportSystem.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetDriver")]
        public ActionResult<Driver> GetDriver(int id)
        {
            try
            {
                var driver = _driverService.GetDriver(id);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet(Name = "GetDrivers")]
        public ActionResult<IEnumerable<Driver>> GetDrivers()
        {
            try
            {
                var drivers = _driverService.GetDrivers();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost(Name = "AddDriver")]
        public ActionResult<Driver> AddDriver([FromBody] Driver driver)
        {
            try
            {
                var addedDriver = _driverService.AddDriver(driver);
                return Ok(addedDriver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}", Name = "UpdateDriver")]
        public ActionResult<Driver> UpdateDriver(int id, [FromBody] Driver driver)
        {
            try
            {
                var updatedDriver = _driverService.UpdateDriver(driver);
                return Ok(updatedDriver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("{driverId}/licenses", Name = "AddDriverLicense")]
        public ActionResult<DriverLicense> AddDriverLicense(int driverId, 
            [FromBody] DriverLicense driverLicense)
        {
            try
            {
                var addedLicense = _driverService.AddDriverLicense(driverId, driverLicense);
                return Ok(addedLicense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{driverId}/licenses/{licenseId}", Name = "UpdateDriverLicense")]
        public ActionResult<DriverLicense> UpdateDriverLicense(int driverId, int licenseId, 
            [FromBody] DriverLicense driverLicense)
        {
            try
            {
                driverLicense.LicenseId = licenseId;
                var updatedLicense = _driverService.UpdateDriverLicense(driverId, driverLicense);
                return Ok(updatedLicense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("{driverId}/contracts", Name = "AddDriverContract")]
        public ActionResult<DriverContract> AddDriverContract(int driverId, 
            [FromBody] DriverContractDTO driverContractDto)
        {
            try
            {
                var addedContract = _driverService.AddDriverContract(driverId, driverContractDto);
                return Ok(addedContract);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{driverId}/contracts/{contractId}", Name = "UpdateDriverContract")]
        public ActionResult<DriverContract> UpdateDriverContract(int driverId, int contractId, 
            [FromBody] DriverContract driverContract)
        {
            try
            {
                driverContract.ContractId = contractId;
                var updatedContract = _driverService.UpdateDriverContract(driverId, driverContract);
                return Ok(updatedContract);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            try
            {
                _driverService.DeleteDriver(id);
                return Ok(new { message = "Driver deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{driverId}/licenses/{licenseId}")]
        public IActionResult DeleteDriverLicense(int driverId, int licenseId)
        {
            try
            {
                _driverService.DeleteDriverLicense(driverId, licenseId);
                return Ok(new { message = "Driver license deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{driverId}/contracts/{contractId}")]
        public IActionResult DeleteDriverContract(int driverId, int contractId)
        {
            try
            {
                _driverService.DeleteDriverContract(driverId, contractId);
                return Ok(new { message = "Driver contract deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

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
        public ActionResult<DriverDto> GetDriver(int id)
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
        public ActionResult<IEnumerable<DriverDto>> GetDrivers()
        {
            try
            {
                var drivers = _driverService.GetDrivers();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost(Name = "AddDriver")]
        public ActionResult<DriverDto> AddDriver([FromBody] DriverDto driver)
        {
            try
            {
                var addedDriver = _driverService.AddDriver(driver);
                return Ok(addedDriver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}", Name = "UpdateDriver")]
        public ActionResult<DriverDto> UpdateDriver([FromBody] DriverDto driver)
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
        [HttpPost("licenses", Name = "AddDriverLicense")]
        public ActionResult<DriverDto> AddDriverLicense(
            [FromBody] DriverLicenseDto driverLicense)
        {
            try
            {
                var addedLicense = _driverService.AddDriverLicense(driverLicense);
                return Ok(addedLicense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("licenses/", Name = "UpdateDriverLicense")]
        public ActionResult<DriverLicenseDto> UpdateDriverLicense(
            [FromBody] DriverLicenseDto driverLicense)
        {
            try
            {
                var updatedLicense = _driverService.UpdateDriverLicense(driverLicense);
                return Ok(updatedLicense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("contracts/", Name = "AddDriverContract")]
        public ActionResult<DriverContractDto> AddDriverContract(
            [FromBody] DriverContractDto driverContractDto)
        {
            try
            {
                var addedContract = _driverService.AddDriverContract(driverContractDto);
                return Ok(addedContract);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("contracts/", Name = "UpdateDriverContract")]
        public ActionResult<DriverContractDto> UpdateDriverContract(
            [FromBody] DriverContractDto driverContract)
        {
            try
            {
                var updatedContract = _driverService.UpdateDriverContract(driverContract);
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
        [HttpDelete("licenses/")]
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
        [HttpDelete("contracts/")]
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

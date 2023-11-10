using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.DriverService; 

public interface IDriverService
{
    IEnumerable<DriverDto> GetDrivers();
    DriverDto GetDriver(int id);
    DriverDto AddDriver(DriverDto driver);
    DriverLicenseDto AddDriverLicense(DriverLicenseDto driverLicense);
    DriverContractDto AddDriverContract(DriverContractDto driverContract);
    DriverDto UpdateDriver(DriverDto driver);
    DriverLicenseDto UpdateDriverLicense( DriverLicenseDto driverLicense);
    DriverContractDto UpdateDriverContract(DriverContractDto driverContract);
    void DeleteDriver(int id);
    void DeleteDriverLicense(int driverId, int licenseId);
    void DeleteDriverContract(int driverId, int contractId);
}
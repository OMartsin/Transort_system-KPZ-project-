using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.DriverService; 

public interface IDriverService
{
    IEnumerable<Driver> GetDrivers();
    IEnumerable<DriverDto> GetDriversDto();
    Driver GetDriver(int id);
    Driver AddDriver(Driver driver);
    DriverLicense AddDriverLicense(int driverId, DriverLicense driverLicense);
    DriverContract AddDriverContract(int driverId, DriverContractDTO driverContract);
    Driver UpdateDriver(Driver driver);
    DriverLicense UpdateDriverLicense(int driverId, DriverLicense driverLicense);
    DriverContract UpdateDriverContract(int driverId, DriverContract driverContract);
    void DeleteDriver(int id);
    void DeleteDriverLicense(int driverId, int licenseId);
    void DeleteDriverContract(int driverId, int contractId);
}
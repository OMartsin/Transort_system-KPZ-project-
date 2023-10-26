using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.DriverService; 

public interface IDriverService {
    public IEnumerable<Driver> GetDrivers();
    public Driver GetDriver(int id);
    public Driver AddDriver(Driver driver);
    public DriverLicense AddDriverLicense(int driverId, DriverLicense driverLicense);  
    public DriverContract AddDriverContract(int driverId, DriverContract driverContract);
    public Driver UpdateDriver(int id, Driver driver);
    public Driver UpdateDriverLicense(int driverId, DriverLicense driverLicense);
    public Driver UpdateDriverContract(int driverId, DriverContract driverContract);
    public void DeleteDriver(int id);
    public void DeleteDriverLicense(int driverId, int licenseId);
    public void DeleteDriverContract(int driverId, int contractId);
    public IEnumerable<DriverDto> GetDriversDto();
}
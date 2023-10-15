using TransportSystem.Models;

namespace TransportSystem.Services.DriverService; 

public interface IDriverService {
    public IEnumerable<Driver> GetDrivers();
    public Driver GetDriver(int id);
    public Driver AddDriver(Driver driver);
    public Driver UpdateDriver(int id, Driver driver);
    public void DeleteDriver(int id);
}
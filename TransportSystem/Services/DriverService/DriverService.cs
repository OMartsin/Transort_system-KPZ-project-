using TransportSystem.Models;

namespace TransportSystem.Services.DriverService; 

public class DriverService : IDriverService {
    private TransportSystemContext _transportSystemContext;

    public DriverService(TransportSystemContext transportSystemContext) {
        _transportSystemContext = transportSystemContext;
    }

    public IEnumerable<Driver> GetDrivers() {
        var drivers = _transportSystemContext.Drivers.ToList();
        return drivers;
    }

    public Driver GetDriver(int id) {
        var driver = _transportSystemContext.Drivers.Find(id);
        if(driver is null) throw new Exception("Driver not found");
        return driver;
    }

    public Driver AddDriver(Driver driver) {
        if (_transportSystemContext.Drivers.Any
                (d => d.DriverIndividualTaxNumber == driver.DriverIndividualTaxNumber)) {
            throw new Exception("Driver with this individual tax number already exists");
        }
        _transportSystemContext.Drivers.Add(driver);
        _transportSystemContext.Users.Add(new User {
            Username = driver.DriverName.ToLower() + "_" + driver.DriverSurname.ToLower() ,
            Password = driver.DriverBirthday.ToString("ddMMyyyy"),
            Role = "driver",
            DriverId = _transportSystemContext.Drivers.ToList().Last().DriverId
        });
        _transportSystemContext.SaveChanges();
        return driver;
    }

    public Driver UpdateDriver(int id, Driver driver) {
        _transportSystemContext.Drivers.Update(driver);
        _transportSystemContext.SaveChanges();
        return driver;
    }

    public void DeleteDriver(int id) {
        var driver = _transportSystemContext.Drivers.Find(id);
        if(driver is null) throw new Exception("Driver not found");
        _transportSystemContext.Drivers.Remove(driver);
        _transportSystemContext.SaveChanges();
    }
}
using Microsoft.EntityFrameworkCore;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.DriverService
{
        public class DriverService : IDriverService
    {
        private readonly TransportSystemContext _transportSystemContext;

        public DriverService(TransportSystemContext transportSystemContext)
        {
            _transportSystemContext = transportSystemContext;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _transportSystemContext.Drivers.ToList();
        }

        public IEnumerable<DriverDto> GetDriversDto()
        {
            var drivers = _transportSystemContext.Drivers.ToList();
            var driversDto = drivers.Select(driver => new DriverDto(driver)).ToList();
            return driversDto;
        }

        public Driver GetDriver(int id)
        {
            var driver = _transportSystemContext.Drivers.Find(id);
            if (driver == null) throw new Exception("Driver not found");
            return driver;
        }

        public Driver AddDriver(Driver driver)
        {
            if (_transportSystemContext.Drivers.Any(d => d.DriverIndividualTaxNumber == driver.DriverIndividualTaxNumber))
            {
                throw new Exception("Driver with this individual tax number already exists");
            }

            _transportSystemContext.Drivers.Add(driver);
            _transportSystemContext.Users.Add(new User
            {
                Username = driver.DriverName.ToLower() + "_" + driver.DriverSurname.ToLower(),
                Password = driver.DriverBirthday.ToString("ddMMyyyy"),
                Role = "driver",
            });
            _transportSystemContext.SaveChanges();
            driver.UserId = _transportSystemContext.Users.Last().UserId;
            _transportSystemContext.Drivers.Update(driver);
            _transportSystemContext.SaveChanges();
            return driver;
        }

        public DriverLicense AddDriverLicense(int driverId, DriverLicense driverLicense)
        {
            var driver = _transportSystemContext.Drivers.Find(driverId);
            if (driver == null) throw new Exception("Driver not found");

            driverLicense.DriverId = driverId;
            _transportSystemContext.DriverLicenses.Add(driverLicense);
            _transportSystemContext.SaveChanges();
            return driverLicense;
        }

        public DriverContract AddDriverContract(int driverId, DriverContractDTO driverContract)
        {
            var driver = _transportSystemContext.Drivers.Find(driverId);
            if (driver == null) throw new Exception("Driver not found");
            var addDriverContract = new DriverContract
            {
                ContractNumber = driverContract.ContractNumber,
                ContractIssueDate = driverContract.ContractIssueDate,
                ContractExpiryDate = driverContract.ContractExpiryDate,
                ContractDriverId = driverId
            };
            _transportSystemContext.DriverContracts.Add(addDriverContract);
            _transportSystemContext.SaveChanges();
            return addDriverContract;
        }

        public Driver UpdateDriver(Driver driver)
        {
            var editDriver = _transportSystemContext.Drivers.Find(driver.DriverId);
            if (editDriver == null) throw new Exception("Driver not found");
            editDriver.DriverName = driver.DriverName;
            editDriver.DriverSurname = driver.DriverSurname;
            editDriver.DriverBirthday = driver.DriverBirthday;
            editDriver.DriverIndividualTaxNumber = driver.DriverIndividualTaxNumber;
            _transportSystemContext.Drivers.Update(editDriver);
            _transportSystemContext.SaveChanges();
            return driver;
        }

        public DriverLicense UpdateDriverLicense(int driverId, DriverLicense driverLicense)
        {
            var editDriverLicense = _transportSystemContext.DriverLicenses
                .SingleOrDefault(dl => dl.DriverId == driverId && dl.LicenseId == driverLicense.LicenseId);
            if (editDriverLicense == null) throw new Exception("Driver license not found");
            editDriverLicense.LicenseId = driverLicense.LicenseId;
            editDriverLicense.LicenseNumber = driverLicense.LicenseNumber;
            editDriverLicense.ExpirationDate = driverLicense.ExpirationDate;
            _transportSystemContext.DriverLicenses.Update(editDriverLicense);
            _transportSystemContext.SaveChanges();
            return driverLicense;
        }

        public DriverContract UpdateDriverContract(int driverId, DriverContract driverContract)
        {
            var editDriverContract = _transportSystemContext.DriverContracts
                .SingleOrDefault(dc => dc.ContractDriverId == driverId && dc.ContractId == driverContract.ContractId);
            if (editDriverContract == null) throw new Exception("Driver contract not found");
            editDriverContract.ContractId = driverContract.ContractId;
            editDriverContract.ContractNumber = driverContract.ContractNumber;
            editDriverContract.ContractIssueDate = driverContract.ContractIssueDate;
            editDriverContract.ContractExpiryDate = driverContract.ContractExpiryDate;
            _transportSystemContext.DriverContracts.Update(editDriverContract);
            _transportSystemContext.SaveChanges();
            return driverContract;
        }

        public void DeleteDriver(int id)
        {
            var driver = _transportSystemContext.Drivers.Find(id);
            if (driver == null) throw new Exception("Driver not found");
            _transportSystemContext.Drivers.Remove(driver);
            _transportSystemContext.SaveChanges();
        }

        public void DeleteDriverLicense(int driverId, int licenseId)
        {
            var driverLicense = _transportSystemContext.DriverLicenses
                .SingleOrDefault(dl => dl.DriverId == driverId && dl.LicenseId == licenseId);
            if (driverLicense == null) throw new Exception("Driver license not found");
            _transportSystemContext.DriverLicenses.Remove(driverLicense);
            _transportSystemContext.SaveChanges();
        }

        public void DeleteDriverContract(int driverId, int contractId)
        {
            var driverContract = _transportSystemContext.DriverContracts
                .SingleOrDefault(dc => dc.ContractDriverId == driverId && dc.ContractId == contractId);
            if (driverContract == null) throw new Exception("Driver contract not found");
            _transportSystemContext.DriverContracts.Remove(driverContract);
            _transportSystemContext.SaveChanges();
        }
    }
}
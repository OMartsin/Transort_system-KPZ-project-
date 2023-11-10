using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.DriverService
{
        public class DriverService : IDriverService
    {
        private readonly TransportSystemContext _transportSystemContext;
        private readonly IMapper _mapper;

        public DriverService(TransportSystemContext transportSystemContext, IMapper mapper)
        {
            _transportSystemContext = transportSystemContext;
            _mapper = mapper;
        }

        public IEnumerable<DriverDto> GetDrivers()
        {
            return _mapper.Map<IEnumerable<DriverDto>>(_transportSystemContext.Drivers.ToList());
        }
        
        public DriverDto GetDriver(int id)
        {
            var driver = _transportSystemContext.Drivers.Find(id);
            if (driver == null) throw new Exception("Driver not found");
            return _mapper.Map<DriverDto>(driver);
        }

        public DriverDto AddDriver(DriverDto driverDto)
        {
            if (_transportSystemContext.Drivers.Any(d => d.DriverIndividualTaxNumber 
                                                         == driverDto.DriverIndividualTaxNumber))
            {
                throw new Exception("Driver with this individual tax number already exists");
            }

            var user = new User {
                Username = driverDto.DriverName.ToLower() + "_" + driverDto.DriverSurname.ToLower(),
                Password = driverDto.DriverBirthday.ToString("ddMMyyyy"),
                Role = "driver",
            };
            _transportSystemContext.Users.Add(user);
            _transportSystemContext.SaveChanges();
            var driver = _mapper.Map<Driver>(driverDto);
            driver.UserId = user.UserId;
            _transportSystemContext.Drivers.Add(driver);
            _transportSystemContext.SaveChanges();
            return _mapper.Map<DriverDto>(driver);
        }

        public DriverLicenseDto AddDriverLicense(DriverLicenseDto driverLicenseDto)
        {
            var driver = _transportSystemContext.Drivers.Find(driverLicenseDto.DriverId);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }

            var license = _mapper.Map<DriverLicense>(driverLicenseDto);

            foreach (var existingCategoryDto in driverLicenseDto.Categories)
            {
                var category = _transportSystemContext.LicenseCategories
                    .SingleOrDefault(lc => lc.CategoryId == existingCategoryDto.CategoryId);

                if (category == null)
                {
                    throw new Exception("Category not found");
                }

                var mappedCategory = _mapper.Map<LicenseCategory>(category);
                license.Categories.Add(mappedCategory);
            }

            _transportSystemContext.DriverLicenses.Add(license);
            _transportSystemContext.SaveChanges();

            return _mapper.Map<DriverLicenseDto>(license);
        }




        public DriverContractDto AddDriverContract(DriverContractDto driverContract)
        {
            var driver = _transportSystemContext.Drivers.Find(driverContract.ContractDriverId);
            if (driver == null) throw new Exception("Driver not found");
            var contract = _mapper.Map<DriverContract>(driverContract);
            _transportSystemContext.DriverContracts.Add(contract);
            _transportSystemContext.SaveChanges();
            return _mapper.Map<DriverContractDto>(contract);
        }

        public DriverDto UpdateDriver(DriverDto driver)
        {
            var editDriver = _transportSystemContext.Drivers.Find(driver.DriverId);
            if (editDriver == null) throw new Exception("Driver not found");
            _transportSystemContext.Entry(editDriver).CurrentValues.SetValues(
                _mapper.Map<Driver>(driver));
            _transportSystemContext.SaveChanges();
            return _mapper.Map<DriverDto>(editDriver);
        }

        public DriverLicenseDto UpdateDriverLicense(DriverLicenseDto driverLicense)
        {
            var editDriverLicense = _transportSystemContext.DriverLicenses
                .SingleOrDefault(dl => dl.DriverId == driverLicense.DriverId
                                       && dl.LicenseId == driverLicense.LicenseId);
            if (editDriverLicense == null) throw new Exception("Driver license not found");
            _transportSystemContext.Entry(editDriverLicense).CurrentValues.SetValues(
                _mapper.Map<DriverLicense>(driverLicense));
            _transportSystemContext.SaveChanges();
            return _mapper.Map<DriverLicenseDto>(editDriverLicense);
        }

        public DriverContractDto UpdateDriverContract(DriverContractDto driverContract)
        {
            var editDriverContract = _transportSystemContext.DriverContracts
                .SingleOrDefault(dc => dc.ContractDriverId == driverContract.ContractDriverId
                                       && dc.ContractId == driverContract.ContractId);
            if (editDriverContract == null) throw new Exception("Driver contract not found");
            _transportSystemContext.Entry(editDriverContract).CurrentValues.SetValues(
                _mapper.Map<DriverContract>(driverContract));
            _transportSystemContext.SaveChanges();
            return _mapper.Map<DriverContractDto>(editDriverContract);
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
using TransportSystem.Models;

namespace TransportSystem.DTO; 

public class DriverDto {
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public string DriverSurname { get; set; }
    public string? DriverPatronymic { get; set; }
    public string DriversPassportNumber { get; set; }
    public string DriverNationality { get; set; }
    public string DriverPhoneNumber { get; set; }
    public string DriverIndividualTaxNumber { get; set; }
    public DateOnly DriverBirthday { get; set; }
    public UserDto? User { get; set; }
    public IEnumerable<DriverContractDto> DriverContracts { get; set; } = new List<DriverContractDto>();
    public IEnumerable<DriverLicenseDto> DriverLicenses { get; set; } = new List<DriverLicenseDto>();
    public IEnumerable<TripDto> TripDriver { get; set; } = new List<TripDto>();
}
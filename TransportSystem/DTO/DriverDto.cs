using TransportSystem.Models;

namespace TransportSystem.DTO; 

public class DriverDto {
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public string DriverSurname { get; set; }
    public string? DriverPatronymic { get; set; }
    public int ExperienceYears { get; set; }
    
    public DriverDto(Driver driver) {
        DriverId = driver.DriverId;
        DriverName = driver.DriverName;
        DriverSurname = driver.DriverSurname;
        DriverPatronymic = driver.DriverPatronymic;
        ExperienceYears = driver.DriverContracts.Count;
    }
}
namespace TransportSystem.DTO; 

public class DriverLicenseDto {
    public int LicenseId { get; set; }
    public int? DriverId { get; set; }
    public string? LicenseNumber { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public IEnumerable<LicenceCategoryDto> Categories { get; set; } = new List<LicenceCategoryDto>();
}
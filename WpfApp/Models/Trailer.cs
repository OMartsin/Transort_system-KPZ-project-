namespace WpfApp.Models; 

public class Trailer {
    public int TrailerId { get; set; }
    public string TrailerNumberPlate { get; set; } = null!;
    public string TrailerVendor { get; set; } = null!;
    public string TrailerModel { get; set; } = null!;
    public int TrailerWeight { get; set; }
    public int TrailerCapacity { get; set; }
    public string? TrailerTyresType { get; set; }
    public string TrailerType { get; set; } = null!;
}
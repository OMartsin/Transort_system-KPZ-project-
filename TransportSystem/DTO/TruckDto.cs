namespace TransportSystem.DTO; 

public class TruckDto
{
    public int TruckId { get; set; }
    public string TruckNumberPlate { get; set; }
    public string TruckFuelType { get; set; }
    public string TruckVendor { get; set; }
    public string TruckModel { get; set; }
    public int? TruckEcoStandartEuro { get; set; }
    public int TruckWeight { get; set; }
    public string TruckFrontTyresType { get; set; }
    public string TruckRearTyperType { get; set; }
    public ICollection<TransportInsuranceDto> 
        TransportInsurances { get; set; } = new List<TransportInsuranceDto>();
}
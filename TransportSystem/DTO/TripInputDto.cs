namespace TransportSystem.DTO; 

public class TripInputDto {
    public string TripName { get; set; } = null!;
    public int TripTruckId { get; set; }
    public int TripTrailerId { get; set; }
    public int TripCargoName { get; set; }
    public int TripAgentId { get; set; }
    public int TripTotal { get; set; }
    public DateOnly? TripDeparture { get; set; }
    public DateOnly? TripCompletion { get; set; }
}
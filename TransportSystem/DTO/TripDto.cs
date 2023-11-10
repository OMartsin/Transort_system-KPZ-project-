namespace TransportSystem.DTO; 

public class TripDto {
    public int TripId { get; set; }
    public string TripName { get; set; } = null!;
    public int TripTruckId { get; set; }
    public int TripTrailerId { get; set; }
    public string TripCargoName { get; set; }
    public int TripAgentId { get; set; }
    public int TripTotal { get; set; }
    public DateOnly? TripDeparture { get; set; }
    public DateOnly? TripCompletion { get; set; }
}
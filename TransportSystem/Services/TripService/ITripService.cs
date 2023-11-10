using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.TripService; 

public interface ITripService
{
    IEnumerable<TripDto> GetTrips();
    TripDto GetTripById(int id);
    TripDto AddTrip(TripDto tripDto);
    TripDto UpdateTrip(TripDto tripDto);
    void DeleteTrip(int id);
}
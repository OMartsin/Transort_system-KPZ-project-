using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.TripService; 

public interface ITripService
{
    IEnumerable<Trip> GetTrips();
    Trip GetTripById(int id);
    Trip AddTrip(TripInputDto tripDto);
    void UpdateTrip(int id, TripInputDto tripDto);
    void DeleteTrip(int id);
}
using TransportSystem.Models;

namespace TransportSystem.Services; 

public interface ITruckService {
    public IEnumerable<Truck> GetTrucks();
    public Truck GetTruck(int id);
    public Truck AddTruck(Truck truck);
    
    public void DeleteTruck(int id);
    public Truck UpdateTruck(int id, Truck truck);
}
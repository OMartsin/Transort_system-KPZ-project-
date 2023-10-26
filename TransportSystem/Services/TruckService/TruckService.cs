using TransportSystem.Models;

namespace TransportSystem.Services; 

public class TruckService: ITruckService {
    private TransportSystemContext _context;
    
    public TruckService(TransportSystemContext context) {
        _context = context;
    }
    
    public IEnumerable<Truck> GetTrucks() {
        return _context.Trucks;
    }
    
    public Truck GetTruck(int id) {
        return _context.Trucks.Find(id) ?? throw new Exception("Truck not found");
    }
    
    public Truck AddTruck(Truck truck) {
        _context.Trucks.Add(truck);
        _context.SaveChanges();
        return truck;
    }
    
    public void DeleteTruck(int id) {
        var truck = _context.Trucks.Find(id);
        if(truck is null) throw new Exception("Truck not found");
        _context.Trucks.Remove(truck);
        _context.SaveChanges();
    }

    public Truck UpdateTruck(int id, Truck truck) {
        var editTruck = _context.Trucks.Find(id);
        if(editTruck is null) throw new Exception("Truck not found" );
        editTruck.TruckNumberPlate = truck.TruckNumberPlate;
        editTruck.TruckFuelType = truck.TruckFuelType;
        editTruck.TruckVendor = truck.TruckVendor;
        editTruck.TruckModel = truck.TruckModel;
        editTruck.TruckEcoStandartEuro = truck.TruckEcoStandartEuro;
        editTruck.TruckWeight = truck.TruckWeight;
        editTruck.TruckFrontTyresType = truck.TruckFrontTyresType;
        editTruck.TruckRearTyperType = truck.TruckRearTyperType;
        _context.Trucks.Update(editTruck);
        _context.SaveChanges();
        return truck;
    }
}
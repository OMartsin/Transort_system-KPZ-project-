using TransportSystem.Models;

namespace TransportSystem.Services.CargoService; 

public class CargoService: ICargoService {
    private TransportSystemContext _context;
    
    public CargoService(TransportSystemContext context) {
        _context = context;
    }
    
    public IEnumerable<Cargo> GetCargos() {
        return _context.Cargos;
    }
    
    public Cargo GetCargo(int id) {
        return _context.Cargos.Find(id) ?? throw new Exception("Cargo not found");
    }

    public Cargo AddCargo(Cargo cargo) {
        _context.Cargos.Add(cargo);
        _context.SaveChanges();
        return cargo;
    }
    
    public void DeleteCargo(int id) {
        var cargo = _context.Cargos.Find(id);
        if(cargo is null) throw new Exception("Cargo not found");
        _context.Cargos.Remove(cargo);
        _context.SaveChanges();
    }
    
    public Cargo UpdateCargo(int id, Cargo cargo) {
        var editCargo = _context.Cargos.Find(id);
        if(editCargo is null) throw new Exception("Cargo not found");
        editCargo.CargoName = cargo.CargoName;
        editCargo.CargoWeight = cargo.CargoWeight;
        _context.Cargos.Update(editCargo);
        _context.SaveChanges();
        return cargo;
    }
}
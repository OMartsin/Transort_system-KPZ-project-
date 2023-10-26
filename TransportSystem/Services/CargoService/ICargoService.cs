using TransportSystem.Models;

namespace TransportSystem.Services.CargoService; 

public interface ICargoService {
    public IEnumerable<Cargo> GetCargos();
    public Cargo GetCargo(int id);
    public Cargo AddCargo(Cargo cargo);
    public Cargo UpdateCargo(int id, Cargo cargo);
    public void DeleteCargo(int id);
}
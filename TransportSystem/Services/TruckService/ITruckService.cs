using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services
{
    public interface ITruckService
    {
        IEnumerable<TruckDto> GetTrucks();
        TruckDto GetTruck(int id);
        TruckDto AddTruck(TruckDto truck);
        void DeleteTruck(int id);
        TruckDto UpdateTruck(TruckDto truck);
    }
}

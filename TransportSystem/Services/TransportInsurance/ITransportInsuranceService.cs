using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services; 

public interface ITransportInsuranceService {
    public TransportInsuranceDto GetTransportInsurance(int id);
    public IEnumerable<TransportInsuranceDto> GetTransportInsurancesByTruckId(int truckId);
    public IEnumerable<TransportInsuranceDto> GetTransportInsurancesByTrailerId(int driverId);
    public TransportInsuranceDto AddTransportInsurance(TransportInsuranceDto transportInsurance);
    public TransportInsuranceDto UpdateTransportInsurance(TransportInsuranceDto transportInsurance);
    public void DeleteTransportInsurance(int id);
}
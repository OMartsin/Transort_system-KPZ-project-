using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services
{
    public class TransportInsuranceService : ITransportInsuranceService
    {
        private TransportSystemContext _context;
        private IMapper _mapper;

        public TransportInsuranceService(TransportSystemContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TransportInsuranceDto> GetTransportInsurances()
        {
            return _mapper.Map<IEnumerable<TransportInsuranceDto>>(_context.
                TransportInsurances.ToList());
        }

        public TransportInsuranceDto GetTransportInsurance(int id)
        {
            var transportInsurance = _context.TransportInsurances.Find(id);
            if (transportInsurance is null) throw new Exception("Transport insurance not found");
            return _mapper.Map<TransportInsuranceDto>(transportInsurance);
        }

        public IEnumerable<TransportInsuranceDto> GetTransportInsurancesByTruckId(int truckId)
        {
            return _mapper.Map<IEnumerable<TransportInsuranceDto>>(_context.TransportInsurances.Where(
                ti => ti.InsuranceTruckId == truckId).ToList());
        }

        public IEnumerable<TransportInsuranceDto> GetTransportInsurancesByTrailerId(int trailerId)
        {
            return _mapper.Map<IEnumerable<TransportInsuranceDto>>(_context.TransportInsurances.Where(
                ti => ti.InsuranceTrailerId == trailerId).ToList());
        }

        public TransportInsuranceDto AddTransportInsurance(TransportInsuranceDto transportInsurance)
        {
            _context.TransportInsurances.Add(_mapper.Map<TransportInsurance>(transportInsurance));
            _context.SaveChanges();
            return transportInsurance;
        }

        public TransportInsuranceDto UpdateTransportInsurance(TransportInsuranceDto transportInsurance)
        {
            var transportInsuranceToUpdate = _context.TransportInsurances.Find(
                transportInsurance.TransportInsuranceId);
            if (transportInsuranceToUpdate is null) throw new Exception("Transport insurance not found");

            _context.Entry(transportInsuranceToUpdate).CurrentValues.SetValues(transportInsurance);
            _context.SaveChanges();
            return transportInsurance;
        }

        public void DeleteTransportInsurance(int id)
        {
            var transportInsurance = _context.TransportInsurances.Find(id);
            if (transportInsurance is null) throw new Exception("Transport insurance not found");

            _context.TransportInsurances.Remove(transportInsurance);
            _context.SaveChanges();
        }
    }
}
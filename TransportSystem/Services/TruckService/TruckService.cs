using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services
{
    public class TruckService : ITruckService
    {
        private readonly TransportSystemContext _context;
        private readonly IMapper _mapper;

        public TruckService(TransportSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TruckDto> GetTrucks()
        {
            return _mapper.Map<IEnumerable<TruckDto>>(_context.Trucks.ToList());
        }

        public TruckDto GetTruck(int id)
        {
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                throw new Exception("Truck not found");
            }
            return _mapper.Map<TruckDto>(truck);
        }

        public TruckDto AddTruck(TruckDto truck)
        {
            var truckToAdd = _mapper.Map<Truck>(truck);
            _context.Trucks.Add(truckToAdd);
            _context.SaveChanges();
            return _mapper.Map<TruckDto>(truckToAdd);
        }

        public void DeleteTruck(int id)
        {
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                throw new Exception("Truck not found");
            }
            _context.Trucks.Remove(truck); 
            _context.SaveChanges();
        }

        public TruckDto UpdateTruck(TruckDto truck)
        {
            var existingTruck = _context.Trucks.Find(truck.TruckId);
            if (existingTruck == null)
            {
                throw new Exception("Truck not found");
            }
            
            _context.Entry(existingTruck).CurrentValues.SetValues(truck);

            _context.SaveChanges();
            return truck;
        }
    }
}

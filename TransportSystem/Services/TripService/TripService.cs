using System;
using System.Collections.Generic;
using TransportSystem.DTO;
using TransportSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace TransportSystem.Services.TripService
{
    public class TripService : ITripService
    {
        private readonly TransportSystemContext _context;

        public TripService(TransportSystemContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripById(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }
            return trip;
        }

        public Trip AddTrip(TripInputDto tripDto)
        {
            var trip = new Trip
            {
                TripName = tripDto.TripName,
                TripTruckId = tripDto.TripTruckId,
                TripTrailerId = tripDto.TripTrailerId,
                TripCargoName = tripDto.TripCargoName,
                TripAgentId = tripDto.TripAgentId,
                TripTotal = tripDto.TripTotal,
                TripDeparture = tripDto.TripDeparture
            };

            _context.Trips.Add(trip);
            _context.SaveChanges();
            return trip;
        }

        public void UpdateTrip(int id, TripInputDto tripDto)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            trip.TripName = tripDto.TripName;
            trip.TripTruckId = tripDto.TripTruckId;
            trip.TripTrailerId = tripDto.TripTrailerId;
            trip.TripCargoName = tripDto.TripCargoName;
            trip.TripAgentId = tripDto.TripAgentId;
            trip.TripTotal = tripDto.TripTotal;
            trip.TripDeparture = tripDto.TripDeparture;

            _context.SaveChanges();
        }

        public void DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }
    }
}

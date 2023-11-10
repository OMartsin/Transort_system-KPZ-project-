using AutoMapper;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.TripService
{
    public class TripService : ITripService
    {
        private readonly TransportSystemContext _context;
        private readonly IMapper _mapper;

        public TripService(TransportSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TripDto> GetTrips()
        {
            return _mapper.Map<IEnumerable<TripDto>>(_context.Trips.ToList());
        }

        public TripDto GetTripById(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }
            return _mapper.Map<TripDto>(trip);
        }

        public TripDto AddTrip(TripDto tripDto) {
            var trip = _mapper.Map<Trip>(tripDto);
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return _mapper.Map<TripDto>(trip);
        }

        public TripDto UpdateTrip(TripDto tripDto)
        {
            var trip = _context.Trips.Find(tripDto.TripId);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            _context.Entry(trip).CurrentValues.SetValues(_mapper.Map<Trip>(tripDto));

            _context.SaveChanges();
            return _mapper.Map<TripDto>(trip); 
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

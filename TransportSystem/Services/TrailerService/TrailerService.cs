using TransportSystem.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.TrailerService
{
    public class TrailerService : ITrailerService
    {
        private readonly TransportSystemContext _context;
        private readonly IMapper _mapper;

        public TrailerService(TransportSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TrailerDto> GetTrailers()
        {
            return _mapper.Map<IEnumerable<TrailerDto>>(_context.Trailers.ToList());
        }

        public TrailerDto GetTrailerById(int id)
        {
            var trailer = _context.Trailers.Find(id);
            if (trailer == null)
            {
                throw new Exception("Trailer not found");
            }
            return _mapper.Map<TrailerDto>(trailer);
        }

        public TrailerDto AddTrailer(TrailerDto trailer)
        {
            var tempTrailer = _mapper.Map<Trailer>(trailer);
            _context.Trailers.Add(tempTrailer);
            _context.SaveChanges();
            return _mapper.Map<TrailerDto>(tempTrailer);
        }

        public TrailerDto UpdateTrailer(TrailerDto trailer)
        {
            var existingTrailer = _context.Trailers.Find(trailer.TrailerId);
            if (existingTrailer == null)
            {
                throw new Exception("Trailer not found");
            }

            _context.Entry(existingTrailer).CurrentValues.SetValues(_mapper.Map<Trailer>(trailer));
            _context.SaveChanges();
            return trailer;
        }

        public void DeleteTrailer(int id)
        {
            var trailer = _context.Trailers.Find(id);
            if (trailer == null)
            {
                throw new Exception("Trailer not found");
            }
            _context.Trailers.Remove(trailer);
            _context.SaveChanges();
        }
    }
}

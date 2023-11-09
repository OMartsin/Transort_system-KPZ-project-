using TransportSystem.DTO;
using TransportSystem.Models;

namespace TransportSystem.Services.TrailerService; 

public interface ITrailerService
{
    IEnumerable<TrailerDto> GetTrailers();
    TrailerDto GetTrailerById(int id);
    TrailerDto AddTrailer(TrailerDto trailer);
    TrailerDto UpdateTrailer(TrailerDto trailer);
    void DeleteTrailer(int id);
}

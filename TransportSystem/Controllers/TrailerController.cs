using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.Models;

namespace TransportSystem.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TrailerController {
    private TransportSystemContext _transportSystemContext;
    
    public TrailerController(TransportSystemContext transportSystemContext) {
        _transportSystemContext = transportSystemContext;
    }
    
    [HttpGet("{id}", Name = "GetTrailer")]
    public Trailer GetTrailer(int id)
    {
        var trailer = _transportSystemContext.Trailers.Find(id);
        return trailer;
    }
    
    [HttpGet(Name = "GetTrailers")]
    public IEnumerable<Trailer> GetTrailers() {
        var trailers = _transportSystemContext.Trailers.ToList();
        return trailers;
    }   
    
    [HttpPost(Name = "AddTrailer")]
    public Trailer AddTrailer(string numberPlate, string vendor, string model, 
        int weight, string tyresType, string trailerType) { 
        var trailer = new Trailer {
            TrailerNumberPlate = numberPlate,
            TrailerVendor = vendor,
            TrailerModel = model,
            TrailerWeight = weight,
            TrailerTyresType = tyresType,
            TrailerType = trailerType
        };
        _transportSystemContext.Trailers.Add(trailer);
        _transportSystemContext.SaveChanges();
        return trailer;
    }
    
    [HttpDelete(Name = "DeleteTrailer")]
    public void DeleteTrailer(int id) {
        var trailer = _transportSystemContext.Trailers.Find(id);
        _transportSystemContext.Trailers.Remove(trailer);
        _transportSystemContext.SaveChanges();
    }   
    
    [HttpPut(Name = "UpdateTrailer")]
    public Trailer UpdateTrailer(int id, string numberPlate, string vendor, string model, 
        int weight, string tyresType, string trailerType) {
        var trailer = _transportSystemContext.Trailers.Find(id);
        trailer.TrailerNumberPlate = numberPlate;
        trailer.TrailerVendor = vendor;
        trailer.TrailerModel = model;
        trailer.TrailerWeight = weight;
        trailer.TrailerTyresType = tyresType;
        trailer.TrailerType = trailerType;
        _transportSystemContext.SaveChanges();
        return trailer;
    }
}
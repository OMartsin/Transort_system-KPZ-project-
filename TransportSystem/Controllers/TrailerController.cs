using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Models;
using TransportSystem.Services;
using TransportSystem.Services.TrailerService;

namespace TransportSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class TrailerController : ControllerBase {
    private readonly ITrailerService _trailerService;
    private readonly ITransportInsuranceService _transportInsuranceService;
    
    public TrailerController(ITrailerService trailerService, 
        ITransportInsuranceService transportInsuranceService) {
        _trailerService = trailerService;
        _transportInsuranceService = transportInsuranceService;
    }

    [HttpGet("{id}", Name = "GetTrailer")]
    public ActionResult<TrailerDto> GetTrailer(int id) {
        try {
            var trailer = _trailerService.GetTrailerById(id);
            return Ok(trailer);
        }
        catch (Exception e) {
            return BadRequest(new {message = e.Message});
        }
    }
    
    [HttpGet(Name = "GetTrailers")]
    public ActionResult<IEnumerable<TrailerDto>> GetTrailers() {
        try {
            var trailers = _trailerService.GetTrailers();
            return Ok(trailers);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpPost(Name = "AddTrailer")]
    public ActionResult<TrailerDto> AddTrailer([FromBody] TrailerDto trailer) {
        try {
            var addedTrailer = _trailerService.AddTrailer(trailer);
            return Ok(addedTrailer);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpDelete(Name = "DeleteTrailer")]
    public ActionResult DeleteTrailer(int id) {
        try { 
            _trailerService.DeleteTrailer(id);
            return Ok();
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpPut(Name = "UpdateTrailer")]
    public ActionResult<TrailerDto> UpdateTrailer([FromBody] TrailerDto trailer) {
        try { 
            var updateTrailer = _trailerService.UpdateTrailer(trailer);
            return Ok(updateTrailer);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpGet("trailers/insurances", Name = "GetTransportInsurances")]
    public ActionResult<IEnumerable<TransportInsuranceDto>> GetTransportInsurances(int trailerId) {
        try {
            var transportInsurances = 
                _transportInsuranceService.GetTransportInsurancesByTrailerId(trailerId);
            return Ok(transportInsurances);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost("trailers/insurances", Name = "AddTransportInsurance")]
    public ActionResult<TransportInsuranceDto> AddTrailerTransportInsurance(
        [FromBody] TransportInsuranceDto transportInsuranceDto) {
        try {
            var addedTransportInsurance = _transportInsuranceService.AddTransportInsurance(
                transportInsuranceDto);
            return Ok(addedTransportInsurance);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPut("trailers/insurances", Name = "UpdateTransportInsurance")]
    public ActionResult<TransportInsurance> UpdateTrailerTransportInsurance(
        [FromBody] TransportInsuranceDto transportInsuranceDto) {
        try {
            var updatedTransportInsurance = _transportInsuranceService.UpdateTransportInsurance(
                transportInsuranceDto);
            return Ok(updatedTransportInsurance);
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
    
    
}
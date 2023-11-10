using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Services.TripService;

namespace TransportSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet(Name = "GetTrips")]
        public ActionResult<IEnumerable<TripDto>> GetTrips()
        {
            try
            {
                var trips = _tripService.GetTrips();
                return Ok(trips);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{id}", Name = "GetTrip")]
        public ActionResult<TripDto> GetTrip(int id)
        {
            try
            {
                var trip = _tripService.GetTripById(id);
                return Ok(trip);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost(Name = "AddTrip")]
        public ActionResult<TripDto> AddTrip([FromBody] TripDto tripDto)
        {
            try
            {
                var addedTrip = _tripService.AddTrip(tripDto);
                return CreatedAtAction("GetTrip", new { id = addedTrip.TripId }, addedTrip);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}", Name = "UpdateTrip")]
        public ActionResult UpdateTrip( [FromBody] TripDto tripDto)
        {
            try
            {
                var trip = _tripService.UpdateTrip(tripDto);
                return Ok(trip);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("{id}", Name = "DeleteTrip")]
        public IActionResult DeleteTrip(int id)
        {
            try
            {
                _tripService.DeleteTrip(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

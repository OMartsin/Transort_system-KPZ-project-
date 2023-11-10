using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportSystem.DTO;
using TransportSystem.Services;
using AutoMapper;

namespace TransportSystem.Controllers {
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class TruckController : ControllerBase {
        private readonly ITruckService _truckService;
        private readonly ITransportInsuranceService _insuranceService;
        private readonly IMapper _mapper;

        public TruckController(ITruckService truckService, ITransportInsuranceService insuranceService
            , IMapper mapper) {
            _truckService = truckService;
            _insuranceService = insuranceService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetTruck")]
        public ActionResult<TruckDto> GetTruck(int id) {
            try {
                var truck = _truckService.GetTruck(id);
                if (truck == null) {
                    return NotFound();
                }

                return Ok(truck);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet(Name = "GetTrucks")]
        public ActionResult<IEnumerable<TruckDto>> GetTrucks() {
            try {
                var trucks = _truckService.GetTrucks();
                return Ok(trucks);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost(Name = "AddTruck")]
        public ActionResult<TruckDto> AddTruck([FromBody] TruckDto truck) {
            try {
                var addedTruck = _truckService.AddTruck(truck);
                return Ok(addedTruck);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete(Name = "DeleteTruck")]
        public IActionResult DeleteTruck(int id) {
            try { 
                _truckService.DeleteTruck(id);
                return Ok(new { message = "Truck deleted successfully." });
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut( Name = "UpdateTruck")]
        public ActionResult<TruckDto> UpdateTruck([FromBody] TruckDto truck) {
            try {
                var updatedTruck = _truckService.UpdateTruck(truck);
                return Ok(updatedTruck);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("insurance", Name = "GetTruckInsurances")]
        public ActionResult<IEnumerable<TransportInsuranceDto>> GetTruckInsurances(int id) {
            try {
                var insurances =
                    _insuranceService.GetTransportInsurancesByTruckId(id);
                return Ok(insurances);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost("insurance", Name = "AddTruckInsurance")]
        public ActionResult<TransportInsuranceDto> AddTruckInsurance(int id,
            [FromBody] TransportInsuranceDto transportInsuranceDto) {
            try {
                var addedInsurance = _insuranceService.AddTransportInsurance(transportInsuranceDto);
                return Ok(addedInsurance);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("insurance", Name = "UpdateTruckInsurance")]
        public ActionResult<TransportInsuranceDto> UpdateTruckInsurance(
            [FromBody] TransportInsuranceDto transportInsuranceDto) {
            try {
                var updatedInsurance = _insuranceService.UpdateTransportInsurance(transportInsuranceDto);
                return Ok(updatedInsurance);
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("insurance/{insuranceId}", Name = "DeleteTruckInsurance")]
        public IActionResult DeleteTruckInsurance(int insuranceId) {
            try {
                _insuranceService.DeleteTransportInsurance(insuranceId);
                return Ok(new { message = "Insurance deleted successfully." });
            }
            catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
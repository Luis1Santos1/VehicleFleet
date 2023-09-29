using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleFleetAPI.Models;
using VehicleFleetAPI.Persistence;

namespace VehicleFleetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleInsuranceController : Controller
    {
        private readonly VehicleFleetDbContext _context;

        public VehicleInsuranceController(VehicleFleetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehiclesInsurances()
        {
            var vehiclesInsurance = await _context.VehiclesInsurances.ToListAsync();
            return Ok(vehiclesInsurance);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleInsuranceById(int id)
        {
            if (_context.VehiclesInsurances == null)
            {
                return NotFound();
            }

            var vehiclesInsurance = await _context.VehiclesInsurances.FirstOrDefaultAsync(x => x.Id == id);

            if (vehiclesInsurance != null)
            {
                return Ok(vehiclesInsurance);
            }
            return NotFound("Vehicle Insurance  Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> PostVehicleInsurance(VehicleInsuranceModel vehicleInsurance)
        {
            var existingVehicle = await _context.Vehicles.FindAsync(vehicleInsurance.VehicleId);

            if (existingVehicle == null)
            {
                return BadRequest("Vehicle with the specified VehicleId does not exist.");
            }

            await _context.VehiclesInsurances.AddAsync(vehicleInsurance);
            await _context.SaveChangesAsync();

            int insuranceId = vehicleInsurance.Id;

            existingVehicle.InsuranceId = insuranceId;

            await _context.SaveChangesAsync();

            var resourceUrl = Url.Action("GetVehicleInsuranceById", new { id = vehicleInsurance.Id });


            return Created(resourceUrl, vehicleInsurance);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleInsurance(int id, [FromBody] VehicleInsuranceModel updatedVehicleInsurance)
        {
            var existingVehicleInsurance = await _context.VehiclesInsurances.FindAsync(id);

            if (existingVehicleInsurance == null)
            {
                return NotFound();
            }

            updatedVehicleInsurance.Id = id;

            _context.Entry(existingVehicleInsurance).CurrentValues.SetValues(updatedVehicleInsurance);

            await _context.SaveChangesAsync();

            return Ok(existingVehicleInsurance);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInsurance(int id)
        {
            if (_context.VehiclesInsurances == null)
            {
                return NotFound();
            }
            var vehicleInsurance = await _context.VehiclesInsurances.FindAsync(id);
            if (vehicleInsurance == null)
            {
                return NotFound();
            }

            _context.VehiclesInsurances.Remove(vehicleInsurance);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

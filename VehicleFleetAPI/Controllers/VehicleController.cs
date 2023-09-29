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
    public class VehicleController : Controller
    {
        private readonly VehicleFleetDbContext _context;

        public VehicleController(VehicleFleetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles() 
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound("Vehicle Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> PostVehicle(VehicleModel vehicle)
        {
            var existingOwner = await _context.Owners.FindAsync(vehicle.OwnerId);

            if(existingOwner == null)
            {
                return BadRequest("Owner with the specified OwnerId does not exist.");
            }
            
            if (existingOwner.Vehicles == null)
            {
                existingOwner.Vehicles = new List<VehicleModel>();
            }

            existingOwner.Vehicles.Add(vehicle);

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            var resourceUrl = Url.Action("GetVehicleById", new { id = vehicle.Id });

            return Created(resourceUrl, vehicle);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, [FromBody] VehicleModel updatedVehicle)
        {
            var existingVehicle = await _context.Vehicles.FindAsync(id);

            if (existingVehicle == null)
            {
                return NotFound();
            }

            updatedVehicle.Id = id;

            _context.Entry(existingVehicle).CurrentValues.SetValues(updatedVehicle);

            await _context.SaveChangesAsync();

            return Ok(existingVehicle);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

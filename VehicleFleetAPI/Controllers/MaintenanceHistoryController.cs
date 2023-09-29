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
    public class MaintenanceHistoryController : Controller
    {
        private readonly VehicleFleetDbContext _context;

        public MaintenanceHistoryController(VehicleFleetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaintenancesHistory()
        {
            var maintenanceHistory = await _context.MaintenancesHistorys.ToListAsync();
            return Ok(maintenanceHistory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenanceHistoryById(int id)
        {
            if (_context.MaintenancesHistorys == null)
            {
                return NotFound();
            }

            var maintenanceHistory = await _context.MaintenancesHistorys.FirstOrDefaultAsync(x => x.Id == id);

            if (maintenanceHistory != null)
            {
                return Ok(maintenanceHistory);
            }
            return NotFound("Maintenance History Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> PostMaintenanceHistory(MaintenanceHistoryModel maintenanceHistory)
        {
            var existingVehicle = await _context.Vehicles.FindAsync(maintenanceHistory.VehicleId);

            if (existingVehicle == null)
            {
                return BadRequest("Vehicle with the specified VehicleId does not exist.");
            }

            existingVehicle.InsuranceId = maintenanceHistory.VehicleId;

            await _context.MaintenancesHistorys.AddAsync(maintenanceHistory);
            await _context.SaveChangesAsync();

            var resourceUrl = Url.Action("GetMaintenanceHistoryById", new { id = maintenanceHistory.Id });


            return Created(resourceUrl, maintenanceHistory);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceHistory(int id, [FromBody] MaintenanceHistoryModel updateMaintenanceHistory)
        {
            var existingMaintenanceHistory = await _context.MaintenancesHistorys.FindAsync(id);

            if (existingMaintenanceHistory == null)
            {
                return NotFound();
            }

            updateMaintenanceHistory.Id = id;

            _context.Entry(existingMaintenanceHistory).CurrentValues.SetValues(updateMaintenanceHistory);

            await _context.SaveChangesAsync();

            return Ok(existingMaintenanceHistory);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceHistory(int id)
        {
            if (_context.MaintenancesHistorys == null)
            {
                return NotFound();
            }
            var maintenanceHistory = await _context.MaintenancesHistorys.FindAsync(id);
            if (maintenanceHistory == null)
            {
                return NotFound();
            }

            _context.MaintenancesHistorys.Remove(maintenanceHistory);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}

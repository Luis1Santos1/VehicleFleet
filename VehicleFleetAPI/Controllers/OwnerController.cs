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
    public class OwnerController : Controller
    {
        private readonly VehicleFleetDbContext _context;

        public OwnerController(VehicleFleetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _context.Owners.ToListAsync();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner != null)
            {
                return Ok(owner);
            }
            return NotFound("Owner Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> PostOwner(OwnerModel owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();

            var resourceUrl = Url.Action("GetOwnerById", new { id = owner.Id });


            return Created(resourceUrl, owner);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, [FromBody] OwnerModel updatedOwner)
        {
            var existingOwner = await _context.Owners.FindAsync(id);

            if (existingOwner == null)
            {
                return NotFound();
            }

            updatedOwner.Id = id;

            _context.Entry(existingOwner).CurrentValues.SetValues(updatedOwner);

            await _context.SaveChangesAsync();

            return Ok(existingOwner);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}

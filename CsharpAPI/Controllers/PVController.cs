using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CsharpAPI.Models;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PVController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PVController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PV
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PV>>> GetPVs()
        {
            return await _context.PV.ToListAsync();
        }

        // GET: api/PV/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PV>> GetPV(Guid id)
        {
            var pv = await _context.PV.FindAsync(id);

            if (pv == null)
            {
                return NotFound();
            }

            return pv;
        }

        // POST: api/PV
        [HttpPost]
        public async Task<ActionResult<PV>> CreatePV(PV pv)
        {
            _context.PV.Add(pv);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPV), new { id = pv.IdPV }, pv);
        }

        // PUT: api/PV/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePV(Guid id, PV pv)
        {
            if (id != pv.IdPV)
            {
                return BadRequest();
            }

            _context.Entry(pv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PVExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PV/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePV(Guid id)
        {
            var pv = await _context.PV.FindAsync(id);
            if (pv == null)
            {
                return NotFound();
            }

            _context.PV.Remove(pv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PVExists(Guid id)
        {
            return _context.PV.Any(e => e.IdPV == id);
        }
    }
}

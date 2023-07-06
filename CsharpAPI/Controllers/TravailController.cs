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
    public class TravailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TravailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Travail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travail>>> GetTravails()
        {
            return await _context.Travail.ToListAsync();
        }

        // GET: api/Travail/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Travail>> GetTravail(Guid id)
        {
            var travail = await _context.Travail.FindAsync(id);

            if (travail == null)
            {
                return NotFound();
            }

            return travail;
        }

        // POST: api/Travail
        [HttpPost]
        public async Task<ActionResult<Travail>> CreateTravail(Travail travail)
        {
            _context.Travail.Add(travail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTravail), new { id = travail.IdTravail }, travail);
        }

        // PUT: api/Travail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTravail(Guid id, Travail travail)
        {
            if (id != travail.IdTravail)
            {
                return BadRequest();
            }

            _context.Entry(travail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravailExists(id))
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

        // DELETE: api/Travail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravail(Guid id)
        {
            var travail = await _context.Travail.FindAsync(id);
            if (travail == null)
            {
                return NotFound();
            }

            _context.Travail.Remove(travail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravailExists(Guid id)
        {
            return _context.Travail.Any(e => e.IdTravail == id);
        }
    }
}

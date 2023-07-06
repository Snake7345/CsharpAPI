using Microsoft.AspNetCore.Mvc;
using CsharpAPI.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaliteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocaliteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Localite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localite>>> GetLocalites()
        {
            return await _context.Localite.ToListAsync();
        }

        // GET: api/Localite/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Localite>> GetLocalite(Guid id)
        {
            var localite = await _context.Localite.FindAsync(id);

            if (localite == null)
            {
                return NotFound();
            }

            return localite;
        }

        // POST: api/Localite
        [HttpPost]
        public async Task<ActionResult<Localite>> CreateLocalite(Localite localite)
        {
            localite.IdLocalite = Guid.NewGuid();
            _context.Localite.Add(localite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocalite), new { id = localite.IdLocalite }, localite);
        }

        // PUT: api/Localite/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocalite(Guid id, Localite localite)
        {
            if (id != localite.IdLocalite)
            {
                return BadRequest();
            }

            _context.Entry(localite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaliteExists(id))
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

        // DELETE: api/Localite/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalite(Guid id)
        {
            var localite = await _context.Localite.FindAsync(id);
            if (localite == null)
            {
                return NotFound();
            }

            _context.Localite.Remove(localite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaliteExists(Guid id)
        {
            return _context.Localite.Any(l => l.IdLocalite == id);
        }
    }
}
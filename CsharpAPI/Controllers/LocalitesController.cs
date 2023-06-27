using Microsoft.AspNetCore.Mvc;
using CsharpAPI.Class;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalitesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocalitesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Localites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localites>>> GetLocalites()
        {
            return await _context.Localites.ToListAsync();
        }

        // GET: api/Localites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localites>> GetLocalite(int id)
        {
            var localite = await _context.Localites.FindAsync(id);

            if (localite == null)
            {
                return NotFound();
            }

            return localite;
        }

        // POST: api/Localites
        [HttpPost]
        public async Task<ActionResult<Localites>> CreateLocalite(Localites localite)
        {
            _context.Localites.Add(localite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocalite), new { id = localite.Id }, localite);
        }

        // PUT: api/Localites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocalite(int id, Localites localite)
        {
            if (id != localite.Id)
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

        // DELETE: api/Localites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalite(int id)
        {
            var localite = await _context.Localites.FindAsync(id);
            if (localite == null)
            {
                return NotFound();
            }

            _context.Localites.Remove(localite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaliteExists(int id)
        {
            return _context.Localites.Any(l => l.Id == id);
        }
    }
}

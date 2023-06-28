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
    public class PersonnesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonnesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Personnes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personnes>>> GetPersonnes()
        {
            return await _context.Personnes.Include(p => p.Localite).ToListAsync();
        }

        // GET: api/Personnes/bylocalite/{localiteId}
        [HttpGet("bylocalite/{localiteId}")]
        public async Task<ActionResult<IEnumerable<Personnes>>> GetPersonnesByLocalite(Guid localiteId)
        {
            return await _context.Personnes.Where(p => p.LocaliteId == localiteId).Include(p => p.Localite).ToListAsync();
        }

        // GET: api/Personnes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Personnes>> GetPersonne(Guid id)
        {
            var personne = await _context.Personnes.Include(p => p.Localite).FirstOrDefaultAsync(p => p.IdPersonne == id);

            if (personne == null)
            {
                return NotFound();
            }

            return personne;
        }

        // POST: api/Personnes
        [HttpPost]
        public async Task<ActionResult<Personnes>> CreatePersonne(Personnes personne)
        {
            personne.IdPersonne = Guid.NewGuid();
            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonne), new { id = personne.IdPersonne }, personne);
        }

        // PUT: api/Personnes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonne(Guid id, Personnes personne)
        {
            if (id != personne.IdPersonne)
            {
                return BadRequest();
            }

            _context.Entry(personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(id))
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

        // DELETE: api/Personnes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonne(Guid id)
        {
            var personne = await _context.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }

            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonneExists(Guid id)
        {
            return _context.Personnes.Any(p => p.IdPersonne == id);
        }
    }
}

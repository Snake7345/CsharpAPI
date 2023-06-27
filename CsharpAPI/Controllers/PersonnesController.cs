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

        // GET: api/Personnes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personnes>> GetPersonne(int id)
        {
            var personne = await _context.Personnes.Include(p => p.Localite).FirstOrDefaultAsync(p => p.Id == id);

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
            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonne), new { id = personne.Id }, personne);
        }

        // PUT: api/Personnes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonne(int id, Personnes personne)
        {
            if (id != personne.Id)
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

        // DELETE: api/Personnes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonne(int id)
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

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(p => p.Id == id);
        }
    }
}

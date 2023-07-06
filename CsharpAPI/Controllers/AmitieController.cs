using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpAPI.Models;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmitieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AmitieController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Amitie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amitie>>> GetAmitie()
        {
            return await _context.Amitie.ToListAsync();
        }

        // GET: api/Amitie/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Amitie>> GetAmitie(Guid id)
        {
            var amitie = await _context.Amitie.FindAsync(id);

            if (amitie == null)
            {
                return NotFound();
            }

            return amitie;
        }

        // POST: api/Amitie
        [HttpPost]
        public async Task<ActionResult<Amitie>> CreateAmitie(Amitie amitie)
        {
            _context.Amitie.Add(amitie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAmitie), new { id = amitie.IdAmitie }, amitie);
        }

        // PUT: api/Amitie/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmitie(Guid id, Amitie amitie)
        {
            if (id != amitie.IdAmitie)
            {
                return BadRequest();
            }

            _context.Entry(amitie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmitieExists(id))
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

        // DELETE: api/Amitie/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmitie(Guid id)
        {
            var amitie = await _context.Amitie.FindAsync(id);
            if (amitie == null)
            {
                return NotFound();
            }

            _context.Amitie.Remove(amitie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmitieExists(Guid id)
        {
            return _context.Amitie.Any(e => e.IdAmitie == id);
        }
    }
}
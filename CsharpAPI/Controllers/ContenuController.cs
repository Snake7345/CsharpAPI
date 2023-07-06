using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpAPI.Models;

namespace CsharpAPI.Controllers
{

    namespace CsharpAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ContenuController : ControllerBase
        {
            private readonly AppDbContext _context;

            public ContenuController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/Contenu
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Contenu>>> GetContenus()
            {
                return await _context.Contenu.ToListAsync();
            }

            // GET: api/Contenu/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<Contenu>> GetContenu(Guid id)
            {
                var contenu = await _context.Contenu.FindAsync(id);

                if (contenu == null)
                {
                    return NotFound();
                }

                return contenu;
            }

            // POST: api/Contenu
            [HttpPost]
            public async Task<ActionResult<Contenu>> CreateContenu(Contenu contenu)
            {
                _context.Contenu.Add(contenu);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetContenu), new { id = contenu.IdContenu }, contenu);
            }

            // PUT: api/Contenu/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateContenu(Guid id, Contenu contenu)
            {
                if (id != contenu.IdContenu)
                {
                    return BadRequest();
                }

                _context.Entry(contenu).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContenuExists(id))
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

            // DELETE: api/Contenu/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteContenu(Guid id)
            {
                var contenu = await _context.Contenu.FindAsync(id);
                if (contenu == null)
                {
                    return NotFound();
                }

                _context.Contenu.Remove(contenu);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ContenuExists(Guid id)
            {
                return _context.Contenu.Any(e => e.IdContenu == id);
            }
        }
    }
}

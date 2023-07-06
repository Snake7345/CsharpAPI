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
    public class PublicationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PublicationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Publication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublications()
        {
            return await _context.Publication.ToListAsync();
        }

        // GET: api/Publication/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublication(Guid id)
        {
            var publication = await _context.Publication.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return publication;
        }

        // POST: api/Publication
        [HttpPost]
        public async Task<ActionResult<Publication>> CreatePublication(Publication publication)
        {
            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublication), new { id = publication.IdPublication }, publication);
        }

        // PUT: api/Publication/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublication(Guid id, Publication publication)
        {
            if (id != publication.IdPublication)
            {
                return BadRequest();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // DELETE: api/Publication/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(Guid id)
        {
            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationExists(Guid id)
        {
            return _context.Publication.Any(e => e.IdPublication == id);
        }
    }
}

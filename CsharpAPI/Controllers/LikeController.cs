using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CsharpAPI.Models;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LikeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Like
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
            return await _context.Like.ToListAsync();
        }

        // GET: api/Like/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(Guid id)
        {
            var like = await _context.Like.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        // POST: api/Like
        [HttpPost]
        public async Task<ActionResult<Like>> CreateLike(Like like)
        {
            _context.Like.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLike), new { id = like.IdLike }, like);
        }

        // PUT: api/Like/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLike(Guid id, Like like)
        {
            if (id != like.IdLike)
            {
                return BadRequest();
            }

            _context.Entry(like).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // DELETE: api/Like/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(Guid id)
        {
            var like = await _context.Like.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            _context.Like.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeExists(Guid id)
        {
            return _context.Like.Any(e => e.IdLike == id);
        }
    }
}

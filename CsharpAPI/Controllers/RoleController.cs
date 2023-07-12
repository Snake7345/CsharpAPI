using CsharpAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI.Controllers
{
    public class RoleController : ControllerBase
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

            // GET: api/Role
            [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Role.ToListAsync();
        }

        // GET: api/Role/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Role.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.IdRole }, role);
        }

        // PUT: api/Role/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role role)
        {
            if (id != role.IdRole)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.IdRole == id);
        }
    }
}
}

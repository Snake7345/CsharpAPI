using CsharpAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
            private readonly AppDbContext _context;

            public PermissionController(AppDbContext context)
            {
                _context = context;
            }
        // GET: api/Permission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
        {
            return await _context.Permission.ToListAsync();
        }

        // GET: api/Permission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetPermission(int id)
        {
            var permission = await _context.Permission.FindAsync(id);

            if (permission == null)
            {
                return NotFound();
            }

            return permission;
        }

        // POST: api/Permission
        [HttpPost]
        public async Task<ActionResult<Permission>> CreatePermission(Permission permission)
        {
            _context.Permission.Add(permission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermission", new { id = permission.IdPermission }, permission);
        }

        // PUT: api/Permission/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, Permission permission)
        {
            if (id != permission.IdPermission)
            {
                return BadRequest();
            }

            _context.Entry(permission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
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

        // DELETE: api/Permission/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionExists(int id)
        {
            return _context.Permission.Any(e => e.IdPermission == id);
        }

    }
}

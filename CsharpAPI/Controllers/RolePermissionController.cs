using CsharpAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolePermissionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RolePermission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermission>>> GetRolePermissions()
        {
            return await _context.RolePermission.ToListAsync();
        }

        // GET: api/RolePermission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RolePermission>> GetRolePermission(Guid id)
        {
            var rolePermission = await _context.RolePermission.FindAsync(id);

            if (rolePermission == null)
            {
                return NotFound();
            }

            return rolePermission;
        }

        // POST: api/RolePermission
        [HttpPost]
        public async Task<ActionResult<RolePermission>> CreateRolePermission(RolePermission rolePermission)
        {
            _context.RolePermission.Add(rolePermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRolePermission), new { id = rolePermission.IdRolePermission }, rolePermission);
        }

        // PUT: api/RolePermission/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRolePermission(Guid id, RolePermission rolePermission)
        {
            if (id != rolePermission.IdRolePermission)
            {
                return BadRequest();
            }

            _context.Entry(rolePermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolePermissionExists(id))
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

        // DELETE: api/RolePermission/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermission(Guid id)
        {
            var rolePermission = await _context.RolePermission.FindAsync(id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            _context.RolePermission.Remove(rolePermission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolePermissionExists(Guid id)
        {
            return _context.RolePermission.Any(e => e.IdRolePermission == id);
        }
    }
}

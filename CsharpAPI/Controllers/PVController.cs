using Microsoft.AspNetCore.Mvc;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PVController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PVController(AppDbContext context)
        {
            _context = context;
        }
    }
}

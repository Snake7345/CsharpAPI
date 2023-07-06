using Microsoft.AspNetCore.Mvc;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TravailController(AppDbContext context)
        {
            _context = context;
        }
    }
}

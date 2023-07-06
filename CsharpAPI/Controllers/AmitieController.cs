using Microsoft.AspNetCore.Mvc;

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
    }
}

using Microsoft.AspNetCore.Mvc;

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
    }
}

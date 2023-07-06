using Microsoft.AspNetCore.Mvc;

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
    }
}

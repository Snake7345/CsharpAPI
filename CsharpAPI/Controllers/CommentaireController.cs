using Microsoft.AspNetCore.Mvc;

namespace CsharpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentaireController(AppDbContext context)
        {
            _context = context;
        }

    }
}

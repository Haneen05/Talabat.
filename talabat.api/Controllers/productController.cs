using Microsoft.AspNetCore.Mvc;
using talbat.core.Entities;
using talbat.core.Repositery;

namespace talabat.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<productController> _logger;
        private readonly IGenericRepo<Product> _genericRepo;

        public productController(ILogger<productController> logger,IGenericRepo<Product> genericRepo)
        {
            _logger = logger;
            _genericRepo = genericRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _genericRepo.GetAllAsyn();
            return Ok(products);
        }



    }
}

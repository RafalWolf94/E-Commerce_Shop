using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("apo/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "this will be a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Single product";
            
        }
    }
}
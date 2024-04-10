using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productService.GetAllProducts();
            if (result == null)
            {
                return NotFound("No products are there at this moment");
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Product supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _productService.AddANewProduct(supplier);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }
    }
}

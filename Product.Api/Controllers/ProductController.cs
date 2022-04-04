using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductEntity product)
        {
            await _productService.CreateOrUpdate(product);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProductEntity product)
        {
            await _productService.CreateOrUpdate(product);
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id )
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
using ECOM.Core.Interfaces;
using ECOM.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _productService.GetProductByIdAsync(id);
            return Ok(products);
        }
    }
}

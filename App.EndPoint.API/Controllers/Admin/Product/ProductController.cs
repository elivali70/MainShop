using App.Domain.Core.Product.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.API.Controllers.Admin.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProduct(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            var products= await _productAppService.GetProducts(categoryId, keyWord, minPrice, maxPrice, brandId, cancellationToken);
            return Ok(products);
        }
    }
}

using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoint.API.Attribute;
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
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetProduct(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            var products= await _productAppService.GetProducts(categoryId, keyWord, minPrice, maxPrice, brandId, cancellationToken);
            return Ok(products);
        }

        [HttpPost("[action]")]
        [ApiKeyAuthorize]

        public async Task<IActionResult> SetProduct(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            await _productAppService.Set(productInputDto);
            return Ok();
        }
    }
}

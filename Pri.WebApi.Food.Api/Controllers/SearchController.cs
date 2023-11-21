using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Api.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SearchController(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchQuery)
        {
            var searchResults = await _productRepository.SearchAsync(searchQuery);

            var searchResultsDto = searchResults.Select(s => new ProductResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Category = new CategoryResponseDto
                {
                    Id = s.Category.Id,
                    Name = s.Category.Name
                }
            });

            return Ok(searchResultsDto);
        }
    }
}

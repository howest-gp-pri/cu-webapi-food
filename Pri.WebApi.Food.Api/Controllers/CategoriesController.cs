using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IProductRepository _productRepository;

        public CategoriesController(ICategoryRepository categoryRepository, 
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.ListAllAsync();
            var categoriesDto = categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"No category with an id of {id}");
            }
            var categoryDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsFromCategory(Guid id)
        {
            var products = await _productRepository.GetByCategoryIdAsync(id);

            var productsDto = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = new CategoryResponseDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            });

            return Ok(productsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var categoryEntity = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryRepository.AddAsync(categoryEntity);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var categoryEntity = await _categoryRepository.GetByIdAsync(categoryDto.Id);

            if (categoryEntity == null)
            {
                return NotFound($"No category with an id of {categoryDto.Id}");
            }

            categoryEntity.Name = categoryDto.Name;


            await _categoryRepository.UpdateAsync(categoryEntity);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            if (categoryEntity == null)
            {
                return NotFound($"No category with an id of {id}");
            }

            await _categoryRepository.DeleteAsync(categoryEntity);

            return Ok();
        }
    }
}

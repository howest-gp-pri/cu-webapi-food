using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.ListAllAsync();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"No product with an id of {id}");
            }
            var productDto = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            // Check if CategoryId exists in db
            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Cannot add new product because category with id {productDto.CategoryId} does not exists");
            }

            var productEntity = new Product
            {
                CategoryId = productDto.CategoryId,
                Name = productDto.Name
            };

            await _productRepository.AddAsync(productEntity);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            // Check if CategoryId exists in db
            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Cannot update product because category with id {productDto.CategoryId} does not exists");
            }

            var productEntity = await _productRepository.GetByIdAsync(productDto.Id);

            if (productEntity == null)
            {
                return NotFound($"No product with an id of {productDto.Id}");
            }

            productEntity.CategoryId = productDto.CategoryId;
            productEntity.Name = productDto.Name;


            await _productRepository.UpdateAsync(productEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            if (productEntity == null)
            {
                return NotFound($"No product with an id of {id}");
            }

            await _productRepository.DeleteAsync(productEntity);

            return Ok();
        }
    }
}

using Pri.WebApi.Food.Api.Dtos.Categories;

namespace Pri.WebApi.Food.Api.Dtos.Products
{
    public class ProductResponseDto : BaseDto
    {
        public string Name { get; set; }
        public CategoryResponseDto Category { get; set; }
    }
}

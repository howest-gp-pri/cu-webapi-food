using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Food.Api.Dtos.Categories
{
    public class CategoryRequestDto : BaseDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}

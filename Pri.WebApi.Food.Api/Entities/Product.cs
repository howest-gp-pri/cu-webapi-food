using System;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Food.Api.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

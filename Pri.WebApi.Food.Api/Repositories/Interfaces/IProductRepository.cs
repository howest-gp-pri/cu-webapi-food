using Pri.WebApi.Food.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Api.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}

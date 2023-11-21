using Pri.WebApi.Food.Api.Data;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Repositories.Interfaces;

namespace Pri.WebApi.Food.Api.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

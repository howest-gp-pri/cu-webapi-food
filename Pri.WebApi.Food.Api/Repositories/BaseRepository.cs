using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Api.Data;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Api.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.LastEditedOn = DateTime.UtcNow;

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastEditedOn = DateTime.UtcNow;

            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

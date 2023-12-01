using Bank.Core.Models;
using Bank.Infrastructure.DataContext;
using Bank.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> _dbSet;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }

        public async Task<bool> CreateAsync(T? entity)
        {
            if (entity is not null)
            {
                await _dbSet.AddAsync(entity);
            }
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T? entity)
        {
            if (entity is not null)
            {
                _dbSet.Remove(entity);
            }
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> UpdateAsync(T? entity)
        {
            if (entity is not null)
            {
                _dbSet.Update(entity);
            }
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }
        }

        public async Task<T?> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException($"Entity with id '{id}' does not exist");
            }
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }
    }
}
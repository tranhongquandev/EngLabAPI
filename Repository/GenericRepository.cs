using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EngLabAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EngLabAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly EngLabContext _context;

        public GenericRepository(EngLabContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public async Task<int> CountAllAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) ?? throw new InvalidOperationException("Entity not found");
        }



        public async Task<IEnumerable<T>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            if(!name.IsNullOrEmpty())
                return await _context.Set<T>().Where(x => x.ToString()!.Contains(name!)).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            else {
                return await _context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
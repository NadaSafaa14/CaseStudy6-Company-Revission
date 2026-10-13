using CaseStudy6_Company_Revission.Data;
using CaseStudy6_Company_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy6_Company_Revission.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepo(AppDbContext context)
        {
            _context=context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

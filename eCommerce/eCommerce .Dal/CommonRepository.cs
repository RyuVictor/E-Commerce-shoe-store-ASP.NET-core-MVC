
using eCommerce.Dal;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Dal
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        public CommonRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetDetailAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}

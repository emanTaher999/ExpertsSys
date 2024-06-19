using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SudaneseExpSYS.Data;
using SudaneseExpSYS.Repository.Base;

namespace SudaneseExpSYS.Repository
{
    public class MainRepository<T> : IRepositroy<T> where T : class
    {
        protected AppDbContext context;
        public MainRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> match)
        {
            return await context.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<T> FindByIdAsyn(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();

        }
        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
           
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        

        public async Task AddOneAsync(T myItem)
        {
            await context.Set<T>().AddAsync(myItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOneAsync(T myItem)
        {
           context.Set<T>().Update(myItem);
           context.SaveChanges();
        }

        public async Task DeleteOneAsync(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }



        //********************************************



    }
}


using System.Linq.Expressions;

namespace SudaneseExpSYS.Repository.Base
{
    public interface IRepositroy<T> where T : class
    {
        Task<T> SelectOneAsync(Expression<Func<T, bool>> match);

        Task<T> FindByIdAsyn(int id);   
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        Task AddOneAsync(T myItem);
        Task UpdateOneAsync(T myItem);
        Task DeleteOneAsync(T myItem);

       


      
       

    }
}

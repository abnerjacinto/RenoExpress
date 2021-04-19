using System.Collections.Generic;
using System.Threading.Tasks;
using RenoExpress.Sales.Core.Entities;

namespace RenoExpress.Sales.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {       
        Task<IEnumerable<T>> GetAllAsync();        
        Task<T> GetByIdAsync(string id);        
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(string id);
        
    }
}

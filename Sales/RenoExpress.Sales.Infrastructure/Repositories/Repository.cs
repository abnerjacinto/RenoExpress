using Microsoft.EntityFrameworkCore;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces;
using RenoExpress.Sales.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Infrastructure.Repositories
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
  {
    #region Attributes
    protected readonly DBContext _context;
    private readonly DbSet<T> _entities;
    #endregion

    #region Construtor
    public Repository(DBContext context)
    {
      _context = context;
      _entities = context.Set<T>();
    }
    #endregion

    #region Methods
    public async Task DeleteAsync(string id)
    {
      T entity = await GetByIdAsync(id);
      entity.Expired = 1;
      entity.ModifiedDate = DateTime.Now;
      _entities.Update(entity);
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _entities.Where(x => x.Expired == 0).ToListAsync();
    }
    
    public async Task<T> GetByIdAsync(string id)
    {
      return await _entities.FindAsync(id);
    }

    public async Task InsertAsync(T entity)
    {
      entity.Expired = 0;
      entity.ID = Guid.NewGuid().ToString();
      entity.CreatedDate = DateTime.Now;
      await _entities.AddAsync(entity);
    }    
    public void Update(T entity)
    {
      entity.ModifiedDate = DateTime.Now;
      _entities.Update(entity);
    }
    #endregion
  }
}

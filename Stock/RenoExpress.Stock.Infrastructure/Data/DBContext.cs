using Microsoft.EntityFrameworkCore;
using RenoExpress.Stock.Core.Entities;

namespace RenoExpress.Stock.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        #region Constructor
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductStock>()
                .HasKey(i => new { i.ID });           
                       

            // Database Schema
            // Se agrega Schema por es la misma tabla
            // al manejar distinta base de datos se borra el schema(opcional)
            builder.HasDefaultSchema("ProductStock");

        }
        #endregion

        #region Properties
        public DbSet<ProductStock> ProductStocks { get; set; }
       
             
        #endregion

    }
}

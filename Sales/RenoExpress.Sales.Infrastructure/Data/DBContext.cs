using Microsoft.EntityFrameworkCore;
using RenoExpress.Sales.Core.Entities;

namespace RenoExpress.Sales.Infrastructure.Data
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
            builder.Entity<Sale>()
                .HasKey(i => new { i.ID });
            builder.Entity<SaleDetail>()
                .HasKey(i => new { i.ID });
                       

            // Database Schema
            // Se agrega Schema por es la misma tabla
            // al manejar distinta base de datos se borra el schema(opcional)
            builder.HasDefaultSchema("Sales");

        }
        #endregion

        #region Properties
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
             
        #endregion

    }
}

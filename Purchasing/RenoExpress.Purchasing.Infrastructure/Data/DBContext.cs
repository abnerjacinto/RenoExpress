using Microsoft.EntityFrameworkCore;
using RenoExpress.Purchasing.Core.Entities;

namespace RenoExpress.Purchasing.Infrastructure.Data
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
            builder.Entity<Purchase>()
                .HasKey(i => new { i.ID });
            builder.Entity<PurchaseDetail>()
                .HasKey(i => new { i.ID });
                       

            // Database Schema
            builder.HasDefaultSchema("Purchasing");

        }
        #endregion

        #region Properties
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
             
        #endregion

    }
}

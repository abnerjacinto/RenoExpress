using System.ComponentModel.DataAnnotations.Schema;

namespace RenoExpress.Sales.Core.Entities
{
    public class SaleDetail:BaseEntity
    {
        #region Properties
        public string ProductID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string SaleId { get; set; }
        public Sale Sale { get; set; }

        [NotMapped]
        public double Partial
        {
            get { return Price * Quantity; }
        }
        #endregion

    }
}

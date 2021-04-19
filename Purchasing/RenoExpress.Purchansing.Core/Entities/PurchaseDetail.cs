using System.ComponentModel.DataAnnotations.Schema;

namespace RenoExpress.Purchasing.Core.Entities
{
    public class PurchaseDetail:BaseEntity
    {
        #region Properties
        public string PurchaseId { get; set; }
        public string ProductID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Purchase Purchase { get; set; }

        [NotMapped]
        public double Partial {
            get { return Price * Quantity; } 
        }
        #endregion
    }
}

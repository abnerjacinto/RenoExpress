using System.ComponentModel.DataAnnotations;

namespace RenoExpress.Purchasing.Core.DTOs
{
    public class PurchaseDetailDTO
    {
        #region Properties
        public string ID { get; set; }
        [Required]
        public string ProductID { get; set; }
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Partial { get; set; }
        #endregion

    }
}

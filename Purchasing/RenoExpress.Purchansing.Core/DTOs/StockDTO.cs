using System.ComponentModel.DataAnnotations;

namespace RenoExpress.Purchasing.Core.DTOs
{
    public class StockDTO
    {
        public string ID { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string BranchId { get; set; }
        [Required]
        public bool Increase { get; set; }
    }
}

namespace RenoExpress.Sales.Core.DTOs
{
    public class SaleDetailDTO
    {
        #region Properties
        public string ID { get; set; }
        public string ProductID { get; set; }
        public string BranchId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string SaleId { get; set; }
        public double Partial { get; set; }
        #endregion
    }
}

using System;

namespace RenoExpress.Sales.Core.DTOs
{
    public class SaleDTO
    {
        #region Properties
        public string ID { get; set; }
        public string Document { get; set; }
        public string CustomerId { get; set; }
        public string BranchID { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        #endregion
    }
}

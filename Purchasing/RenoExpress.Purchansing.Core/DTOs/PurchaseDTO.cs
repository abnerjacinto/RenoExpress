using System;
using System.Collections.Generic;

namespace RenoExpress.Purchasing.Core.DTOs
{
    public class PurchaseDTO
    {
        public string ID { get; set; }
        public string SupplierId { get; set; }
        public string Document { get; set; }
        public DateTime Date { get; set; }
        public string BranchID { get; set; }
        public double Total { get; set; }
        public List<PurchaseDetailDTO> PurchaseDetails { get; set; }

        
    }   
}

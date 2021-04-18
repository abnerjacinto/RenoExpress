using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RenoExpress.Purchasing.Core.Entities
{
    public class Purchase:BaseEntity
    {
        #region Properties
        public string SupplierID { get; set; }
        public string Document { get; set; }
        //public double Total { get; set; }
        public string BranchID { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        public double Total { 
            get {
                return PurchaseDetails.Sum(x => x.Partial);
            } 
        }
        #endregion

        #region Constructor
        public Purchase()
        {
            PurchaseDetails = new Collection<PurchaseDetail>();
        }
        #endregion
    }
}

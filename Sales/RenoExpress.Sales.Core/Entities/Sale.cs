using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RenoExpress.Sales.Core.Entities
{
    public class Sale:BaseEntity
    {
        #region Properties
        public string Document { get; set; }
        public string CustomerId { get; set; }
        public string BranchID { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }

        public double Total
        {
            get
            {
                return SaleDetails.Sum(x => x.Partial);
            }
        }

        #endregion

        #region Constructor
        public Sale()
        {
            SaleDetails = new Collection<SaleDetail>();
        }
        #endregion
    }
}

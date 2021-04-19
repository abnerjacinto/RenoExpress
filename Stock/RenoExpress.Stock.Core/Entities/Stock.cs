﻿namespace RenoExpress.Stock.Core.Entities
{
    public class Stock : BaseEntity
    {
        #region Properties
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string BranchId { get; set; }
        #endregion
    }
}

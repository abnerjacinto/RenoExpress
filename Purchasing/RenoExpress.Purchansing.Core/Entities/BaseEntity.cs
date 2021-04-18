using System;
using System.ComponentModel.DataAnnotations;

namespace RenoExpress.Purchasing.Core.Entities
{   
    public class BaseEntity
    {
        #region Properties
        [Key]
        public string ID { get; set; }
        public double? CreatedTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public double? ModifiedTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string ModifiedUserId { get; set; }        
        public int? Expired { get; set; }
        #endregion
    }
}
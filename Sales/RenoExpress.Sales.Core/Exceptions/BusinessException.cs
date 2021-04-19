using System;

namespace RenoExpress.Sales.Core.Exceptions
{
    
    public class BusinessException : Exception
    {
        #region Constructor
        public BusinessException()
        {
        }
        public BusinessException(string message) : base(message)
        {
        }
        #endregion
    }
}
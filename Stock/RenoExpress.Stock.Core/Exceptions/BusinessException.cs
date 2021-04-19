using System;

namespace RenoExpress.Stock.Core.Exceptions
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
using System;

namespace RenoExpress.Purchasing.Core.Exceptions
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
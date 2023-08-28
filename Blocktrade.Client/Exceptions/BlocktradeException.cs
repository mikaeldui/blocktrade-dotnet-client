using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blocktrade
{
    /// <summary>
    /// Base exception for Blocktrade.
    /// </summary>
    public class BlocktradeException : ApplicationException
    {
        public BlocktradeException()
        {
        }

        public BlocktradeException(string message) : base(message)
        {
        }

        public BlocktradeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlocktradeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

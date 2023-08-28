using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blocktrade
{
    /// <summary>
    /// Order book not found.
    /// </summary>
    public class OrderBookNotFoundException : BlocktradeException
    {
        public OrderBookNotFoundException()
        {
        }

        public OrderBookNotFoundException(string message) : base(message)
        {
        }

        public OrderBookNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderBookNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

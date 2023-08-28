using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blocktrade
{
    public class TickerNotFoundException : BlocktradeException
    {
        public TickerNotFoundException()
        {
        }

        public TickerNotFoundException(string message) : base(message)
        {
        }

        public TickerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TickerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

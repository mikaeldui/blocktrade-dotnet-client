using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blocktrade.Exceptions
{
    public class UnauthenticatedException : BlocktradeException
    {
        public UnauthenticatedException()
        {
        }

        public UnauthenticatedException(string message) : base(message)
        {
        }

        public UnauthenticatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthenticatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

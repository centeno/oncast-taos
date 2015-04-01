using System;

namespace oncast_taos.src.exception
{
    public class OrderingException : Exception
    {
        public OrderingException(string message)
            : base(message)
        {
        }

        public OrderingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

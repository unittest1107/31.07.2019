using System;
using System.Runtime.Serialization;

namespace DataCollections
{
    [Serializable]
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException()
        {
        }

        public EmptyQueueException(string message) : base(message)
        {
        }

        public EmptyQueueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
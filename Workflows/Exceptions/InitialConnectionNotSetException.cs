using System;
using System.Runtime.Serialization;

namespace Workflows.Engine
{
    [Serializable]
    internal class InitialConnectionNotSetException : Exception
    {
        public InitialConnectionNotSetException()
        {
        }

        public InitialConnectionNotSetException(string message) : base(message)
        {
        }

        public InitialConnectionNotSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InitialConnectionNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
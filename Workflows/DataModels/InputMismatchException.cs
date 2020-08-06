using System;
using System.Runtime.Serialization;
using Workflows.Interfaces;

namespace Workflows.DataModels
{
    [Serializable]
    internal class InputMismatchException : Exception
    {
        private WorkflowItem to;
        private string toName;
        private Type type;

        public InputMismatchException()
        {
        }

        public InputMismatchException(string message) : base(message)
        {
        }

        public InputMismatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InputMismatchException(WorkflowItem to, string toName, Type type)
        {
            this.to = to;
            this.toName = toName;
            this.type = type;
        }

        protected InputMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
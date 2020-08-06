using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Workflows.Interfaces;

namespace Workflows.Exceptions
{
    [Serializable]
    internal class WorkflowNotFoundException : Exception
    {
        private Guid toGuid;
        private string toName;
        private List<WorkflowItem> workflowItems;

        public WorkflowNotFoundException()
        {
        }

        public WorkflowNotFoundException(string message) : base(message)
        {
        }

        public WorkflowNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public WorkflowNotFoundException(Guid toGuid, string toName, List<WorkflowItem> workflowItems)
        {
            this.toGuid = toGuid;
            this.toName = toName;
            this.workflowItems = workflowItems;
        }

        protected WorkflowNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
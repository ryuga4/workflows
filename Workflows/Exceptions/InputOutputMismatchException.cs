using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Exceptions
{
    public class InputOutputMismatchException : Exception
    {
        private WorkflowItem from;
        private WorkflowItem to;
        private string fromName;
        private string toName;

        public InputOutputMismatchException(WorkflowItem from, WorkflowItem to, string fromName, string toName)
        {
            this.from = from;
            this.to = to;
            this.fromName = fromName;
            this.toName = toName;
        }
    }
}

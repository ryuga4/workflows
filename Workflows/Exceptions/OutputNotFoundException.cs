using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Exceptions
{
    public class OutputNotFoundException : Exception
    {
        private WorkflowItem to;
        private string toName;

        public OutputNotFoundException(WorkflowItem to, string toName)
        {
            this.to = to;
            this.toName = toName;
        }
    }
}

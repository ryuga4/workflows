using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Exceptions
{
    public class InputNotFoundException : Exception
    {
        private WorkflowItem from;
        private string fromName;

        public InputNotFoundException(WorkflowItem from, string fromName)
        {
            this.from = from;
            this.fromName = fromName;
        }
    }
}

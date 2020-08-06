using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Workflows
{
    public class Finish : WorkflowItem
    {
        public override Dictionary<string, Type> Inputs => new Dictionary<string, Type>() { { "Finish", typeof(object) } };

        public override Dictionary<string, Type> Outputs => new Dictionary<string, Type>() { { "Finish", typeof(object) } };

        public override Dictionary<string, object> Compute(Dictionary<string, object> inputs)
        {
            return inputs;
        }
    }
}

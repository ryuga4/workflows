using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Workflows
{
    public class Cast<A, B> : WorkflowItem
    {
        public override Dictionary<string, Type> Inputs => new Dictionary<string, Type>() { { "Value", typeof(A) } };

        public override Dictionary<string, Type> Outputs => new Dictionary<string, Type>() { { "Value", typeof(B) } };

        public override Dictionary<string, object> Compute(Dictionary<string, object> inputs)
        {
            return new Dictionary<string, object>() { { "Value", Convert.ChangeType(inputs["Value"], typeof(B)) } };
        }
    }
}

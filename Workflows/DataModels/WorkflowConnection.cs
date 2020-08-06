using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Exceptions;
using Workflows.Interfaces;

namespace Workflows.DataModels
{
    public class WorkflowConnection
    {
        public WorkflowItem From { get; set; }
        public WorkflowItem To { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public Type ContentType { get; set; }

        public WorkflowConnection()
        {

        }

        public WorkflowConnection(WorkflowItem from, WorkflowItem to, string fromName, string toName)
        {
            if (!from.Outputs.ContainsKey(fromName))
                throw new InputNotFoundException(from, fromName);
            if (!to.Inputs.ContainsKey(toName))
                throw new OutputNotFoundException(to, toName);
            if (from.Outputs[fromName] != to.Inputs[toName] && !from.Outputs[fromName].IsSubclassOf(to.Inputs[toName]))
                throw new InputOutputMismatchException(from, to, fromName, toName);


            From = from;
            To = to;
            FromName = fromName;
            ToName = toName;
            ContentType = from.Outputs[fromName];            
        }

        public Dictionary<string, object> Pass(Dictionary<string,object> input, Func<Dictionary<string,object>, Dictionary<string,object>> continuation)
        {
            return continuation(To.Compute(input));
        }
    }
}

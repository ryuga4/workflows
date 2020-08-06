using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Exceptions;
using Workflows.Interfaces;

namespace Workflows.DataModels
{
    public class InitialConnection<T>
    {
        public WorkflowItem To { get; set; }
        public string ToName { get; set; }
        public Type ContentType { get; set; }

        public InitialConnection()
        {

        }

        public InitialConnection(WorkflowItem to,string toName)
        {
            if (!to.Inputs.ContainsKey(toName))
                throw new OutputNotFoundException(to, toName);
            if (typeof(T) != to.Inputs[toName])
                throw new InputMismatchException(to, toName, typeof(T));
            
            To = to;
            ToName = toName;
            ContentType = to.Inputs[toName];
        }
    }
}

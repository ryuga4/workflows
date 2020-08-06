using System;
using System.Collections.Generic;
using System.Text;

namespace Workflows.DataModels
{
    public abstract class WorkflowDataWrapper<T>
    {
        public T Value { get; set; }
        public WorkflowDataWrapper(T value)
        {
            Value = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Workflows.Interfaces
{
    public abstract class WorkflowItem
    {
        public Guid Guid { get; }

        public WorkflowItem()
        {
            Guid = Guid.NewGuid();
        }

        public abstract Dictionary<string, Type> Inputs { get; }
        public abstract Dictionary<string, Type> Outputs { get; }
        public abstract Dictionary<string, object> Compute(Dictionary<string, object> inputs);

        public override bool Equals(object obj)
        {
            var item = obj as WorkflowItem;
            return item != null &&
                   Guid.Equals(item.Guid) &&
                   EqualityComparer<Dictionary<string, Type>>.Default.Equals(Inputs, item.Inputs) &&
                   EqualityComparer<Dictionary<string, Type>>.Default.Equals(Outputs, item.Outputs);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Guid, Inputs, Outputs);
        }

        public static bool operator==(WorkflowItem item1, WorkflowItem item2)
        {
            return item1?.Guid == item2?.Guid;
        }
        public static bool operator !=(WorkflowItem item1, WorkflowItem item2)
        {
            return item1?.Guid != item2?.Guid;
        }

    }
}

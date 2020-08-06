using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflows.DataModels;
using Workflows.Exceptions;
using Workflows.Interfaces;
using Workflows.Workflows;

namespace Workflows.Engine
{
    public class Workflow<T>
    {
        public InitialConnection<T> InitialConnection;

        public List<WorkflowItem> WorkflowItems;
        public List<WorkflowConnection> WorkflowConnections;

        private List<(Dictionary<string, object> data, Guid itemGuid)> Data;


        public Workflow()
        {
            WorkflowItems = new List<WorkflowItem>();
            WorkflowConnections = new List<WorkflowConnection>();
            Data = new List<(Dictionary<string, object> data, Guid itemGuid)>();
        }

        public void AddWorkflow(Guid fromGuid, Guid toGuid, string fromName, string toName)
        {
            var from = WorkflowItems.FirstOrDefault(x => x.Guid == fromGuid);
            var to = WorkflowItems.FirstOrDefault(x => x.Guid == toGuid);
            if (from == null)
                throw new WorkflowNotFoundException(fromGuid, fromName, WorkflowItems);
            if (to == null)
                throw new WorkflowNotFoundException(toGuid, toName, WorkflowItems);


            WorkflowConnections.Add(new WorkflowConnection(from, to, fromName, toName));
        }

        public void SetInit(Guid toGuid, string toName)
        {
            var to = WorkflowItems.FirstOrDefault(x => x.Guid == toGuid);
            if (to == null)
                throw new WorkflowNotFoundException(toGuid, toName, WorkflowItems);
            InitialConnection = new InitialConnection<T>(to, toName);
        }

        private List<WorkflowConnection> OutputConnections(Guid workflowGuid)
        {
            return WorkflowConnections.Where(x => x.From.Guid == workflowGuid).ToList();
        }


        public Dictionary<string,object> Compute(T input)
        {
            if (InitialConnection == null)
                throw new InitialConnectionNotSetException();

            Data.Add((new Dictionary<string, object>() { { InitialConnection.ToName, input } }, InitialConnection.To.Guid));            
            
            while (true)
            {
                var finishVal = Data.Where(x => x.data.ContainsKey("Finish"));
                if (finishVal.Any())
                    return finishVal.First().data;
                var requestedWorkflows = Data.Select(x => x.itemGuid).Distinct().Select(guid => WorkflowItems.Find(y=>y.Guid == guid)).ToList();
                foreach (var workflowItem in requestedWorkflows)
                {
                    RequestComputation(workflowItem);
                }
            }

        }

        public void RequestComputation(WorkflowItem workflowItem)
        {
            var data = Data.Where(x => x.itemGuid == workflowItem.Guid).SelectMany(x => x.data).ToDictionary(x => x.Key, x => x.Value);
            if (data.Any())
            {
                var result = workflowItem.Compute(data);
                Data.RemoveAll(x => x.itemGuid == workflowItem.Guid);

                var successors = OutputConnections(workflowItem.Guid);
                foreach (var el in successors)
                {

                    Data.Add((new Dictionary<string, object>() { { el.ToName, result[el.FromName] } }, el.To.Guid));
                }
            }
        }
    }
}

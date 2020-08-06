using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Workflows
{
    public class AskNumber<A> : WorkflowItem
    {
        public override Dictionary<string, Type> Inputs => new Dictionary<string, Type>(){{"Value", typeof(A)}};

        public override Dictionary<string, Type> Outputs => new Dictionary<string, Type>() { { "Value", typeof(A) }, {"Number", typeof(int) } };

        public override Dictionary<string, object> Compute(Dictionary<string, object> inputs)
        {
            Console.WriteLine("Podaj liczbe: ");
            int number = int.Parse(Console.ReadLine());
            var result = new Dictionary<string,object>(inputs);
            result.Add("Number", number);
            return result;
        }
    }
}

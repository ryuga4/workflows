using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Workflows
{
    public class RandomNumber : WorkflowItem
    {
        private static Random _randomGenerator;
        private static Random RandomGenerator
        {
            get
            {
                if (_randomGenerator == null) _randomGenerator = new Random();
                return _randomGenerator;
            }
        }
        public override Dictionary<string, Type> Inputs => new Dictionary<string, Type>() { { "Max", typeof(int) } };

        public override Dictionary<string, Type> Outputs => new Dictionary<string, Type>() { { "RandomInt", typeof(int) } };
        

        public override Dictionary<string, object> Compute(Dictionary<string, object> inputs)
        {
            var max = (int)inputs["Max"];
            return new Dictionary<string, object>() { { "RandomInt", RandomGenerator.Next() % max } };
        }
    }
}

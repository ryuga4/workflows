using System;
using System.Collections.Generic;
using System.Text;
using Workflows.Interfaces;

namespace Workflows.Workflows
{
    public class Divide : WorkflowItem
    {
        public override Dictionary<string, Type> Inputs => new Dictionary<string, Type> { { "Divisor", typeof(double) }, { "Dividend", typeof(double) } };
        public override Dictionary<string, Type> Outputs => new Dictionary<string, Type> { {"Quotient", typeof(double)}};



        public override Dictionary<string,object> Compute(Dictionary<string, object> inputs)
        {
            var dzielnik = (double)inputs["Divisor"];
            var dzielna = (double)inputs["Dividend"];

            return new Dictionary<string, object>() { { "Quotient", dzielna / dzielnik } };
        }
    }
}

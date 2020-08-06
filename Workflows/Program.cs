using System;
using Workflows.Engine;
using Workflows.Workflows;

namespace Workflows
{
    class Program
    {


        static void Main(string[] args)
        {
            var workflow = new Workflow<int>();

            var start = new Identity<int>();
            var divide = new Divide();
            var randomNumber1 = new RandomNumber();
            var randomNumber2 = new RandomNumber();
            var askNumber = new AskNumber<int>();

            var cast1 = new Cast<int, double>();
            var cast2 = new Cast<int, double>();
            var finish = new Finish();
            var print1 = new PrintAndReturn<double>();
            var print2 = new PrintAndReturn<double>();

            workflow.WorkflowItems.Add(start);
            workflow.WorkflowItems.Add(divide);
            workflow.WorkflowItems.Add(randomNumber1);
            workflow.WorkflowItems.Add(randomNumber2);
            workflow.WorkflowItems.Add(askNumber);
            workflow.WorkflowItems.Add(cast1);
            workflow.WorkflowItems.Add(cast2);
            workflow.WorkflowItems.Add(print1);
            workflow.WorkflowItems.Add(print2);
            workflow.WorkflowItems.Add(finish);

            workflow.AddWorkflow(start.Guid, randomNumber1.Guid, "Value", "Max");
            //workflow.AddWorkflow(start.Guid, randomNumber2.Guid, "Value", "Max");
            workflow.AddWorkflow(start.Guid, askNumber.Guid, "Value", "Value");



            workflow.AddWorkflow(randomNumber1.Guid, cast1.Guid, "RandomInt", "Value");
            //workflow.AddWorkflow(randomNumber2.Guid, cast2.Guid, "RandomInt", "Value");
            workflow.AddWorkflow(askNumber.Guid, cast2.Guid, "Number", "Value");

            workflow.AddWorkflow(cast1.Guid, print1.Guid, "Value", "Value");
            workflow.AddWorkflow(cast2.Guid, print2.Guid, "Value", "Value");


            workflow.AddWorkflow(print1.Guid, divide.Guid, "Value", "Dividend");
            workflow.AddWorkflow(print2.Guid, divide.Guid, "Value", "Divisor");
            workflow.AddWorkflow(divide.Guid, finish.Guid, "Quotient", "Finish");

            workflow.SetInit(start.Guid, "Value");

            var result = workflow.Compute(10);
            Console.WriteLine($"Result is {result["Finish"]}");
            Console.Read();
            
        }
    }
}

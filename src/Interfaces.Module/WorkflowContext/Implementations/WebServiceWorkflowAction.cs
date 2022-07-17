namespace Interfaces.Module.WorkflowContext.Implementations
{
    public class WebServiceWorkflowAction : IWorkflowAction
    {
        public void Execute()
        {
            Console.WriteLine("Calling web service...");
        }
    }
}

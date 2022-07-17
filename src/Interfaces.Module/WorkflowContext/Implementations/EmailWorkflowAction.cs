namespace Interfaces.Module.WorkflowContext.Implementations
{
    public class EmailWorkflowAction : IWorkflowAction
    {
        public void Execute()
        {
            Console.WriteLine("Sending email...");
        }
    }
}

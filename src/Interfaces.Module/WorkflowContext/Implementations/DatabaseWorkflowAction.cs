namespace Interfaces.Module.WorkflowContext.Implementations
{
    public class DatabaseWorkflowAction : IWorkflowAction
    {
        public void Execute()
        {
            Console.WriteLine("Updating database...");
        }
    }
}

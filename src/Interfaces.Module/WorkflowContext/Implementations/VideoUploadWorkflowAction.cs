namespace Interfaces.Module.WorkflowContext.Implementations
{
    public class VideoUploadWorkflowAction : IWorkflowAction
    {
        public void Execute()
        {
            Console.WriteLine("Uploading video...");
        }
    }
}

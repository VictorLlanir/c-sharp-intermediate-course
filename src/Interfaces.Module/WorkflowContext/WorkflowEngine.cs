namespace Interfaces.Module.WorkflowContext
{
    public sealed class WorkflowEngine
    {
        private readonly IEnumerable<IWorkflowAction> _actions;
        public WorkflowEngine(IEnumerable<IWorkflowAction> actions)
        {
            _actions = actions;
        }

        public void Run()
        {
            foreach (var action in _actions)
                action.Execute();
        }
    }
}

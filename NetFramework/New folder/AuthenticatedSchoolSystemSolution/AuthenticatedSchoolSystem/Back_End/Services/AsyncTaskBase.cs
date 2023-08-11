using System;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public abstract class AsyncTaskBase : ITask
    {
        public void Execute()
        {
            System.Threading.Tasks.Task task = ExecuteAsync();
            task.GetAwaiter().GetResult();
        }

        public virtual System.Threading.Tasks.Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
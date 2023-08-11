//using System;

//namespace SchoolSystem.Models
//{
//    public abstract class AsyncTaskBase : SchoolSystem.Services.ITask
//    {


//        public void Execute()
//        {
//            var task = this.ExecuteAsync();
//            task.GetAwaiter().GetResult();
//        }

//        public virtual System.Threading.Tasks.Task ExecuteAsync()
//        {
//            throw new NotImplementedException();
//        }


//    }
//}
using System;
using System.Threading.Tasks;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public class Task
    {
        public void Execute()
        {
            //do some work
        }

        internal Task<int> ContinueWith(Func<object, int> value)
        {
            throw new NotImplementedException();
        }
    }
}
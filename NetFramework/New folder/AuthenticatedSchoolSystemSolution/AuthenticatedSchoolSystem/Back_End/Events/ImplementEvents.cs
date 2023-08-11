using System.Threading;

namespace AuthenticatedSchoolSystem.Back_End.Events
{
    public class ImplementEvents : RoleEntryPoint
    {
        public override void OnRun()
        {
            Thread.Sleep(Timeout.Infinite);
        }

        public override bool OnStart()
        {
            return true;
        }

        public override bool OnStop()
        {
            return true;
        }
    }
}
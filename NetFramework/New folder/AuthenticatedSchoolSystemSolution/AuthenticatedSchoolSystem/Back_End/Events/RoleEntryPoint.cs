namespace AuthenticatedSchoolSystem.Back_End.Events
{
    public abstract class RoleEntryPoint
    {
        public virtual void OnRun()
        {
        }

        public virtual bool OnStart()
        {
            return true;
        }

        public virtual bool OnStop()
        {
            return true;
        }
    }
}
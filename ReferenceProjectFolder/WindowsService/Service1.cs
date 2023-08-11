using System.ServiceProcess;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Method intentionally left empty.
        }

        protected override void OnStop()
        {
            // Method intentionally left empty.
        }
    }
}
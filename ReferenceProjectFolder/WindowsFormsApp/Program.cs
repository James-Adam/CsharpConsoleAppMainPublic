using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateWebBrowser());
        }

        public static void CreateWinApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateWinApp());
        }

        public static void ManageCertificate()
        {
            Uri baseAddress = new Uri("http://phogistix.org/getavailability.svc");
            ServiceHost sh =
                new ServiceHost(typeof(PharmacologicalIService), baseAddress);

            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine, StoreName.My,
                X509FindType.FindBySubjectName, "phlogistix.com");
        }
    }
}
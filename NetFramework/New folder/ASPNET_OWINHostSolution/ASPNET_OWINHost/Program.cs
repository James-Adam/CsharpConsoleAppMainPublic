using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_OWINHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            using(WebApp.Start<Startup>(url:baseAddress))
            {
                Console.WriteLine($" hosted at {baseAddress} \n Press Enter to terminate....");
                Console.ReadLine();
            }
        }
    }
}

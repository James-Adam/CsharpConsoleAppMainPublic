using System;
using System.ServiceModel;

namespace WCF
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Uri[] uris = new Uri[1];
            const string address = "net.tcp://localhost:6565/MessageService";
            uris[0] = new Uri(address);
            IMessageService message = new MessageService();
            ServiceHost host = new ServiceHost(message, uris);
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            _ = host.AddServiceEndpoint(typeof(IMessageService), binding, "");
            host.Opened += Host_Opened;
            host.Open();
            _ = Console.ReadLine();
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("message service started");
        }

        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string[] GetMessages();
        }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class MessageService : IMessageService
        {
            public string[] GetMessages()
            {
                return new[] { "server1", "server2", "server3" };
            }
        }
    }
}
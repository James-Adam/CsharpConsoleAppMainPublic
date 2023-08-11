using System;
using System.Linq;
using System.ServiceModel;

namespace WCF.Client
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        string[] GetMessages();
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press any key to continue");
            _ = Console.ReadLine();

            const string uri = "net.tcp://localhost:6565/MessageService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            ChannelFactory<IMessageService> channel = new ChannelFactory<IMessageService>(binding);
            EndpointAddress endpoint = new EndpointAddress(uri);
            IMessageService proxy = channel.CreateChannel(endpoint);
            string[] result = proxy?.GetMessages();
            if (result != null)
            {
                result.ToList().ForEach(p => Console.WriteLine(p));
                _ = Console.ReadLine();
            }
        }
    }
}
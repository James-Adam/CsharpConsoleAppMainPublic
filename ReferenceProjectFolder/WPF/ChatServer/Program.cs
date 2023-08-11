// See https://aka.ms/new-console-template for more information

using ChatServer.Net.IO;
using System.Net;
using System.Net.Sockets;

namespace ChatServer;

internal static class Program
{
    private static List<Client>? _users;
    private static TcpListener? _listener;

    private static void Main(string[] args)
    {
        _users = new List<Client>();
        _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891);
        _listener.Start();

        while (true)
        {
            //var client = _listener.AcceptTcpClient();
            //Console.WriteLine("Client has connected");
            Client client = new(_listener.AcceptTcpClient());
            _users.Add(client);

            //broad cast connection to everyone on server
            BroadcastConnection();
        }
    }

    private static void BroadcastConnection()
    {
        foreach (Client user in _users)
        {
            foreach (Client usr in _users)
            {
                PacketBuilder broadcastPacket = new();
                broadcastPacket.WriteOpCode(1);
                broadcastPacket.WriteMessage(usr.Username);
                broadcastPacket.WriteMessage(usr.UID.ToString());
                _ = user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }
        }
    }

    public static void BroadcastMessage(string message)
    {
        foreach (Client user in _users)
        {
            PacketBuilder msgPacket = new();
            msgPacket.WriteOpCode(5);
            msgPacket.WriteMessage(message);
            _ = user.ClientSocket.Client.Send(msgPacket.GetPacketBytes());
        }
    }

    public static void BroadcastDisconnect(string uid)
    {
        Client? disconnectedUser = _users!.Where(x => x.UID.ToString() == uid).FirstOrDefault();
        _ = _users.Remove(disconnectedUser!);

        foreach (Client user in _users)
        {
            PacketBuilder broadcastPacket = new();
            broadcastPacket.WriteOpCode(10);
            broadcastPacket.WriteMessage(uid);
            _ = user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
        }

        BroadcastMessage($"[{disconnectedUser.Username}] Disconnected!");
    }
}
using ChatClient.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatClient.Net;

public class Server
{
    private readonly TcpClient _client;
    public PacketReader PacketReader;

    public Server()
    {
        _client = new TcpClient();
    }

    public event Action connectedEvent;

    public event Action msgRecievedEvent;

    public event Action userDisconnectEvent;

    public void ConnectToServer(string username)
    {
        if (!_client.Connected)
        {
            _client.Connect("127.0.0.1", 7891);
            PacketReader = new PacketReader(_client.GetStream());

            if (!string.IsNullOrEmpty(username))
            {
                PacketBuilder connectPacket = new();
                connectPacket.WriteOpCode(0);
                connectPacket.WriteMessage(username);
                _ = _client.Client.Send(connectPacket.GetPacketBytes());
            }

            ReadPackets();
        }
    }

    private void ReadPackets()
    {
        _ = Task.Run(() =>
        {
            while (true)
            {
                byte opcode = PacketReader.ReadByte();
                switch (opcode)
                {
                    case 1:
                        connectedEvent?.Invoke();
                        break;

                    case 5:
                        msgRecievedEvent?.Invoke();
                        break;

                    case 10:
                        userDisconnectEvent?.Invoke();
                        break;

                    default:
                        Console.WriteLine("ah yes...");
                        break;
                }
            }
        });
    }

    public void SendMessageToServer(string message)
    {
        PacketBuilder messagePacket = new();
        messagePacket.WriteOpCode(5);
        messagePacket.WriteMessage(message);
        _ = _client.Client.Send(messagePacket.GetPacketBytes());
    }
}
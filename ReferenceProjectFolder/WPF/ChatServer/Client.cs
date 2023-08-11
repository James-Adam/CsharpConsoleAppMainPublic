using ChatServer.Net.IO;
using System.Net.Sockets;

namespace ChatServer;

internal class Client
{
    private readonly PacketReader _packetReader;

    public Client(TcpClient client)
    {
        ClientSocket = client;
        UID = Guid.NewGuid();
        _packetReader = new PacketReader(ClientSocket.GetStream());

        byte opcode = _packetReader.ReadByte();
        Username = _packetReader.ReadMessage();

        Console.WriteLine($"[{DateTime.Now}]: Client has connected with the username: {Username}");

        _ = Task.Run(Process);
    }

    public string Username { get; set; }
    public Guid UID { get; set; }
    public TcpClient ClientSocket { get; set; }

    private void Process()
    {
        while (true)
        {
            try
            {
                byte opcode = _packetReader.ReadByte();
                switch (opcode)
                {
                    case 5:
                        string msg = _packetReader.ReadMessage();
                        Console.WriteLine($"[{DateTime.Now}]: Message recieved! {msg}");
                        Program.BroadcastMessage($"[{DateTime.Now}]:[{Username}]:{msg}");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"[{UID}]: Disconnected!");
                Program.BroadcastDisconnect(UID.ToString());
                ClientSocket.Close();
                break;
            }
        }
    }
}
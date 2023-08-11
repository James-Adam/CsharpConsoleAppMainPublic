﻿using System;
using System.IO;
using System.Text;

namespace ChatClient.Net.IO;

internal class PacketBuilder
{
    private readonly MemoryStream _ms;

    public PacketBuilder()
    {
        _ms = new MemoryStream();
    }

    public void WriteOpCode(byte opcode)
    {
        _ms.WriteByte(opcode);
    }

    public void WriteMessage(string msg) //writeString
    {
        int msgLength = msg.Length;
        _ms.Write(BitConverter.GetBytes(msgLength));
        _ms.Write(Encoding.ASCII.GetBytes(msg));
    }

    public byte[] GetPacketBytes()
    {
        return _ms.ToArray();
    }
}
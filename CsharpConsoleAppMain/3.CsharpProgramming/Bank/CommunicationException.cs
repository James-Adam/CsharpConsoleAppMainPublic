﻿using System.Runtime.Serialization;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

[Serializable]
public class CommunicationException : Exception
{
    public CommunicationException()
    {
    }

    public CommunicationException(string message) : base(message)
    {
    }

    public CommunicationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected CommunicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
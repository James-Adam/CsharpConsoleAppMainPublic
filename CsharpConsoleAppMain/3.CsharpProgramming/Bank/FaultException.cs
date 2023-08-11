using System.Runtime.Serialization;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

[Serializable]
public class FaultException<T> : Exception
{
    public FaultException()
    {
    }

    public FaultException(string message) : base(message)
    {
    }

    public FaultException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected FaultException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public object SpecificDetails { get; internal set; }
}
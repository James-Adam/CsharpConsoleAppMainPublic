using System.Runtime.Serialization;
using System.Text;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

[Serializable] // mark as serializable - incase of propagation
public class BankAccountException : Exception
{
    public BankAccountException()
    {
        transactionGUID = Guid.NewGuid();
    }

    public BankAccountException(string message) : base(message)
    {
        transactionGUID = Guid.NewGuid();
    } //Object Initializers

    public BankAccountException(string message, Exception inner) : base(message, inner)
    {
        transactionGUID = Guid.NewGuid();
    }

    public BankAccountException(string message, string Notes)
    {
        transactionGUID = Guid.NewGuid();
        transactionNotes = Notes;
    }

    //A constructor is needed for serialization when an exception propagates from a remoting server to the client
    protected BankAccountException(SerializationInfo info,
        StreamingContext context)
    {
    }

    public Guid transactionGUID { get; set; }
    public string transactionNotes { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new();
        _ = sb.AppendLine(base.ToString());
        _ = sb.AppendFormat("Transaction GUID: {0}\n", transactionGUID);
        _ = sb.AppendFormat("notes: {0}", transactionNotes);
        return sb.ToString();
    }
}
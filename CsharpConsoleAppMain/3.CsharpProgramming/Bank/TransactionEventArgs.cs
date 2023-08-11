namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public enum FailReason
{
    AccountFrozen,
    DisallowedOverdraw,
    AccountDBOffline,
    RestrictionByAccountHolder
}

public class TransactionEventArgs : EventArgs
{
    public TransactionEventArgs(string message, FailReason reason)
    {
        Message = message;
        WhyItFailed = reason;
    }

    public string Message { get; set; }
    public FailReason WhyItFailed { get; set; }
}
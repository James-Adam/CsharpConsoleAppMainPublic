namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class Check
{
    public decimal CheckAmount { get; internal set; }
    public string? Payee { get; internal set; }
    public DateTime DatePosted { get; internal set; }
    public string? AccountNumber { get; internal set; }
}
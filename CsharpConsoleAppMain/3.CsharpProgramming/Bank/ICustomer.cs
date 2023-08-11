namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public interface ICustomer
{
    public void CreateNote(string message);

    public int GetAccountNumber();
}
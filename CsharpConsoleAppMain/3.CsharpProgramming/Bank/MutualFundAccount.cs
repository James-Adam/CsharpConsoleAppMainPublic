namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class MutualFundAccount : BankAccount
{
    //anything not private should be available to mutual class from inheritance
    public MutualFundAccount(string name, decimal OpeningDeposit, MoneyInformation defaultMoneyType)
        : base(name, OpeningDeposit, defaultMoneyType)
    {
    }
}
namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

internal class SavingsAccount : BankAccount //Inheritance will search for base class method
{
    //Fields

    private readonly string accountNumber;

    //Method
    public SavingsAccount(string name, decimal OpeningDeposit, MoneyInformation defaultMoneyType)
        : base(name, OpeningDeposit, defaultMoneyType)
    {
        accountNumber = "1233445";
    }

    /// <summary>
    ///     Overrides the default AccountNumber implement with the GetNextAccountNumber() method result
    /// </summary>
    //Properties
    public override string AccountNumber => accountNumber;

    //public int AccountNumber { get; internal set; }

    //Methods
    public static void CheckForUsedAccountNumber(long proposedNumber)
    {
        // Method intentionally left empty.
    }

    //Methods
    public static void GetNextAccountNumber()
    {
        // Method intentionally left empty.
    }

    //Methods
    public void RequestPassbook(bool UserOwnsAccount, PassbookSize BookSize,
        PassbookTheme BookTheme = PassbookTheme.Professional)
    {
        if (!UserOwnsAccount)
        {
            //Request a get permission from account owner (i.e. Parent, gaurdian, ect.
        }

        Console.WriteLine("A{0} passbook will be ordered for {1} in a {2} theme...",
            BookSize, Name, BookTheme);
    }
}
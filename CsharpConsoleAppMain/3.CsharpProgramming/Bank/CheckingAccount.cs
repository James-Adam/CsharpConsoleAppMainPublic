namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class CheckingAccount : BankAccount
{
    //Method
    public CheckingAccount(string name, decimal openingDeposit, MoneyInformation defaultMoney,
        int startingCheckNumber, string accountNumber)
        : base(name, openingDeposit, defaultMoney)
    {
        AccountNumber = accountNumber;
        StartingCheckNumber = startingCheckNumber;
        RecentCheckCollection = new List<Check>();

        CreateMokeCheckCollection();
    }

    //Properties
    public List<Check> RecentCheckCollection { get; }

    //Properties
    public int StartingCheckNumber { get; protected set; }

    //Properties
    public Check this[decimal? checkAmount] =>
        (from r in RecentCheckCollection where r.CheckAmount == checkAmount select r).FirstOrDefault();

    public Check this[string? payee] //this = indicates indexer
    {
        get
        {
            payee = payee.Trim().ToLower();
            return (from r in RecentCheckCollection where r.Payee.Trim().ToLower() == payee select r)
                .FirstOrDefault();
        }
        set
        {
            Check? cToUpdate = (from r in RecentCheckCollection where r.Payee == payee select r).FirstOrDefault();
            cToUpdate = value;
        }
    }

    //Method

    //Method
    public override bool Withdraw(decimal amount, DateTime dateTime) //inheritance allows for override
    {
        Console.WriteLine("Extra work done by the Withdraw method in CheckingAccount...");
        return base.Withdraw(amount);
    }

    #region HelperCode

    public void CreateMokeCheckCollection()
    {
        Check c1 = new() { Payee = "CompanyA", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c2 = new() { Payee = "Maria Martinez", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c3 = new() { Payee = "CompanyC", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c4 = new() { Payee = "CompanyD", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c5 = new() { Payee = "CompanyE", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c6 = new() { Payee = "CompanyF", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c7 = new() { Payee = "CompanyG", AccountNumber = AccountNumber, DatePosted = DateTime.Now };
        Check c8 = new()
        { Payee = "CompanyH", AccountNumber = AccountNumber, DatePosted = DateTime.Now, CheckAmount = 99.95M };
        Check[] recent = { c1, c2, c3, c4, c5, c6, c7, c8 };
        RecentCheckCollection.AddRange(recent);
    }

    #endregion HelperCode
}
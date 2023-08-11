using System.Diagnostics;
using System.Security;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public delegate void TransactionFailed(object sender, TransactionEventArgs e);

public class BankAccount : ILogger, ICustomer, IComparable<BankAccount>
{
    public static readonly decimal MinimumRequiredOpeningDeposit = 50M;

    private readonly Random r = new();

    //Threading
    private readonly object thisLock = new();

    private decimal balance;

    //Demo of overload: Not practically usable, since we need to know their name ect... to open account
    public BankAccount(MoneyInformation defaultMoneyType) : this("Unknown", 50M, defaultMoneyType)
    {
        DefaultMoney = defaultMoneyType;
    }

    /// <summary>
    ///     Creates a valid BankAccount Instance
    /// </summary>
    /// <param name="name">Name information</param>
    /// <param name="OpeningDeposit">Must be greater than or equal to the Minimum Required Opening Deposit</param>
    /// <param name="defaultMoneyType">the Default Currency for presentation to user </param>
    /// <exception cref="System.ArgumentException"> if OpeningDepost is below MinimumRequiredOpeningDeposit</exception>
    public BankAccount(string name, decimal OpeningDeposit, MoneyInformation defaultMoneyType) //constructor method
    {
        Name = name;
        DefaultMoney = defaultMoneyType;

        balance = OpeningDeposit >= MinimumRequiredOpeningDeposit
            ? OpeningDeposit
            : throw new ArgumentException(string.Format("A minimum of {0:C} is required to open this account",
                MinimumRequiredOpeningDeposit));
    }

    public BankAccount(int initial)
    {
        balance = initial;
    }

    public virtual string AccountNumber { get; set; }

    public string Name { get; set; }

    public decimal Balance
    {
        get => balance;
        protected set //not private, protected is middle ground, inheriting classes can call but instances cannot
        {
            balance = value; //what ever variable: in this case it is decimal //implicitly declared
            if (balance < 0)
            {
                Status = AccountStatus.Overdrawn;
            }
        }
    }

    public AccountStatus Status { get; set; }

    public MoneyInformation DefaultMoney { get; set; }

    public string LogName { get; set; } = "Application";

    public string V { get; }

    public int CompareTo(BankAccount other)
    {
        return AccountNumber.CompareTo(other.AccountNumber);
    }

    void ICustomer.CreateNote(string message) //not allowed access modifier
    {
        Console.WriteLine("Note written by a customer...");
    }

    public int GetAccountNumber()
    {
        return 34;
    }

    string ILogger.LogName
    {
        get => LogName;
        set => LogName = value;
    }

    //void ILogger.WriteLogEntry(string entry, EntryType messageType)//not allowed access modifier
    //{
    //    Console.WriteLine("BankAccount has written Log Entry...");
    //}
    void ILogger.CreateNote(string message) //not allowed access modifier
    {
        Console.WriteLine("Note written by a the bank");
    }

    //custom exceptions

    void ILogger.WriteLogEntry(EventLogEntryType messageType, string EntryPointNotFoundException)
    {
        Console.WriteLine(EntryPointNotFoundException);
    }

    void ILogger.WriteLogEntry(string entry, EntryType messageType) //not allowed access modifier
    {
        Console.WriteLine(entry);
    }

    public void WriteLogEntry(string entry, EventLogEntryType messageType) //not allowed access modifier
    {
        try
        {
            if (!EventSourceExists("CSharpConsoleAppMain"))
            {
                EventLog.CreateEventSource("CSharpConsoleAppMain", LogName);
            }

            EventLog.WriteEntry("CSharpConsoleAppMain",
                entry,
                (System.Diagnostics.EventLogEntryType)messageType);
            Console.WriteLine("WriteLogEntry (Non-explicit version) wrote a Log Entry. Success!");
        }
        catch (Exception)
        {
            Console.WriteLine("WriteLogEntry (non-explicit version) attempted to write a Log Entry. Fail!");
        }
    }

    public event TransactionFailed OnTransactionFailed;

    // @NOTE: Constructors

    public virtual bool Withdraw(decimal amount) //, DateTime dateTime)
    {
        bool success = true;

        if (amount > 0 && amount < Balance)
        {
            Balance -= amount;
            success = true;
        }
        else if (amount > Balance)
        {
            OnTransactionFailed?.Invoke(this, new TransactionEventArgs(
                "You are not permitted to overdraw this account",
                FailReason.DisallowedOverdraw));
        }
        else
        {
            Console.WriteLine("YourWithdrawal of {0:C2} has been processed");
        }

        return success;
    }

    public virtual bool Withdraw(decimal amount, DateTime dateTime)
    {
        bool success = true;
        _ = Withdraw(amount);
        if (amount > 0 && amount < Balance)
        {
            Balance -= amount;
            success = true;
        }
        else if (amount > Balance)
        {
            OnTransactionFailed?.Invoke(this, new TransactionEventArgs(
                "You are not permitted to overdraw this account",
                FailReason.DisallowedOverdraw));
        }
        else
        {
            Console.WriteLine("YourWithdrawal of {0:C2} has been scheduled for {1}");
        }

        return success;
    }

    private int Withdraw(int amount) //, DateTime dateTime)
    {
        if (balance < 0)
        {
            throw new Exception("Negative Balance");
        }

        lock (thisLock)
        {
            if (balance >= amount)
            {
                Console.WriteLine("Activity on thread #{0}", Environment.CurrentManagedThreadId);
                Console.WriteLine("Balance before Withdrawal: " + balance);
                Console.WriteLine("Amount to withdraw     :-" + amount);
                balance -= amount;
                Console.WriteLine("Balance after Withdrawal : " + balance);
                Console.WriteLine("--");
                return amount;
            }

            return 0;
        }
    }

    public void DoTransactions()
    {
        for (int i = 0; i < 100; i++)
        {
            _ = Withdraw(r.Next(1, 100));
        }
    }

    //Threading End
    public virtual bool Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            return true;
        }

        BankAccountException ex = new("You cannot deposit a negative amount.",
            "the error occurred at " + DateTime.Now.ToString("hh:mm:ss:ffff"));
        throw ex;
    }

    //Fix
    public virtual bool Transfer(BankAccount from, BankAccount to, decimal amount)
    {
        return true;
    }

    //private bool EventSourceExists(string sourceName)
    //{
    //    return EventLog.SourceExists("Bank.BankApp");
    //}
    public void CreateNote(string message)
    {
        Console.WriteLine("Non-explicit interface implementation. Satisfied requirements for being called" +
                          "from objects of both ILogger and ICustomer (Unfortunately?)");
    }

    public void WriteLogEntry(EventLogEntryType messageType, string EntryPointNotFoundException)
    {
        Console.WriteLine(EntryPointNotFoundException);
    }

    private static bool EventSourceExists(string v)
    {
        bool exists = false;
        try
        {
            exists = EventLog.SourceExists("CSharpConsoleAppMain");
        }
        catch (SecurityException ex)
        {
            string message = ex.Message;

#if DEBUG
            //LogToLocalTextFile(message)
#endif
        }

        return exists;
    }

    public override bool Equals(object? obj)
    {
        return obj is not BankAccount
            ? throw new ArgumentException("Cannot compare this object to bank account")
            : AccountNumber == ((BankAccount)obj).AccountNumber;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
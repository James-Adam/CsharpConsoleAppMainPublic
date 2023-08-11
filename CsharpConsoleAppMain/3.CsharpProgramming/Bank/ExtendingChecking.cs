namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

//Note: No Inheritance
public static class ExtendingChecking
{
    public static long CustomTransactionCount(this CheckingAccount c, TimeSpan howFarBack)
    {
        long tranCount = 0;
        DateTime minDate = DateTime.Today.Subtract(howFarBack);
        foreach (Check ck in c.RecentCheckCollection)
        {
            if (ck.DatePosted >= minDate)
            {
                tranCount++;
            }
        }

        return tranCount;
    }
}
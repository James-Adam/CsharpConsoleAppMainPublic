namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

//Creating and using Enums
public enum AccountStatus
{
    OK = 0,
    Overdrawn = 1,
    Maintenance = 2,
    RestrictedFraudAlert = 3,
    SuspendedUserRequest = 4,
    SuspendedBankReview = 5,
    Other = 6
}
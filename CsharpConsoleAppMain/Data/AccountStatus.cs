namespace CsharpConsoleAppMain.Data;

public enum AccountStatus
{
    OK = 0,
    RestrictedFraudAlert = 1,
    Overdrawn = 2,
    Maintenance = 3,
    SuspendedUserRequest = 4,
    SuspendedBankReview = 5
}
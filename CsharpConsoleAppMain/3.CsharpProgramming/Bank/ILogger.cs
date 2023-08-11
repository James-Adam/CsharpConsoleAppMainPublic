namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public enum EntryType
{
    Information,
    Warning,
    Error,
    SuccessAudit,
    FailureAudit
}

public enum EventLogEntryType
{
    Information = 1,
    Warning = 2,
    Error = 4,
    SuccessAudit = 8,
    FailureAudit = 16
}

public interface ILogger
{
    string LogName { get; set; } //definition of property

    void WriteLogEntry(string entry, EntryType messageType);

    void WriteLogEntry(string entry, EventLogEntryType messageType);

    public void CreateNote(string message);

    public void WriteLogEntry(EventLogEntryType messageType, string EntryPointNotFoundException);
}
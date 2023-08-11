namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public enum ModType
{
    Created,
    Refactored,
    Bulletproofed,
    UntitTestChange,
    RegressionTestChange,
    Other
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
public class CodeTrackingAttribute : Attribute
{
    public CodeTrackingAttribute(string DeveloperName, string DateLastModified, ModType action)
    {
        coder = DeveloperName;
        dateinquestion = DateLastModified;
        whatwasdone = action;
    }

    public string coder { get; set; }
    public string dateinquestion { get; set; }
    public ModType whatwasdone { get; set; }
}
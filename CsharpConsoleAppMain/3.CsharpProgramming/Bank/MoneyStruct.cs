namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public struct MoneyInformation
{
    //Fields
    public char MoneySymbol;

    public string Name;

    //private field/property with validation
    private string _acronym;

    //Properties
    public string MoneyAcronym
    {
        get => _acronym;
        set => _acronym = value.Length >= 2 ? value[..3] : "";
    }

    //Methods
    public MoneyInformation(char MoneySymbol, string MoneyName)
    {
        this.MoneySymbol = MoneySymbol;
        Name = MoneyName;
        _acronym = Name[..3];
    }
}

//Structure
public struct MoneyInfo_NoConstructor
{
    //Fields
    public char MoneySymbol;

    public string MoneyAcronym;
    public string Name;
}
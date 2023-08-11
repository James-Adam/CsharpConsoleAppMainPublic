namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

//Indexers
internal class Employee
{
    public int EmpID { get; set; }
    public string? EmpName { get; set; }
    public List<Address>? Addresses { get; set; }

    //indexer double tab
    public Address this[int index, string st = ""] => Addresses[index];
}
namespace CsharpConsoleAppMain.CsharpProgramming.Bank;
//over loading methods

internal class clsA
{
    public virtual void Display() // not overridable.. have to use virtual
    {
        Console.WriteLine("In Display method of clsA called...");
    }
}

internal class clsB : clsA
{
    public override void Display() //use override keyword // use sealed for not overrideable
    {
        //base.Display();
        Console.WriteLine("In Display method of clsB called from clsA...");
    }
}

internal class clsC : clsB
{
    public override void Display()
    {
        Console.WriteLine("In Display method of clsC called from clsB...");
    }
}
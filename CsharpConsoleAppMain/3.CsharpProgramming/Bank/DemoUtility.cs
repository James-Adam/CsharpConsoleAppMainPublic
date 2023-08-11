namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

//StaticClassAndMembers
internal static class DemoUtility
{
    // use ctor for constructor
    private static readonly int inc;

    static DemoUtility()
    {
        inc = 1000;
    }

    public static void Display()
    {
        Console.WriteLine("Value of Inc is :{0}", inc);
    }
}
namespace CsharpConsoleAppMain.Data.Declan;

public static class DelegateLambdaAnonoymousFunctions
{
    private static PrintDelegate1? printVariable1; //declare variable

    private static PrintDelegate2? printVariable2; //declare variable

    private static IntDelegate? intVariable; //origionally PrintStuff

    private static void PrintMethod1() //method print stuff
    {
        Console.WriteLine("Hello - From Delegate 1");
    }

    private static void PrintMethod2() //method print stuff
    {
        Console.WriteLine(" World - From Delegate 2");
    }

    private static void IntMethod1(int a) //method print stuff
    {
        Console.WriteLine($"The number is {a}");
    }

    private static void IntMethod2(IntDelegate number) //origionally PrintStuff
    {
        number.Invoke(1);
    }

    public static void delegateLambdaAnonoymousFunctions()
    {
        printVariable1 = PrintMethod1; //Set
        printVariable1.Invoke(); //Invoke

        printVariable2 = PrintMethod2; //Set
        printVariable2.Invoke(); //Invoke

        intVariable = IntMethod1;
        intVariable.Invoke(1); //call for each method

        //WriteStuff(printStuff); //invokes second hello
        IntMethod2(x => Console.WriteLine("This comes from a lambda using x"));
        //IntMethod2(anonoymousFunc);
        //IntMethod2(anonoymousFunc);
        //IntMethod2(anonoymousFunc);

        _ = Console.ReadLine();
    }

    private delegate void PrintDelegate1(); // class PrintStuff { int a; }

    private delegate void PrintDelegate2(); // class PrintStuff { int a; }

    private delegate void IntDelegate(int a); // corresponds with x
}
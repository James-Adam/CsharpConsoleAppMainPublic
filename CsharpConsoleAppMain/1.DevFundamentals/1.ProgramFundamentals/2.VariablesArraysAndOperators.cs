namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals;

public static class VariablesArraysAndOperators
{
    public static void IntroToVarsAndConts()
    {
        //IntroToVarsAndConts

        Console.WriteLine("variables");
        //variables
        const int x = 10;
        Console.WriteLine(x);

        Console.WriteLine("\nConstants");
        //Constants
        const int y = 20;
        //y = y + 10;//will not assign value to constant object
        Console.WriteLine(y);

        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();
    }

    public static void IntroToVarDataTypes()
    {
        //IntroToVarDataTypes

        Console.WriteLine("int a = 10; //Integer");
        const int a = 10; //Integer
        Console.WriteLine(a);
        Console.WriteLine("Press Enter  continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("byte b = 10; //uses one single byte values 0-255");
        const byte b = 10; //uses one single byte values 0-255
        Console.WriteLine(b);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("short c = 10; // two bytes long values - 32768 up to 32767");
        const short c = 10; // two bytes long values - 32768 up to 32767
        Console.WriteLine(c);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("double d = 3.1415927; //8 bytes long decimal values");
        const double d = 3.1415927; //8 bytes long decimal values
        Console.WriteLine(d);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("long e = 2663699455236856; // 8 bytes long // extremely large numbers");
        const long e = 2663699455236856; // 8 bytes long // extremely large numbers
        Console.WriteLine(e);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("float f = 3426545; // int values, 4 bytes long");
        const float f = 3426545; // int values, 4 bytes long
        Console.WriteLine(f);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("char g = '\u0061'; //Unicode character");
        const char g = '\u0061'; //Unicode character
        Console.WriteLine(g);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine(
            "string h = 'James065'; //character string // numbers will not be treated as numbers standard");
        const string h = "James065"; //character string // numbers will not be treated as numbers standard
        Console.WriteLine(h);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("string i = '\tHello World'; //Tab escape char");
        const string i = "\tHello World"; //Tab escape char
        Console.WriteLine(i);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();

        Console.WriteLine("bool j = true; //on or off, used to test if");
        const bool j = true; //on or off, used to test if
        Console.WriteLine(j);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();
    }

    public static void IntroToArrays()
    {
        Console.WriteLine("Array Example 1");
        int[] i = { 1, 2, 3 };
        Console.WriteLine(i[2]);
        Console.WriteLine("Press Enter to continue!!\n");
        _ = Console.ReadKey();

        Console.WriteLine("Array Car Example ");
        string[] cars = { "Ford", "GM", "Toyota", "Honda" };
        Console.WriteLine(cars[2]);
        Console.WriteLine("Press Enter to continue!!");
        _ = Console.ReadKey();
    }

    public static void IntroToMathOps()
    {
        Console.WriteLine("Adding Operator");
        int a = 10;
        a += 10;
        Console.WriteLine(a);
        Console.WriteLine("Press Enter to continue!!\n");
        _ = Console.ReadKey();

        Console.WriteLine("x ++ Operator// increment");
        int b = 10;
        b++;
        Console.WriteLine(b);
        Console.WriteLine("Press Enter to continue!!\n");
        _ = Console.ReadKey();

        Console.WriteLine("x += Operator// increment");
        const int c = 10;
        Console.WriteLine(c);
        Console.WriteLine("Press Enter to continue!!\n");
        _ = Console.ReadKey();

        Console.WriteLine("Alt example");
        int d = 10;
        const int e = 15;
        d += e;
        Console.WriteLine(d);
        Console.WriteLine("Press Enter to continue!!\n");
        _ = Console.ReadKey();

        Console.WriteLine("+ - * / = < > ");
    }
}
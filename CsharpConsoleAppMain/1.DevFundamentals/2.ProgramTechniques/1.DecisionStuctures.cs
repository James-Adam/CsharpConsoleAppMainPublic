using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;

public static class DecisionStuctures
{
    public static void IntroToIfStatements()
    {
        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();

        const int d = 10;
        const int e = 11;
        if (d != e)
        {
            Console.WriteLine("d is not equal to e");
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToIfElseStatements()
    {
        Console.WriteLine("a is less than b");
        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToConditionalStatements()
    {
        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();

        Console.WriteLine(
            "<= -less than or equal to" +
            "\n>   - greater than" +
            "\n<   - less than" +
            "\n!=  - logical not" +
            "\n=   - asign a value" +
            "\n==  - check quality" +
            "\n&&  - and" +
            "\n||  - logical or");

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToSwitchStatements()
    {
        checkColor("yellow");
    }

    //intro to switch statement method 2
    private static void checkColor(string choice)
    {
        string carColor;
        switch (choice)
        {
            case "red":
                carColor = "red car";
                break;

            case "blue":
                carColor = "blue car";
                break;

            case "green":
                carColor = "green car";
                break;

            case "yellow":
                carColor = "yellow car";
                break;

            default:
                Console.WriteLine("Sorry, we do not have this color");
                return;
        }

        Console.WriteLine("{0}{1}", "We have a ", carColor);

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToWhileAndDoWhileLoops()
    {
        int i = 0;

        Console.WriteLine("Example 1: While Loop");
        while (i < 100)
        {
            Console.WriteLine(i);
            i++;
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2: DoWhile Loop");

        do
        {
            Console.WriteLine(i);
            i++;
        } while (i < 100);

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToForAndForEachLoops()
    {
        Console.WriteLine("Example 1: For Loop");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("{0}{1}", "i equals ", i);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2: ForEach Loop");
        int[] counter = { 2, 4, 6, 8, 10, 13, 16, 19, 22, 26, 30, 34 };
        foreach (int i in counter)
        {
            Console.WriteLine("{0}{1}", "i equals ", i);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void TryCatchFinallyStatements()
    {
        LoadFile();
    }

    //try-catch-finally statement
    private static void LoadFile()
    {
        StreamReader? infile = null;
        try
        {
            infile = File.OpenText("../../info.txt");
            Console.WriteLine(infile.ReadToEnd());
        }
        catch (FileNotFoundException notFound)
        {
            Console.WriteLine("Oops!!! {0}", notFound.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            infile?.Close();
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }
}
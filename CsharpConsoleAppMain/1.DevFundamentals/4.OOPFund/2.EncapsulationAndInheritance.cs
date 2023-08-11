namespace CsharpConsoleAppMain.DevFundamentals.OOPFund;

public static class EncapsulationAndInheritance
{
    public static void IntroToEncapsulation()
    {
        Console.WriteLine("public class person");
        Console.WriteLine("{");
        Console.WriteLine("\nprivate string name");
        Console.WriteLine("\npublicperson()");
        Console.WriteLine("{name = 'Naomi Miller';}");
        Console.WriteLine("\npublic Person(string m)");
        Console.WriteLine("{name = nm;");
        Console.WriteLine("\n//Method");
        Console.WriteLine("Public void setName(string name)");
        Console.WriteLine("{this.name = name;}");
        Console.WriteLine("}");

        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void AccessModifiers()
    {
        Console.WriteLine("\nAccessModifiers");
        Coords1 c1 = new()
        {
            X = 100,
            Y = 500
        };
        Coords1 c2 = c1;
        Console.WriteLine("\n" + c2.X + c2.Y);

        //public - access isnt restricted
        //private - access is restrice to the containing class
        //protected - access is restricted to the containing class and any class derived from the containing class
        //internal - access restricted to code in the same assembly (dll or exe)
        //protected internal - combination of protected and internal
        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();
    }

    ////Access Modifier struct within same class
    //private struct Coords
    //{
    //    public double X, Y;
    //}

    public static void InheratInOOP()
    {
        Console.WriteLine("\nInherateInOOP");

        Fruit5 apple = new("Macintosh", 0.5);
        Console.WriteLine("Kind: {0}, cost per dozon: {1}", apple.Kind5, apple.GetCost5());

        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void BaseAndDerivedClasses()
    {
        Console.WriteLine("\nBaseAndDerivedClasses");

        Apple6 apple6 = new("Macintosh", .6);
        Console.WriteLine("Type: {0}, cost per dozen: {1}/{2}", apple6.Kind, apple6.GetCost6(),
            Environment.NewLine);
        Orange6 orange6 = new("Velencia", .75);
        Console.WriteLine("Type: {0}, cost per dozen: {1}/{2}", orange6.Kind, orange6.GetCost6(),
            Environment.NewLine);

        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();
    }
}

//Access Modifier struct
public struct Coords1 //cannot  work with private

{
    public double X, Y;
}

//IneritInOOP class
internal class Apple //base class
{
    public string? Kind5 { get; protected set; }
    public double Cost5 { get; protected set; }
}

internal class Fruit5 : Apple //derived class
{
    public Fruit5(string k, double c)
    {
        Kind5 = k;
        Cost5 = c;
    }

    public string GetCost5()
    {
        return "$" + (Cost5 * 12);
    }
}

//Base and derived class
internal class Fruit6
{
    public string? Kind { get; protected set; }
    public double Cost { get; protected set; }
}

internal class Apple6 : Fruit6
{
    public Apple6(string k, double c)
    {
        Kind = k;
        Cost = c;
    }

    public string GetCost6()
    {
        return "$" + (Cost * 12);
    }
}

internal class Orange6 : Fruit6
{
    public Orange6(string k, double c)
    {
        Kind = k;
        Cost = c;
    }

    public string GetCost6()
    {
        return "$" + (Cost * 12);
    }
}
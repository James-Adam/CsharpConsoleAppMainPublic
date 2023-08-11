namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals;

public static class WorkingWithStrings
{
    public static void IntroToCshrpStrings()
    {
        const string x = "Hello" + " world";
        Console.WriteLine(x);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string a = "Hello";
        const string b = " World";
        string c = a + b;
        Console.WriteLine(c);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        string d = "Hello";
        const string e = " World";
        d += e;
        Console.WriteLine(d);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string f = "Hello";
        const string g = " World";
        const string h = "Hello";
        Console.WriteLine(f == g);
        Console.WriteLine(f == h);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string i = "Hello";
        string j = " H";
        j += "ello";
        Console.WriteLine(i == j);
        Console.WriteLine(i == (object)j);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        string k = "Hello";
        const string l = "World";
        k += l;
        Console.WriteLine(k[5]);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void StringLiterals()
    {
        const string a = "Hello";
        Console.WriteLine(a);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string b = "Hello\nWorld";
        Console.WriteLine(b);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string c = "\u0088";
        Console.WriteLine(c);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string d = "C:\\windows\\system\\";
        Console.WriteLine(d);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string e = @"C:\windows\system\"; //string litterals
        Console.WriteLine(e);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        const string f = @"He said ""hello""";
        Console.WriteLine(f);
    }

    public static void StringIndexing()
    {
        Console.WriteLine("Example 1");
        const string a = "The quick brown fox jumped over the lazy dogs.";
        Console.WriteLine(a.Length); // length of string, every single char in ""

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        const string b = "The quick brown fox jumped over the lazy dogs.";
        Console.WriteLine(b.Length); // length of string, every single char in ""
        int c = b.IndexOf("brown");
        Console.WriteLine(c);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        const string d = "The quick brown fox jumped over the lazy dogs.";
        Console.WriteLine(d.Length); // length of string, every single char in ""
        int e = d.IndexOfAny(new[] { 'e' });
        Console.WriteLine(e);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 4");
        const string f = "The quick brown fox jumped over the lazy dogs.";
        Console.WriteLine(d.Length); // length of string, every single char in ""
        int g = f.IndexOfAny(new[] { 'e', 'h' }); // will show the first instance
        Console.WriteLine(g);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 5");
        const string h = "The quick brown fox jumped over the lazy dogs.";
        Console.WriteLine(d.Length); // length of string, every single char in ""
        int i = h.LastIndexOf("the");
        Console.WriteLine(i);
    }

    public static void UsingCharAndStrings()
    {
        Console.WriteLine("Example 1");
        const string x = "The quick brown fox jumped over the lazy dogs.";
        char[] y = new char[5];
        y[0] = x[4];
        y[1] = x[5];
        y[2] = x[6];
        y[3] = x[7];
        y[4] = x[8];
        string z = new(y);
        Console.WriteLine(z);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void WorkingWithSubstrings()
    {
        Console.WriteLine("Example 1");
        const string a = "The quick brown fox jumped over the lazy dogs.";
        string b = a[..3]; //Get first 3 characters
        Console.WriteLine("Substring : {0}", b);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2");
        const string c = "The quick brown fox jumped over the lazy dogs.";
        string d = c.Substring(4, 5); //get 5 char at index 4
        Console.WriteLine("Substring : {0}", d);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        const string e = "The quick brown fox jumped over the lazy dogs.";
        string f = e[4..]; //starts at index 4 and show remaining
        Console.WriteLine("Substring : {0}", f);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 4");
        const string g = "The quick brown fox jumped over the lazy dogs.";
        string h = g[4..^6]; // start @ 4, ommit last 10
        Console.WriteLine("Substring : {0}", h);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 5");
        const string i = "The quick brown fox jumped over the lazy dogs.";
        string j = "";
        try
        {
            j = i[-1..];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Substring : {0}", j);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 6");
        const string k = "The quick brown fox jumped over the lazy dogs.";
        string l = "";
        try
        {
            l = k[..100];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Substring : {0}", l);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void ConvertStringToNum()
    {
        Console.WriteLine("Example 1 using parse");
        const string a = "10";
        const string b = "20";
        //converting strings to integers
        int a1 = int.Parse(a);
        int b1 = int.Parse(b);
        int c = a1 + b1;
        Console.WriteLine(a + " + " + b + " = " + c);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2 using tryparse");
        const string d = "10";
        const string e = "20";
        //converting strings to integers
        _ = int.TryParse(d, out int d1);
        _ = int.TryParse(e, out int e1);
        int f = d1 + e1;
        Console.WriteLine(d + " + " + e + " = " + f);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3 using convert");
        const string g = "10";
        const string h = "20";
        //converting strings to integers
        int g1 = Convert.ToInt32(g);
        int h1 = Convert.ToInt32(h);

        int i = g1 + h1;
        Console.WriteLine(g + " + " + h + " = " + i);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }
}
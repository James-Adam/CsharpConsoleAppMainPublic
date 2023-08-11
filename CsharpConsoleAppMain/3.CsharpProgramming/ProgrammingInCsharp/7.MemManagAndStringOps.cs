using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class MemManagAndStringOps
{
    public static void ObjectLifetimeGarbageCollection()
    {
        ManagingGarbageCollection();
    }

    #region helper code for ObjectLifetimeGarbageCollection

    private static void ManagingGarbageCollection()
    {
        Invoice? break_room = new("Sundries");
        break_room.Show_Disposal_Fee_As_Of_Now();
        break_room.Increase_Running_Disposal_Fee();
        break_room.Show_Disposal_Fee_As_Of_Now();
        Invoice? human_resources = new("Office Supplies");
        human_resources.Show_Disposal_Fee_As_Of_Now();
        human_resources.Increase_Running_Disposal_Fee();
        human_resources.Show_Disposal_Fee_As_Of_Now();
        GC.AddMemoryPressure(int.MaxValue);
        GC.WaitForPendingFinalizers();

        Invoice? need_new_pc = new("Electronics");
        need_new_pc.Show_Disposal_Fee_As_Of_Now();
        need_new_pc.Increase_Running_Disposal_Fee();
        need_new_pc.Show_Disposal_Fee_As_Of_Now();
        GC.RemoveMemoryPressure(int.MaxValue);
    }

    #endregion helper code for ObjectLifetimeGarbageCollection

    public static void ManagingUnmanagedResources()
    {
        DbManager obj = new();
        try
        {
            obj.DoActualOperation();
        }
        finally
        {
            obj.Dispose();
        }
    }

    public static void Destructor()
    {
        EmployeeDemo? objEmp = new()
        {
            EmpName = "John"
        };
        Console.WriteLine(objEmp.EmpName);
        GC.WaitForPendingFinalizers();
        GC.Collect();

        _ = Console.ReadKey();

        Console.WriteLine("Advance to see the IL...");
        _ = Console.ReadKey();

        const string path = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\ildasm.exe";
        _ = new Process();
        _ = new ProcessStartInfo
        {
            FileName = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\ildasm.exe",
            Arguments = "\"" + Assembly.GetExecutingAssembly().Location + "\""
        };
        _ = Process.Start(path);
    }

    public static void UsingBlock()
    {
        using (DbManager objMgr = new())
        {
            objMgr.Display();
        }

        Console.WriteLine("ObjMgr is Disposed");
    }

    public static void StringbuilderClass()
    {
        UsingStringBuilder();
        Console.WriteLine();
        Console.WriteLine("Done!");
        _ = Console.ReadKey();
    }

    public static void StringReaderAndWriter()
    {
        string hipsterLorenIpsumText =
            "Lorem eos est duis tempor takimata, no diam et ad ipsum tincidunt voluptua liber, iriure nibh te erat labore eos\n";
        hipsterLorenIpsumText +=
            "Sanctus aliquyam est kasd facilisis commodo tempor accusam at dolor. elitr tempor iusto invidunt eirmod no aliquyam amet et, invidunt duis magna congue consetetur minim at .sed dolores est molestie elitr aliquam et. stet sit at dolore diam sea rebum\n";
        hipsterLorenIpsumText += "Ut erat sanctus ea .minim amet, eirmod consetetur clita volutpat.";

        Console.WriteLine("Original text:\n{0}", hipsterLorenIpsumText);

        //From hipsterLorenIpsumText, create a continuous paragraph with the sentence proofreeding mark('^') between each sentance

        string WeMadeALine, weMadeAParagraph = null;
        StringReader aStringReader = new(hipsterLorenIpsumText);
        while (true)
        {
            WeMadeALine = aStringReader.ReadLine();
            if (WeMadeALine != null)
            {
                weMadeAParagraph += WeMadeALine + "^";
            }
            else
            {
                weMadeAParagraph += "\n";
                break;
            }
        }

        Console.WriteLine();
        Console.Clear();
        Console.WriteLine("Modified text: {0}", weMadeAParagraph);

        //Re-create hipsterLorenIpsumText from weMadeAParagraph
        int intCharacter;
        char convertedCharacter;
        StringWriter aStringWriter = new();
        aStringReader = new StringReader(weMadeAParagraph);
        while (true)
        {
            intCharacter = aStringReader.Read();

            //check for the end of the string
            //before converting to a character
            if (intCharacter == -1)
            {
                break;
            }

            convertedCharacter = Convert.ToChar(intCharacter);
            if (intCharacter == '.')
            {
                aStringWriter.Write(".\n\n");

                _ = aStringReader.Read();
                _ = aStringReader.Read();
            }
            else
            {
                aStringWriter.Write(convertedCharacter);
            }
        }

        Console.WriteLine("\nOriginal text:\n\n{0}", aStringWriter);

        if (!SeeMore())
        {
            return;
        }

        //Just a little delay so we can see it happen
        int counter = 0;

        string states = "Ohio, ";
        states += "Florida, ";
        states += "Texas, ";
        states += "New York, ";
        states += "Atlanta, ";
        states += "Miami, ";
        states += "New Jersey, ";
        states += "Boston, ";

        string allStates = string.Join(",", states);
        StringReader srStates = new(allStates);
        char[] lastSetOfCharacters = new char[20];
        while (srStates.Peek() != -1)
        {
            _ = srStates.ReadBlock(lastSetOfCharacters, 0, 20);
            Console.WriteLine(new string(lastSetOfCharacters));
            counter++;
            if (counter % 3 == 0)
            {
                counter = 0;
                Thread.Sleep(1000);
                Console.WriteLine();
            }

            aStringReader.Dispose();
            aStringWriter.Dispose();
        }
    }

    public static void BasicStringMethods()
    {
        Random r = new();
        string stringToUse =
            "I'm going to make him an offer he can't turn into refuse"; //quotes[r.Next(0, quotes.Count - 1)]; //
        Console.WriteLine("Demo string '{0}'", stringToUse);

        //CONTAINS
        Console.WriteLine();
        Console.WriteLine("Determine if there is an exclamation point(i.e'!')--");
        bool success = stringToUse.Contains("!");
        string yesOrNo = success ? "does" : "does not";
        Console.WriteLine("The string {0} contains an exclamation point", yesOrNo);

        //ENDS WITH
        Console.WriteLine();
        Console.WriteLine("Does it end with the word 'you'?--");
        success = stringToUse.EndsWith("you");
        yesOrNo = success ? "does" : "does not";
        Console.WriteLine("The string {0} end with 'you'", yesOrNo);

        //INDEXOFANY AND SUBSTRING
        Console.WriteLine();
        Console.WriteLine("Find the first non-capitalized vowel--");

        //INDEX is the same except this one accepts CHAR[], and INDEX accepts only a (single) string
        int firstVowel = stringToUse.IndexOfAny(new[] { 'a', 'e', 'i', 'o', 'u' }, 0);
        Console.WriteLine("The First vowel is the character at index {0}", firstVowel);

        //Show that the letter and the characters around it....
        int startSubstring = firstVowel > 3 ? firstVowel - 3 : 0;
        Console.WriteLine("its in this part of the string...{0}..", stringToUse.Substring(startSubstring, 11));

        //PADDING A STRING
        string fixedLengthStringOfNumbers = r.Next(10000, 100000).ToString();
        Console.WriteLine();
        Console.WriteLine("Take a numeric string and pad left with zeroes:");
        fixedLengthStringOfNumbers = fixedLengthStringOfNumbers.PadLeft(13, '0');
        Console.WriteLine("Padded number string with leading zeroes: {0}", fixedLengthStringOfNumbers);
        Console.WriteLine("Take a short alpha string and pad right with dots...");
        string shortString = stringToUse.Substring(4, 10);

        //STRING FORMATTING
        Console.WriteLine($"Original string: {0 - 25}");
        Console.WriteLine("Padded string : {0,-25}", shortString.PadRight(25, '.'));

        stringToUse = stringToUse.Replace('e', 'E');
        Console.WriteLine("Replace all the 'e' with 'E'...");
        Console.WriteLine(stringToUse);
    }

    public static void SearchingInStrings()
    {
        Random r = new();
        const string stringToUse = "I'm not going to fake it anymore!"; //qoutes[r.Next(0, quotes.Count - 1)];
        Console.WriteLine("Demo string: '{0}", stringToUse);

        Console.WriteLine("Lets search for vowels and eventually remove them..");

        List<int> vowelsToRemove = new();
        for (int i = stringToUse.Length - 1; i >= 0; i--)
        {
            switch (stringToUse[i])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    vowelsToRemove.Add(i);
                    break;
            }
        }

        Console.Write("Positions of vowels:");
        foreach (int v in vowelsToRemove)
        {
            Console.Write("-{0}", v);
        }

        Console.WriteLine();

        //Do the removal
        string
            orgininalStringToUse =
                stringToUse; //I'm not going to fake it anymore! //Louise, I think this is the beginning of a beautiful relationship.
        foreach (int vowel in vowelsToRemove)
        {
            orgininalStringToUse = stringToUse.Remove(vowel, 1);
        }

        Console.WriteLine("New string: {0}", stringToUse);

        Console.WriteLine("We can also do this with some char/string manipulation");
        List<char> letters = orgininalStringToUse.ToList();
        _ = letters.RemoveAll(TakeOutTheVowels);

        Console.WriteLine("The new word is {0}(No vowels)", new string(letters.ToArray<char>()));
    }

    public static void StringInterpolation()
    {
        //Syntax : { <interpolatedExpression>[,<alignment>][:<formatString>]}

        const int i = 100, j = 200;
        _ = "sum of " + i + "+" + j + "is " + (i + j);

        _ = string.Format("sum of {0} + {1} is {2}", i, j, i + j);

        string result = $"sum of {i} + {j} is {i + j}";

        //Alignment

        Console.WriteLine($"|{"Left",7}|{"Right",-7}|".Length);

        Console.WriteLine($"|{"Left",7}|{"Right",-10}|");
        _ = Console.ReadKey();

        //formatting
        Console.WriteLine($"{DateTime.Now:HH:mm}");
        Console.WriteLine(result);
        _ = Console.ReadKey();
    }

    public static void StringFormatting()
    {
        Random r = new();
        //Make this some random day in the past...
        DateTime whatDayIsIt = DateTime.Now.AddYears(-r.Next(2, 6));
        //Formats for dates
        Console.WriteLine("With default ToString(): {0}", whatDayIsIt);
        Console.WriteLine("With ToLongDateString(): {0}", whatDayIsIt.ToLongDateString());
        Console.WriteLine("With ToShortTimeString(): {0}", whatDayIsIt.ToShortTimeString());
        Console.WriteLine("With custom date formatting in the ToString(__) call: {0}",
            whatDayIsIt.ToString("yyyy-MM-dd, hh-mm-ss tt"));
        Console.WriteLine("With custom time formatting: {0}", whatDayIsIt.ToString("hh:mm:ss:fff"));
        Console.WriteLine("With formatting in the placeholder: {0:MM/dd/yyy}", whatDayIsIt);
        Console.WriteLine("With formatting in the placeholder for time: {0:hh:mm:ss:fff}", whatDayIsIt);

        const double BigDecimalNumber = 9876543.210123456;
        Console.WriteLine("Currency: {0:C}", BigDecimalNumber);
        Console.WriteLine("Decimal Format with 10 digits: {0:D10}", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine("Decimal Format with 15 digits: {0:D15}", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine("Exponential: {0:E2}", BigDecimalNumber);
        Console.WriteLine("Fixed Point: {0:F3}", BigDecimalNumber);
        Console.WriteLine("Percent: {0:P2}", BigDecimalNumber);
        Console.WriteLine("Hex: {0:X}", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine();
    }

    public static void CultureSpecificStringManipulation()
    {
        CultureInfo[] cultures =
        {
            new("en-US"),
            new("fr-FR"),
            new("it-IT"),
            new("de-DE"),
            new("en-GB")
        };

        Random r = new();
        //Make this some random day in the past...
        DateTime whatDayIsIt = DateTime.Now.AddYears(-r.Next(730, 2190));

        foreach (CultureInfo c in cultures)
        {
            Console.WriteLine(string.Format(c, "Today is {0} in {1}. \nThe number 75.234 shows up as {2:N4}\n\n",
                whatDayIsIt, c.DisplayName, 75, 234));
        }

        const double BigDecimalNumber = 9876543.210123456;

        //Formats for collumn width
        Console.WriteLine("{0,-30}{1,15:C}", "Currency:", BigDecimalNumber);
        Console.WriteLine("{0,-30}{1,15:D10}", "Decimal Format with 10 digits:", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine("{0,-30}{1,15:D15}", "Decimal Format with 15 digits:", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine("{0,-30}{1,15:E2}", "Exponential: ", BigDecimalNumber);
        Console.WriteLine("{0,-30}{1,15:F3}", "Fixed Point:", BigDecimalNumber);
        Console.WriteLine("{0,-30}{1,15:P2}", "Percent:", BigDecimalNumber);
        Console.WriteLine("{0,-30}{1,15:X}", "Hex:", Convert.ToInt64(BigDecimalNumber));
        Console.WriteLine();
    }

    #region Helper code for StringbuilderClass

    private static void UsingStringBuilder()
    {
        const int stringLength = 30;
        const int stringConcatLoops = 5000;

        Stopwatch sw = new();
        int i;

        string sourceString = new('Z', stringLength);
        string destinationString = "";

        sw.Start();
        for (i = 0; i < stringConcatLoops; i++)
        {
            destinationString += sourceString;
        }

        sw.Stop();
        Console.WriteLine("Concatenation took {0} seconds", sw.Elapsed.TotalSeconds);

        sw.Reset();
        sw.Start();

        StringBuilder sb = new((int)(stringLength * stringConcatLoops * 1.1));
        for (i = 0; i < stringConcatLoops; i++)
        {
            _ = sb.Append(sourceString);
        }

        _ = sb.ToString();
        sw.Stop();
        Console.WriteLine("String Builder Took {0} seconds", sw.Elapsed.TotalSeconds);
        Console.WriteLine();

        if (!SeeMore())
        {
            return;
        }

        StringBuilder sbOther = new();

        _ = sbOther.AppendFormat("You can also use {0} to insert a formatted string, like this:\n{1}",
            "StringBuilder", DateTime.Now.ToString("\\H:hh \\M:mm \\S:ss tt"));

        //Go to the next line this way
        _ = sbOther.AppendLine();

        _ = sbOther.AppendLine("...or insert a carriage return / line feed...");
        _ = sbOther.Append("More text here!");

        //or this way
        _ = sbOther.Append("\n");
        _ = sbOther.Append("...And then more text if you want");

        Console.WriteLine(sbOther);
    }

    public static bool SeeMore()
    {
        Console.WriteLine("Would you like to see more? Y/N: ");
        _ = Console.ReadLine();

        return true;
    }

    #endregion Helper code for StringbuilderClass

    #region helper for SearchingInStrings

    private static readonly List<char> vowels =
        new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }.ToList();

    private static bool TakeOutTheVowels(char c)
    {
        return vowels.IndexOf(c) > -1;
    }

    #endregion helper for SearchingInStrings
}

#region helper code for ObjectLifetimeGarbageCollection

public class Invoice
{
    private readonly string description;
    private double invoiceAmount;

    public Invoice(string InvoiceDescription)
    {
        description = InvoiceDescription;
        Console.WriteLine("Invoice Created: {0}", InvoiceDescription);
        //Read the current Amount from a file. this could be a date.
        invoiceAmount = double.Parse(File.ReadAllText(
            @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\Memory\InvoiceMetrics.txt"));
    }

    public void Show_Disposal_Fee_As_Of_Now()
    {
        Console.WriteLine("Materials disposal charge running total added to by item '{0}' now {1:C}", description,
            invoiceAmount);
    }

    public void Increase_Running_Disposal_Fee()
    {
        invoiceAmount *= 125;
    }

    ~Invoice()
    {
        //Write the current salary to a file.This could be a database.
        File.WriteAllText("InvoiceMetrics.txt", invoiceAmount.ToString());
        Console.WriteLine("Invoice finalized: {0}", description);
    }
}

#endregion helper code for ObjectLifetimeGarbageCollection

#region Helper code for ManagingUnmanagedResources // UsingBlock

public class DbManager : IDisposable
{
    private readonly SqlConnection cn;
    private bool disposedValue;

    public DbManager()
    {
        cn = new SqlConnection();
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Console.WriteLine("Dispose Method called...");
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    //Using Block method
    public void Display()
    {
        Console.WriteLine("Display Method called...");
    }

    public void DoActualOperation()
    {
        // Method intentionally left empty.
    }

    //public void Dispose()
    //{
    //    cn.Dispose();

    //    GC.SuppressFinalize(this);
    //}

    ////IMPLEMEMNT THE CONSTUCTOR
    //~DbManager()
    //{
    //    cn.Dispose();
    //}

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                cn.Dispose();
            }
            // TODO: dispose managed state (managed objects)
            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~DbManager()
    {
        cn.Dispose();
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(false);
    }
}

#endregion Helper code for ManagingUnmanagedResources // UsingBlock

#region Helper code for Destructor

internal class EmployeeDemo
{
    public int EmpID { get; set; }
    public string? EmpName { get; set; }

    ~EmployeeDemo()
    {
        Console.WriteLine("Destructor Called...");
    }
}

#endregion Helper code for Destructor
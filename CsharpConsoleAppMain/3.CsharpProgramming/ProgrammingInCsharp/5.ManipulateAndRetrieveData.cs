//using ConsoleAppNetFramework;

using CsharpConsoleAppMain.CsharpProgramming.Bank;
using CsharpConsoleAppMain.CsharpProgramming.ConsumingData;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class ManipulateAndRetrieveData
{
    public static void StoredProceduresInAModel()
    {
        //Use the stored procedure by querying through the model
        ADOclass.Program.StoredProceduresInAModel();
    }

    public static void QuerySintaxVsMethodSyntax()
    {
        ADOclass.Program.QuerySyntaxVsMethodSyntax();
    }

    public static void WorkingWithTheWhereLinqOperator()
    {
        ADOclass.Program.WorkingWithTheWhereLinqOperator();
    }

    public static void SelectVsSelectManyLinqOperator()
    {
        ADOclass.Program.SelectVsSelectManyLinqOperator();
    }

    public static void QueryDataUsingOperators()
    {
        ADOclass.Program.QueryDataUsingOperators();
    }

    public static void ConsumingDataLinqToXmlDataPart1()
    {
        //ADOClass.Program.ConsumingDataLinqToXmlDataPart1();
        Console.WriteLine("\nLINQ2XML_ReadAll\n");
        LINQ2XML_ReadAll();
        _ = Console.ReadKey();

        Console.WriteLine("\nLINQ2XML_ReadOne\n");
        LINQ2XML_ReadOne();
        _ = Console.ReadKey();

        Console.WriteLine("\nLINQ2XML_ReadFilteredSet\n");
        LINQ2XML_ReadFilteredSet();
        _ = Console.ReadKey();
    }

    public static void ConsumingDataLinqToXmlDataPart2()
    {
        //ADOClass.Program.ConsumingDataLinqToXmlDataPart2();
        Console.WriteLine("\nLINQ2XML_ReadParticularAttribute\n");
        LINQ2XML_ReadParticularAttribute();
        _ = Console.ReadKey();

        //Console.WriteLine("\nLINQ2XML_ReadMultipleElementsOfOneName\n");
        //LINQ2XML_ReadMultipleElementsOfOneName();
        //Console.ReadKey();

        //Console.WriteLine("\nSerializingWithJson\n");
        //SerializingWithJson();
        //Console.ReadKey();

        //Console.WriteLine("\nLSerializingWithXml\n");
        //SerializingWithXml();
        //Console.ReadKey();
    }

    #region Helper code for ConsumingDataLinqToXmlDataPart2

    public static void LINQ2XML_ReadParticularAttribute()
    {
        XElement xelement =
            XElement.Load(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\Persons.xml");
        IEnumerable<XElement> mainPhone = from phone in xelement.Elements("Person")
                                          where phone.Element("Phone").Attribute("Type").Value.ToString() == "Main"
                                          select phone;
        Console.WriteLine("Main Phone Numbers:");
        foreach (XElement xEle in mainPhone)
        {
            Console.WriteLine(xEle.Element("Phone").Value);
        }
    }

    //public static void LINQ2XML_ReadMultipleElementsOfOneName()
    //{
    //}
    //public static void OnesAndZeroes()
    //{
    //}
    //public static void SerializingWithJson()
    //{
    //}
    //public static void SerializingWithXml()
    //{
    //}

    #endregion Helper code for ConsumingDataLinqToXmlDataPart2

    public static void ConsumingDataXmlSerialization()
    {
        //ADOClass.Program.ConsumingDataXmlSerialization();
        XMLSerializer.XMLSerializerMain();
    }

    public static void ConsumingDataJsonSerialization()
    {
        //ADOClass.Program.ConsumingDataJsonSerialization();
        JSONSerializer.JSONSerializerMain();
    }

    public static void ConsumingDataBinarySerialization()
    {
        //ADOClass.Program.ConsumingDataBinarySerialization();
        BinarySerializer.BinarySerializerMain();
    }

    public static void TypedVsNonTypedCollections()
    {
        //ADOClass.Program.TypedVsNonTypedCollections();

        //rrayList vs. List<>
        ArrayList arrayList = new()
        {
            new USState("Delaware", "DE", 1),
            new USState("Pennsylvania", "PA", 2),
            new USState("New Jersey", "NJ", 3),

            //its all going well until
            "Goergia"
        };

        //its all good until we try to enumerate it..
        try
        {
            foreach (USState s in arrayList)
            {
                Console.WriteLine("{0} is state {1}", s.StateName, s.OrderIntoTheUnion);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Enumeration interrupted: {0}", ex.Message);
        }

        //so thats where generics come in
        _ = new
            //so thats where generics come in
            List<USState>()
            {
                new("Delaware", "DE", 1),
                new("Pennsylvania", "PA", 2),
                new("Washington", "WS", 3)
            };

        //We wont get away with this
        //originalArrayListAsATypedList.Add("Goergia");
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
        //fix console.Writeline
    }

    public static void ManagingCollections()
    {
        //ADOClass.Program.ManagingCollections();

        //Adding Different names, but all have a ability to add item
        //removing: Remove by index or sometimes by item
        InitializeAddAndRemove();
    }

    #region Helper code for ManagingCollections

    public static void InitializeAddAndRemove()
    {
        List<string> sampleList = CreateTypes.SetupInMemoryCollection();

        //Constructor: Pass another ICollection instance and youll have same initial capacity
        ArrayList al = new();
        IEnumerable<string> firstThree = (from s in sampleList select s).Take(3);
        al.AddRange(firstThree.ToArray());
        Console.WriteLine("Capacity: {0}", al.Capacity);

        //Add something and read the capacity now...
        _ = al.Add("Cascadia");
        Console.WriteLine("After adding Capacity+1 - items:{0}, Capacity: {1}", al.Count, al.Capacity);

        //Trim it back if you do not need it
        al.TrimToSize();
        Console.WriteLine("After Trimming - items: {0}, Capacity: {1}", al.Count, al.Capacity);

        ////Or with Hashtable you can set the capacity when intializing allong with LoadFactor
        //Hashtable ht = new Hashtable(3, 0.5F);
        //for (int i = 0, j = 0; j < 1; i += 2, j++)
        //{
        //    ht.Add(i, sampleList[i]);
        //}

        ////lets see what we did
        //CreateTypes.HashableEnumerator<Hashtable>(ht, "Contents of the Hashtable:");

        CreateTypes.TheyCallMeTheEnumerator(al, "Before Removing Alabama");
        //Removing an item
        if (al.Contains("Alabama"))
        {
            al.Remove("Alabama");
        }

        CreateTypes.TheyCallMeTheEnumerator(al, "After Removing Alabama");
        //Take out only the last item
        al.RemoveAt(al.Count - 1);
        CreateTypes.TheyCallMeTheEnumerator(al, "After removing the last item");

        //For creating generic
        //fix console.Writeline
    }

    //private static List<string> SetupInMemoryCollection()
    //{
    //    throw new NotImplementedException();
    //}

    #endregion Helper code for ManagingCollections

    public static void UsingTheDictionaryObject()
    {
        //ADOClass.Program.UsingTheDictionaryObject();
        Dictionary<string, DateTime> holidays = new()
        {
            //Add some elements
            { "boxing day", new DateTime(DateTime.Now.Year, 12, 26) },
            { "us independence", new DateTime(DateTime.Now.Year, 7, 14) },
            { "argentina san martin day", new DateTime(DateTime.Now.Year, 8, 18) },
            { "intl. programmer's day", new DateTime(DateTime.Now.Year, 9, 13) }
        };

        CreateTypes.TheyCallMeTheEnumerator(holidays, "Some initial dictionary objects:", false);
        foreach (KeyValuePair<string, DateTime> i in holidays)
        {
            Console.WriteLine(i.Key, i.Value);
        }

        Console.WriteLine("\nAttempting to add a duplicate key");
        //the add method throws an exception if the new key is already in the dictionary.

        try
        {
            holidays.Add("boxing day", new DateTime(DateTime.Now.Year, 12, 26));
        }
        catch (ArgumentException)
        {
            Console.WriteLine("an element key =\"boxing day\" already exists.");
        }

        Console.WriteLine("ContainsKey checks if key exists before insert");
        //containskey can be used to test key before inserting them
        if (!holidays.ContainsKey("boxing day"))
        {
            holidays.Add("someones birthday probably", new DateTime(DateTime.Now.Year, 2, 29));
            Console.WriteLine("Value added for key = \"someones birthday probably\":{0}",
                holidays["someones birthday probably"]);
        }

        _ = new
            DateTime();
        if (holidays.TryGetValue("boxing day", out DateTime value))
        {
            Console.WriteLine("For key = \"boxing day\", value = {0}", value.Month + "/" + value.Day);
        }
        else
        {
            Console.WriteLine("key = \"boxing day\" is not found.");
        }

        //fix console.Writeline
    }

    public static void UsingTheListObject()
    {
        //ADOClass.Program.UsingTheListObject();

        //ArrayList al = new ArrayList();
        //al.Add("a string");
        //al.Add(13);
        //al.Add((int)DateTime.Now.Year);

        List<string> localsportsteams = new();

        Console.WriteLine("\nCapacity: {0}", localsportsteams.Capacity);

        localsportsteams.Add("Browns");
        localsportsteams.Add("Indians");
        localsportsteams.Add("Cavaliers");
        localsportsteams.Add("Barons");
        localsportsteams.Add("Force");

        Console.WriteLine();
        CreateTypes.TheyCallMeTheEnumerator(localsportsteams, "Teams in the List<string>", false);
        Console.WriteLine();

        Console.WriteLine("\nCapacity: {0}", localsportsteams.Capacity);
        Console.WriteLine("Count: {0}", localsportsteams.Count);

        Console.WriteLine("\nContains(\"Browns\"): {0}", localsportsteams.Contains("Browns"));

        Console.WriteLine("\nInsert(2, \"Crunch\")");
        localsportsteams.Insert(2, "Crunch");

        Console.WriteLine();
        Console.WriteLine("After adding a new team");

        Console.WriteLine("\nlocalsportsteams[3]: {0}", localsportsteams[3]);

        Console.WriteLine("\nRemove(\"Force\")");
        _ = localsportsteams.Remove("Force");

        Console.WriteLine();
        CreateTypes.TheyCallMeTheEnumerator(localsportsteams, "After Removing by item name:");

        Console.WriteLine();
        Console.WriteLine("Trim the excess Capacity:");
        localsportsteams.TrimExcess();
        Console.WriteLine("\nTrimExcess()");
        Console.WriteLine("Capacity: {0}", localsportsteams.Capacity);
        Console.WriteLine("Count: {0}", localsportsteams.Count);
        Console.WriteLine("List<T>.Clear reduces Count to 0 but does not touch Capacity");

        //Do a binary search
        localsportsteams.Sort();
        Console.WriteLine();
        Console.WriteLine("BinarySearch and Insert \"Eagles\":");
        int Index = localsportsteams.BinarySearch("Eagles");
        if (Index < 0)
        {
            localsportsteams.Insert(~Index, "Eagles");
        }

        Console.WriteLine();
        Console.WriteLine("BinarySearch and Insert \"Packers\":");
        Index = localsportsteams.BinarySearch("Packers");
        if (Index < 0)
        {
            localsportsteams.Insert(~Index, "Packers");
        }

        CreateTypes.TheyCallMeTheEnumerator(localsportsteams, "New listing of all teams:");

        //fix console.Writeline
    }

    public static void UsingTheQueeObject()
    {
        //ADOClass.Program.UsingTheQueeObject();
        Queue<string> numbers = new();
        numbers.Enqueue("1 - one");
        numbers.Enqueue("2 - two");
        numbers.Enqueue("3 - three");
        numbers.Enqueue("4 - four");
        numbers.Enqueue("5 - five");

        CreateTypes.TheyCallMeTheEnumerator(numbers, "Members of the Queue", false);

        Queue<string> copyTheNumbersQueue = new(numbers.ToArray());
        CreateTypes.TheyCallMeTheEnumerator(numbers, "Contents of the first copy:");

        string[] anotherArray = new string[numbers.Count * 2];
        numbers.CopyTo(anotherArray, numbers.Count);

        Queue<string> anotherQueueCopy = new(anotherArray);

        CreateTypes.TheyCallMeTheEnumerator(copyTheNumbersQueue, "First Copy...");
        CreateTypes.TheyCallMeTheEnumerator(anotherQueueCopy,
            "Contents of the second copy, with duplicates and nulls:");

        Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}", copyTheNumbersQueue.Contains("four"));

        Console.WriteLine("\nqueueCopy.Clear()");
        copyTheNumbersQueue.Clear();
        Console.WriteLine("\nqueueCopy.Count = {0}", copyTheNumbersQueue.Count);

        Console.WriteLine("Peaking and Dequeuing:");
        if (numbers.Count > 0)
        {
            Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            Console.WriteLine("Peek at the next item that we will dequeue: {0}", numbers.Peek());
            Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());
        }
    }

    public static void ImplementingDotNetInterfaces()
    {
        //ADOClass.Program.ImplementingDotNetInterfaces();
        CollectionInterfaces();
    }

    #region Helper code for ImplementingDotNetInterfaces

    public static void CollectionInterfaces()
    {
        //Create a collection of BankAccount Objects
        List<BankAccount> accounts = new();
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "123", Name = "Customer1" });
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "123", Name = "Customer10" });
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "456", Name = "Customer2" });
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "789", Name = "Customer3" });
        //accounts.Add(new BankAccount("CDDollars") { AccountNumber = "012", Name = "Customer4" });
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "345", Name = "Customer5" });
        //accounts.Add(new BankAccount("USDollars") { AccountNumber = "678", Name = "Customer6" });
        //accounts.Add(new BankAccount("Pesos") { AccountNumber = "901", Name = "Customer7" });
        //accounts.Add(new BankAccount("Pounds") { AccountNumber = "234", Name = "Customer9" });
        //accounts.Add(new BankAccount("USDollar") { AccountNumber = "567", Name = "Customer9" });
        //accounts.Add(new BankAccount("Euros") { AccountNumber = "123", Name = "Customer1" });

        CreateTypes.TheyCallMeTheEnumerator(accounts, "Original BankAccounts collection:", false);
        accounts.Sort();
        CreateTypes.TheyCallMeTheEnumerator(accounts, "Sorted BankAccounts collection:", false);
    }

    #endregion Helper code for ImplementingDotNetInterfaces

    #region Helper code for ConsumingDataLinqToXmlDataPart1

    public static void LINQ2XML_ReadAll()
    {
        XElement xelement =
            XElement.Load(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\Persons.xml");
        IEnumerable<XElement> persons = xelement.Elements();
        //Read the entire XML
        foreach (XElement person in persons)
        {
            Console.WriteLine(person);
        }
    }

    public static void LINQ2XML_ReadOne()
    {
        XElement xelement =
            XElement.Load(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\Persons.xml");
        IEnumerable<XElement> persons = xelement.Elements();
        Console.WriteLine("Person Names:");
        foreach (XElement person in persons)
        {
            Console.WriteLine(person.Element("Name").Value);
        }
    }

    public static void LINQ2XML_ReadFilteredSet()
    {
        XElement xelement =
            XElement.Load(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\Persons.xml");
        IEnumerable<XElement> name = from n in xelement.Elements("Person")
                                     where n.Element("Current").Value.ToString() == "Yes"
                                     select n;
        Console.WriteLine("Current Persons:");
        foreach (XElement element in name)
        {
            Console.WriteLine(element);
        }
    }

    #endregion Helper code for ConsumingDataLinqToXmlDataPart1
}

public class USState
{
    public USState(string v1, string v2, int v3)
    {
        StateName = v1;
        State = v2;
        OrderIntoTheUnion = v3;
    }

    public object StateName { get; internal set; }

    public string State { get; }
    public int OrderIntoTheUnion { get; internal set; }
}
using CsharpConsoleAppMain.CsharpProgramming.Bank;
using IronPython.Hosting;
using System.Collections;
using System.Globalization;
using System.IO;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class CreateTypes
{
    private static readonly TransactionFailed? c_OnTransactionFailed;

    public static void CreatingStrctures()
    {
        Console.WriteLine("CreatingStrctures");

        MoneyInformation money = new('$', "Mexican Pesos")
        {
            //money.Name="Mexican Pesos";
            //money.MoneySymbol = '$';
            MoneyAcronym = "PES"
        };

        //struct with no non-default constructor
        MoneyInfo_NoConstructor yen;
        yen.Name = "Japenese Yen";
        yen.MoneySymbol = '¥';
        yen.MoneyAcronym = "YEN";

        MoneyInfo_NoConstructor peso = new()
        {
            Name = "Mexican Peso", //OBJECT innitializer
            MoneyAcronym = "PES",
            MoneySymbol = '$'
        };
        _ = new
            BankAccount(money);

        Console.WriteLine("Before assignment, {0}'s symbol is {1}.", yen.Name, yen.MoneySymbol);
        yen = peso;

        Console.WriteLine($"After assignment, the symbol is {yen.MoneySymbol}");
        peso.MoneyAcronym = "MEX";

        Console.WriteLine("Mexican Peso changed its abbreviation. Does it affect Yen object?");
        Console.WriteLine("Now Yen's abbreviation is {0}...", yen.MoneyAcronym);
        Console.WriteLine("...While Mex's abbreviation is {0}", peso.MoneyAcronym);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void CreatingAndUsingEnums()
    {
        Console.WriteLine("CreatingAndUsingEnums");

        const AccountStatus aStatus = AccountStatus.OK;
        Console.WriteLine("aStatus value:{0}", aStatus);

        const AccountStatus fromNumber = (AccountStatus)5;
        Console.WriteLine("Enum derived from number: {0}", fromNumber);

        const int MabeItsDefined = 14;
        AccountStatus a;
        if (Enum.IsDefined(typeof(AccountStatus), MabeItsDefined))
        {
            a = (AccountStatus)MabeItsDefined;
            Console.WriteLine("The Value is {0}. The enum member that maps to it is {1}",
                (int)a, a.ToString());
        }
        else
        {
            Console.WriteLine("Sorry, {0} is not an acceptable value for this enum type.", MabeItsDefined);
        }

        Console.WriteLine("List of all members of the AccountStatus enum:");
        foreach (string s in Enum.GetNames(typeof(AccountStatus)))
        {
            Console.WriteLine("--{0}", s);
        }

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void CreatingAndUsingClasses()
    {
        Console.WriteLine("CreatingAndUsingClasses");
        _ = new
            EmptyClass();

        CheckingAccount checkingAccount = new("Dana Powell", 50M, new MoneyInformation('$', "US Dollars"), 1500,
            "1234567890123");

        //Check check1 = c[(decimal)2.394]; // operator
        //Check check2 = c["Dan"];

        //int[] arr = new int[] { 2, 3, 4 };
        //int a = arr[1];

        Console.WriteLine(checkingAccount.Name);
        Console.WriteLine(checkingAccount.Balance);
        Console.WriteLine(checkingAccount.DefaultMoney);
        Console.WriteLine(checkingAccount.StartingCheckNumber);
        Console.WriteLine(checkingAccount.AccountNumber);
        foreach (Check check in checkingAccount.RecentCheckCollection)
        {
            Console.WriteLine(check.Payee);
        }

        checkingAccount.OnTransactionFailed += c_OnTransactionFailed;

        _ = checkingAccount.Withdraw(150);
        _ = checkingAccount.Withdraw(150, DateTime.Today.AddDays(7));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void UsingConstructors()
    {
        Console.WriteLine("UsingConstructors");

        //mutual fund account
        MutualFundAccount mutualFundAccount = new("Dana Powell", 50M, new MoneyInformation('$', "US Dollars"));

        Console.WriteLine(mutualFundAccount.Name);
        Console.WriteLine(mutualFundAccount.Balance);
        Console.WriteLine(mutualFundAccount.DefaultMoney);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void UsingOperationalAndNamedParameters()
    {
        Console.WriteLine("UsingOperationalAndNamedParameters");

        MoneyInformation c = new('$', "US Dollars");

        SavingsAccount sa = new("William", 100M, c);
        Console.WriteLine("Assigned account number: {0}", sa.AccountNumber);

        sa.RequestPassbook(true, PassbookSize.Large);
        sa.RequestPassbook(true, PassbookSize.Small, PassbookTheme.Geometric);
        sa.RequestPassbook(BookTheme: PassbookTheme.SportsAffiliation, UserOwnsAccount: true,
            BookSize: PassbookSize.Mini);

        sa.WriteLogEntry(EventLogEntryType.Information,
            "Something happened!");

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void StaticClassAndMembers()
    {
        //can not inherit static classes
        Console.WriteLine("StaticClassAndMembers");

        DemoUtility.Display();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ExtensionMethods()
    {
        //searched from inner most namespace to outer most namespace using intellisense
        Console.WriteLine("ExtensionMethods");

        const char ch = 'a';
        _ = ch.IsValidEmpIDChar();
        _ = ch.IsValidEmpIDChar();

        const string st = "";
        const double d = 10;
        _ = st.IsValidEmpIDChar();
        _ = d.IsValidEmpIDChar();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void Indexers()
    {
        // indexers are properties that accept arguments
        //accessing certian members which are IEnumerable
        Console.WriteLine("Indexers");

        Employee objEmp = new() { EmpID = 100, EmpName = "James", Addresses = new List<Address>() };
        objEmp.Addresses.Add(new Address { AddressLine = "Addressline" });

        Console.WriteLine(objEmp[0, "street Address"].AddressLine);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void OverloadingVsOverriding()
    {
        Console.WriteLine("OverloadingVsOverriding");

        Console.WriteLine("\nThree Pillars of OOP");
        Console.WriteLine("\nEncapsulation:  First Pillar:   Modularity");
        Console.WriteLine("Inheritance:     Second Pillar:  Reusability");
        Console.WriteLine("Polymorphism:    Third Pillar:   Extensibility");
        Console.WriteLine("Polymorphism:    Static:         Method and Operator overloading");
        Console.WriteLine("Polymorphism:    Dynamic:        RunTime");
        Console.WriteLine("\nPress any key to continue.");
        _ = Console.ReadKey();
    }

    public static void OverloadingMethods()
    {
        Console.WriteLine("OverloadingMethods");
        _ = new
            clsMath();
        Console.WriteLine(clsMath.Add(100, 200));
        _ = new
            clsMath();
        Console.WriteLine(clsMath.Add(100.50, 200.50));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void OverridingMethods()
    {
        Console.WriteLine("OverridingMethods");

        clsA objA = new();
        clsB objB = new();
        clsC objC = new();
        objA.Display();
        objB.Display();
        objC.Display();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void Generics()
    {
        Console.WriteLine("Generics");
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void GenericType()
    {
        Console.WriteLine("GenericType");
        //code is absolutely the same, only difference is the type
        Console.WriteLine(Min(100, 200));
        Console.WriteLine(Min(100.50, 200.50));
        Console.WriteLine(Min("Demo", "value"));
        Console.WriteLine(Min<string>("1000", "value"));

        //List<string> listNames = new List<string>(); //assing to level class

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    //GenericType
    //static int Min(int a, int b)
    //{
    //    if (a < b)
    //    {
    //        return a;
    //    }
    //    else
    //        return b;
    //}
    //static double Min(double a, double b)
    //{
    //    if (a < b)
    //    {
    //        return a;
    //    }
    //    else
    //        return b;
    //}
    //static IComparable Min(IComparable a, IComparable b)
    //{
    //    if (a.CompareTo(b)<0)
    //    {
    //        return a;
    //    }
    //    else
    //        return b;
    //}

    //replacement for intirety of code above
    private static T Min<T>(T a, T b) where T : IComparable<T> // assign to level method
    {
        return a.CompareTo(b) < 0 ? a : b;
    }

    public static void UsingGenericMethods()
    {
        Console.WriteLine("UsingGenericMethods");

        //set up some strings to use in the Hasbtable object
        List<string> sampleList = SetupInMemoryCollection();

        //or with Hashtable you can set capacity when initializing,
        //along with LoadFactor
        Hashtable ht = new(4, 0.5F);
        for (int i = 0, j = 0; j < 4; i += 5, j++)
        {
            ht.Add(i, sampleList[i]);
        }

        //lets see what we did
        HashableEnumerator(ht, "Contents of the Hashtable:");

        Dictionary<int, int> nums = new()
        {
            { 1, 10 },
            { 2, 20 },
            { 3, 30 }
        };

        HashableEnumerator(nums, "Dictionary<int,int>:");

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void HashableEnumerator<T>(T coll, string message = "") where T : IDictionary
    {
        ResetConsole(message);
        Console.WriteLine("Contents of {0}", coll.GetType());
        Console.WriteLine();

        foreach (DictionaryEntry item in coll)
        {
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
        }

        Console.WriteLine();
    }

    public static void TheyCallMeTheEnumerator(IEnumerable coll, string message = "", bool WaitForReadKey = true)
    {
        ResetConsole(message, WaitForReadKey);
        Console.WriteLine("Contents of {0}", coll.GetType());
        Console.WriteLine();
        if (coll.GetType() == typeof(Dictionary<string, DateTime>))
        {
            Dictionary<string, DateTime> dates = (Dictionary<string, DateTime>)coll;
            foreach (KeyValuePair<string, DateTime> date in dates)
            {
                Console.WriteLine("{0} is on {1}{2} this year", date.Key, date.Value.Month, date.Value.Day);
            }
        }
        else
        {
            foreach (object? item in coll)
            {
                Console.WriteLine(item);
            }
        }

        Console.WriteLine();
    }

    private static void ResetConsole(string message, bool waitForReadKey = true)
    {
        if (waitForReadKey)
        {
            _ = Console.ReadKey();
        }

        Console.WriteLine(message);
        Console.WriteLine();
    }

    public static List<string> SetupInMemoryCollection()
    {
        return new List<string>();
    }

    public static void ConvertingValueTypes()
    {
        Console.WriteLine("ConvertingValueTypes");

        int smallNumber = 1000;
        long largeNumber = smallNumber;
        Console.WriteLine("The value of largeNumber is {0}", largeNumber);
        _ = Convert.ToInt32("9999");

        bool DidItWork = int.TryParse("9999", out int X);
        Console.WriteLine("TryParse returned '{0}'. X's value is {1}", DidItWork, X);

        DidItWork = int.TryParse("should be a number but isn't", out X);
        Console.WriteLine("TryParse returned '{0}'. X's value is {1}", DidItWork, X);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ConvertingRefTypes()
    {
        Console.WriteLine("ConvertingRefTypes");

        MoneyInformation currency = new('$', "US Dollars");
        BankAccount bank = new(currency);
        SavingsAccount? savings;
        try
        {
            savings = (SavingsAccount)bank;
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("Could not convert correctly: {0}", ex);
        }

        savings = bank as SavingsAccount;
        string result = savings != null
            ? "the variable was cast correctly"
            : "the variable was not cast, but at least we avoided the exception";
        Console.WriteLine(result);

        SavingsAccount savingsAccount = new("Bob", 50M, new MoneyInformation('$', "US Dollar"));
        //bankAccount.RequestPassbook(); //bot derived from bank account

        Console.WriteLine(savingsAccount.Name);
        Console.WriteLine(savingsAccount.Balance);
        Console.WriteLine(savingsAccount.DefaultMoney);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void BoxingAndUnboxing()
    {
        Console.WriteLine("BoxingAndUnboxing");

        const int i = 100;
        int j = i;

        object o = j; //Boxing - stack heap.. happens internally as program executes
        int k = (int)o; //Unboxing
        Console.WriteLine("Boxing " + o);
        Console.WriteLine("UnBoxing " + k);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void UsingTheDynamicRuntime()
    {
        Console.WriteLine("UsingTheDynamicRuntime");

        //Console.WriteLine("Testing Python");
        //dynamic python = Python.CreateRuntime().UseFile(@"MemberDB.py");

        //dynamic pythonMember = python.GetNewMember(100, "Chen", "(555) 555-5555");
        //dynamic pythonMemberDB = python.GetMemberDB();

        //pythonMemberDB.storeMember(pythonMember);
        //pythonMember = python.GetNewMember(101, "Zachary", "(777) 777-7777");
        //pythonMemberDB.storeMember(pythonMember);

        //Console.WriteLine("{0}", pythonMemberDB);
        //Console.ReadKey();
        //output x 28
        //ID: 100   Name: Chen      Telephone:  (555) 555-5555

        //python file script - partial
        //        class Member :

        //def_init_(self, id, name, telephone):
        //self.memberID = id
        //self.memberName = name
        //self.memberPhone = telephone

        //def_str_(self):
        //return str.format("ID: {0}\tName: {1}\tTelephone: {2}",
        //    self.memberID, self.memberName, self.memberPhone)

        //class MemberDB :

        //def_init_(self):
        //self.memberDatabase = {}

        //def storeMember(self, member):
        //self.memberDatabase[member.memberID] = member

        //def getMember(self, id) :
        //return self.memberDatabase[id]

        //def_str_(self):
        //list = "Member\n"

        //instance of python engine
        Microsoft.Scripting.Hosting.ScriptEngine engine = Python.CreateEngine();
        //reading code from file
        Microsoft.Scripting.Hosting.ScriptSource source =
            engine.CreateScriptSourceFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "calculator.py"));
        Microsoft.Scripting.Hosting.ScriptScope scope = engine.CreateScope();
        //executing script in scope

        source.Execute(scope);
        dynamic classCalculator = scope.GetVariable("calculator");
        //initializing class
        dynamic calculatorInstance = engine.Operations.CreateInstance(classCalculator);
        Console.WriteLine("From Iron Python");
        Console.WriteLine("5 + 10 = {0}", calculatorInstance.add(5, 10));
        Console.WriteLine("5++ = {0}", calculatorInstance.increment(5));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void UsingIConvertable()
    {
        Console.WriteLine("UsingIConvertable");

        PseudoPoint p = new(4, 7);

        showObjectInformation(p);
        showObjectInformation(Convert.ToBoolean(p));
        showObjectInformation(Convert.ToDecimal(p));
        showObjectInformation(Convert.ToString(p));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    private static void showObjectInformation(object test_obj)
    {
        TypeCode typeCode = Type.GetTypeCode(test_obj.GetType());
        switch (typeCode)
        {
            case TypeCode.Boolean:
                Console.WriteLine("Boolean: {0}", test_obj);
                break;

            case TypeCode.Decimal:
                Console.WriteLine("Decimal: {0}", test_obj);
                break;

            case TypeCode.String:
                Console.WriteLine("String: {0}", test_obj);
                break;
        }
    }

    public static void UsingIFormattable()
    {
        Console.WriteLine("UsingIFormattable");

        //Formatting in a Writeline statement
        _ = string.Format("{0} happened on {1} and it was {2}", "A Thing", DateTime.Now, true);

        Numerics num1 = new(99);
        Console.WriteLine("{0:T}(Two) = {0:U} (Three) = {0:V} (Four)\n", num1);

        num1 = new Numerics(-40);
        Console.WriteLine(string.Format(CultureInfo.CurrentCulture,
            "{0:G} (General) = {0:U} (Three) = {0:V} (Four)", num1));

        Console.WriteLine("With fr-FR culture infoL");
        Console.WriteLine(string.Format(new CultureInfo("fr-FR"),
            "{0:G} (General) = {0:W} (Four) = {0:U} (Three)\n", num1));

        num1 = new Numerics(32);
        Console.WriteLine("{0} (General) = {1} (Two) = {2} (Three)\n",
            num1.ToString("T"),
            num1.ToString("U"),
            num1.ToString("V"));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }
}
using CsharpConsoleAppMain.CsharpProgramming.Bank;
using System.Collections;
using System.Reflection;
using ILogger = CsharpConsoleAppMain.CsharpProgramming.Bank.ILogger;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class UsingTypes
{
    public static void EncapsulationDefiningProperties()
    {
        Console.WriteLine("EncapsulationDefiningProperties");
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void AutoImplementProperties()
    {
        Console.WriteLine("AutoImplementProperties");
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void AccessModifiers()
    {
        Console.WriteLine("AccessModifiers");
        Console.WriteLine("Public \tprivate \tinternal");

        clbAssembly.clsMath obj = new();
        Console.WriteLine(obj.pub_i);
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void EncapsulationExplicitInterfaces()
    {
        Console.WriteLine("EncapsulationExplicitInterfaces");

        MoneyInformation curr = new('$', "US Dollars") { MoneyAcronym = "USD" };
        BankAccount ba = new(curr);

        string isLogger = ba is ILogger
            ? "BankAccount implements ILogger"
            : "BankAccount does not implement ILogger";
        Console.WriteLine(isLogger);

        //Call interface methods
        //note the intelisense: its the BankAccount.WriteEntry method
        ba.LogName = "Application";
        ba.WriteLogEntry("your application has run something!", EventLogEntryType.Information);

        //Call Interface methods explicitly
        //point up the difference between the type of Variable and the type of Memory it  points to
        ILogger explicitBA = ba;
        explicitBA.WriteLogEntry("This is through the interface", EntryType.Information);

        //...or...
        ((ILogger)ba).WriteLogEntry("This is cast through the interface", EntryType.Information);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ClassHierarchyInterfaces()
    {
        Console.WriteLine("ClassHierarchyInterfaces");
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ConsumingTypesInheritance()
    {
        Console.WriteLine("ConsumingTypesInheritance");

        //Base clase instance
        BankAccount bankAccount = new("BankAccount Instance", 50M, new MoneyInformation('$', "US Dollar"));
        _ = bankAccount.Deposit(1500M);
        _ = bankAccount.Withdraw(1000M);
        Console.WriteLine(bankAccount.Balance);

        //Derived class instance
        SavingsAccount savingsAccount = new("SavingsAccount instance", 5000M, new MoneyInformation('€', "EURO"));
        Console.WriteLine(savingsAccount.AccountNumber);

        //Override demonstration
        CheckingAccount checkingAccount = new("CheckingAccount instance", 100M,
            new MoneyInformation('$', "US Dollar"), 100, "3456789012345");
        // this should call the override in CheckingAccount
        _ = checkingAccount.Withdraw(99M);
        _ = checkingAccount.Deposit(100M);
        _ = checkingAccount.Withdraw(99M, DateTime.Today.AddDays(3));
        Console.WriteLine("Checking account balance {0}, date {1}", checkingAccount.Balance,
            DateTime.Today.AddDays(3));

        //Polymorphism
        BankAccount bank = savingsAccount;
        //Show stepping into BankAccount method, because no override in Savings Account
        Console.WriteLine(bank.Balance);
        bool success = savingsAccount.Withdraw(100M); //bankAccount
        if (success)
        {
            Console.WriteLine("New balance in {0} is {1}", bank,
                bank.Balance); //C for currency for your region {1:C}
        }

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ClassHierarchyIndexers()
    {
        Console.WriteLine("ClassHierarchyIndexers");

        MoneyInformation currency = new('$', "US Dollars") { MoneyAcronym = "USD" };
        CheckingAccount c = new("User 1", 50M, currency, 1500, "1234567890123");

        //Retrieve the check by Payee name
        Check cGet = c["Maria Martinez"];
        Console.WriteLine("Check retrieved: {0}-{1}-{2}", cGet.Payee, cGet.CheckAmount,
            cGet.DatePosted.ToString(""));

        //Retrieve the check by Amount
        Check cGetByAmount = c[99.95M];
        Console.WriteLine("Check {0} for {1:C} retrieved", cGetByAmount.Payee, cGetByAmount.CheckAmount);

        //change a retrieved check
        cGet.DatePosted = cGet.DatePosted.AddDays(-7);
        c["Maria Martinez"] = cGet;

        Console.WriteLine("Date posted for {0} changed to {1}", c["Maria Martinez"].Payee,
            c["Maria Martinez"].DatePosted.ToString("MM/dd"));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ClassBasedOnIEnumerable()
    {
        Console.WriteLine("ClassBasedOnIEnumerable");

        Member[] peopleArray = new Member[3]
        {
            new("Cody", "Blackwell"), //fucking bullshit
            new("Raj", "Chawanda"),
            new("Harriet", "Lipsey")
        };

        Members peopleList = new(peopleArray);
        foreach (Member p in peopleList)
        {
            Console.WriteLine(p.CompanyAffiliation + " " + p.CV_Info);
        }

        //foreach (Member p in peopleList)
        //{
        //    Console.WriteLine(p.CompanyAffiliation + " " + p.CV_Info);
        //}

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ClassBasedOnIDisposable()
    {
        Console.WriteLine("ClassBasedOnIDisposable");
        //Dispose Example

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void UnderstandingIUnknownAndCOM()
    {
        Console.WriteLine("UnderstandingIUnknownAndCOM");
        //Reference to COM Component is added
        //InteropDLL is automatically create // IL Dasm

        //ADODB.Connection cn = new ADODB.Connection(); //AddRef of IUnknown is internally called
        //cn.Open();
        //cn.Close();
        //cn = null; //Release of IUnknown is inyernally called

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ImplementingIComparable()
    {
        Console.WriteLine("ImplementingIComparable");

        ArrayList uncomparableNums = new();
        Random rndNumbers = new();

        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int degrees = rndNumbers.Next(0, 100);
            NumbersWithoutComparable temp = new()
            {
                RegularNumber = degrees
            };
            _ = uncomparableNums.Add(temp);
        }

        try
        {
            uncomparableNums.Sort();
            foreach (Number aNum in uncomparableNums)
            {
                Console.WriteLine(aNum.RegularNumber);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        ArrayList comparableNums = new();
        Random rnd = new();

        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int randomnum = rnd.Next(0, 100);
            Number num = new()
            {
                RegularNumber = randomnum
            };
            _ = comparableNums.Add(num);
        }

        comparableNums.Sort();

        foreach (Number num2 in comparableNums)
        {
            Console.WriteLine(num2.RegularNumber);
        }

        //numbers are instances of IComparable = sort when you have multiple instance of your type in an array or collection
        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void ConsumingTypesReflection()
    {
        Console.WriteLine("ConsumingTypesReflection");
        //enumerate all class members
        Type type = typeof(TransactionEventArgs); //System.Data.SqlClient.sqlConnection

        GetAllConstructors(type.GetConstructors());
        GetAllProperties(type.GetProperties());
        GetAllEvents(type.GetEvents());
        GetAllMethods(type.GetMethods());

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void AssemblyPropertyInfoAndMethodInfo()
    {
        Console.WriteLine("AssemblyPropertyInfoAndMethodInfo");
        Type? objType = null;

        Assembly objAssembly =
            Assembly.LoadFile(@"C:\inetpub\wwwroot\clbAssembly\bin\Debug\net6.0\clbAssembly.dll");

        Console.WriteLine("--Type Name --");

        foreach (Type objT in objAssembly.GetTypes())
        {
            Console.WriteLine(objT.FullName);
            objType = objT;
        }

        Console.WriteLine("--Method Name --");

        foreach (MethodInfo objMI in objType.GetMethods())
        {
            Console.WriteLine(objMI.Name);
        }

        MethodInfo? minfo = objType.GetMethod(objType.GetMethods()[0].Name);
        _ = minfo.GetParameters();

        object? objUtility = objAssembly.CreateInstance(objType.FullName, true);

        string[] st = new string[2];
        st[0] = "James ";
        st[1] = "Bond";
        Console.WriteLine(minfo.Invoke(objUtility, st));
        object[] prms = new object[2];
        prms[0] = "Hello ";
        prms[1] = "Reflection";

        Console.WriteLine(minfo.Invoke(objUtility, prms));

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void WorkingWithAttributes()
    {
        Console.WriteLine("WorkingWithAttributes");

        SampleTestClass testClass = new();
        Type type = testClass.GetType();

        string st = "";
        foreach (MethodInfo mInfo in type.GetMethods())
        {
            foreach (Attribute attr in
                 Attribute.GetCustomAttributes(mInfo))
            {
                if (attr.GetType() == typeof(CommentatorAttribute))
                {
                    st +=
                    "Method " + mInfo.Name +
                    " has Coment by '" +
                    ((CommentatorAttribute)attr).Author +
                    "' part of Commentator attribute.\n";
                }
            }
        }

        Console.WriteLine(st);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region CustomAttributeClasses Helper Code

    public static void CustomAttributeClasses()
    {
        Console.WriteLine("CustomAttributeClasses");

        //SetupUI();
        //GetChoice();
        Console.WriteLine();
        Console.WriteLine("DONE!");
        _ = Console.ReadKey();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #endregion

    [STAThread]
    public static void ConsumingTypesUsingCodedom()
    {
        Console.WriteLine("ConsumingTypesUsingCodedom");

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region Helpers Methods for Reflection

    private static void GetAllConstructors(ConstructorInfo[] constructorInfos)
    {
        Console.WriteLine("Constructors");
        Type type = typeof(BankAccount); //get type
        ConstructorInfo[] constructorinfo = type.GetConstructors(); //read properties
        foreach (ConstructorInfo info in constructorinfo)
        {
            Console.WriteLine(info.Name); //loop and get results
        }

        Console.WriteLine("==================");
    }

    private static void GetAllEvents(EventInfo[] eventInfos)
    {
        Console.WriteLine("Events");
        Type type = typeof(BankAccount); //get type
        EventInfo[] eventinfo = type.GetEvents(); //read properties
        foreach (EventInfo info in eventinfo)
        {
            Console.WriteLine(info.Name); //loop and get results
        }

        Console.WriteLine("==================");
    }

    private static void GetAllProperties(PropertyInfo[] propertyInfos)
    {
        Console.WriteLine("Properties");
        Type type = typeof(BankAccount); //get type
        PropertyInfo[] propertyinfo = type.GetProperties(); //read properties
        foreach (PropertyInfo info in propertyinfo)
        {
            Console.WriteLine(info.Name); //loop and get results
        }

        Console.WriteLine("==================");
    }

    private static void GetAllMethods(MethodInfo[] methodInfos)
    {
        Console.WriteLine("Methods");
        Type type = typeof(BankAccount); //get type
        _ = type.GetMethods(); //read properties

        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                               BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                               BindingFlags.Static))
        {
            //Getters and setters show us as methods, but for our prposes here, we dont care
            if (method.Name.Contains("get_") || method.Name.Contains("set_"))
            {
                continue;
            }
            else
            {
                Console.WriteLine($"Method: {method.Name}");
            }
        }

        Console.WriteLine("==================");
    }

    //static void GetAllTheMethods(MethodInfo[] methods)
    //{
    //    Console.WriteLine("Methods");
    //    foreach (var method in methods)
    //    {
    //        //Getters and setters show us as methods, but for our prposes here, we dont care
    //        if (method.Name.Contains("get_") || method.Name.Contains("set_"))
    //        {
    //            continue;
    //        }
    //        var methodbuilder = new StringBuilder();

    // methodbuilder.Append("(method)");

    // if (method.IsPublic) methodbuilder.Append("public");

    // if (method.IsStatic) methodbuilder.Append("static");

    // if (method.IsPrivate) methodbuilder.Append("private");

    //        methodbuilder.AppendFormat("{0}", method.ReturnType.Name);
    //        methodbuilder.Append(method.Name);
    //        methodbuilder.Append(GetParameters(method));
    //        Console.WriteLine(methodbuilder.ToString());
    //    }
    //}
    //static string GetAllParams(ConstructorInfo method)
    //{
    //    var parameters = method.GetParameters();
    //    var signitureBuilder = new StringBuilder();
    //    signitureBuilder.Append("(");

    //    return signitureBuilder.ToString();
    //}
    //static string GetParameters(MethodInfo method)
    //{
    //    Console.WriteLine("Parameters");
    //    var parameters = method.GetParameters();
    //    var signitureBuilder = new StringBuilder();
    //    signitureBuilder.Append("(");

    // var isFirst = true; foreach (var param in parameters) { if (!isFirst)
    // signitureBuilder.Append(", "); signitureBuilder.AppendFormat("\n {0}{1}",
    // param.ParameterType.ToString(), param.Name);

    //        isFirst = false;
    //    }
    //    return signitureBuilder.ToString();
    //}

    #endregion Helpers Methods for Reflection

    #region helper code for codedom

    //public static bool BuildTheProjectOutput()
    //{
    //}
    //public void BuildItFromScratch()
    //{
    //    unit = new CodeCompileUnit();
    //    CodeNamespace nspace = new CodeNamespace("codedomdemo");
    //    nspace.Imports.Add(new CodeNamespaceImport("System"));
    //    aClass = new CodeTypeDeclaration("codedomclass");
    //    aClass.IsClass = true;
    //    aClass.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
    //    nspace.Types.Add(aClass);
    //    unit.Namespaces.Add(nspace);

    //}

    //public void AddFields()
    //{
    //    //declare the firstnumber field.
    //    CodeMemberField operand1 = new CodeMemberField();
    //    operand1.Attributes = MemberAttributes.Private;
    //    operand1.Name = "firstNumber";
    //    operand1.Type = new CodeTypeReference(typeof(System.Double));
    //    operand1.Comments.Add(new CodeCommentStatement(
    //        "First number to calculate on"));
    //    aClass.Members.Add(operand1);

    //    ////declare the second number field.
    //    //CodeMemberField operand2 = new CodeMemberField();
    //    //operand2.Attributes = MemberAttributes.Private;
    //    //operand2.Name = "firstNumber";
    //    //operand2.Type = new CodeTypeReference(typeof(System.Double));
    //    //operand2.Comments.Add(new CodeCommentStatement(
    //    //    "Second number to calculate on"));
    //    //aClass.Members.Add(operand2);
    //}
    //public void AddProperties()
    //{
    //    //Declare the read only first property
    //    CodeMemberProperty firstNumberProperty = new CodeMemberProperty();
    //    firstNumberProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
    //    firstNumberProperty.Name = "FirstNumber";
    //    firstNumberProperty.HasGet = true;
    //    firstNumberProperty.Type = new CodeTypeReference(typeof(System.Double));
    //    aClass.Members.Add(firstNumberProperty);

    //    ////Declare the read only second property
    //    //CodeMemberProperty secondNumberProperty = new CodeMemberProperty();
    //    //secondNumberProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
    //    //secondNumberProperty.Name = "FirstNumber";
    //    //secondNumberProperty.HasGet = true;
    //    //firstNumberProperty.Type = new CodeTypeReference(typeof(System.Double));
    //    //aClass.Members.Add(secondNumberProperty);
    //}
    //public void AddMethod()
    //{
    //    //Declaring a ToStringMethod
    //    CodeMemberMethod toStringMethod = new CodeMemberMethod();
    //    toStringMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
    //    toStringMethod.Name = "ToString";

    //}
    //public void AddConstructor()
    //{//Declare the constructor
    //    CodeConstructor constructor = new CodeConstructor();
    //    constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

    // //Add parameters constructor.Parameters.Add( new CodeParameterDeclarationExpression(
    // typeof( System.Double), "firstNumber" )); constructor.Parameters.Add(new
    // CodeParameterDeclarationExpression(typeof(System.Double), "secondNumber"));

    // //Add field initialization logic CodeFieldReferenceExpression firstNumRef = new
    // CodeFieldReferenceExpression( new CodeThisReferenceExpression(), "firstNumber");
    // constructor.Statements.Add(new CodeAssignStatement(firstNumRef, new
    // CodeArgumentReferenceExpression("firstNumber"))); CodeFieldReferenceExpression
    // secondNumRef = new CodeFieldReferenceExpression( new CodeThisReferenceExpression(),
    // "secondNumber"); constructor.Statements.Add(new CodeAssignStatement(secondNumRef, new
    // CodeArgumentReferenceExpression("secondNumber"))); aClass.Members.Add(constructor);

    //}
    //public void AddEntryPoint()
    //{
    //    CodeEntryPointMethod start = new CodeEntryPointMethod();
    //    CodeObjectCreateExpression objectCreate =
    //        new CodeObjectCreateExpression(
    //            new CodeTypeReference("codedomclass"),
    //            new CodePrimitiveExpression(777.5),
    //            new CodePrimitiveExpression(688.8));

    // //add the statement: //"codedomclass test = // new codedomclass(777.7, 688.8);"
    // start.Statements.Add(new CodeVariableDeclarationStatement( new
    // CodeTypeReference("codedomclass"), "test", objectCreate));

    // //Create the expression: //"testClass.ToString()" CodeMethodInvokeExpression
    // toStringInvoke = new CodeMethodInvokeExpression( new
    // CodeVariableReferenceExpression("test"), "ToString");

    //    //Add a System.Console.WriteLine Statement with the previous expression as a parameter
    //    start.Statements.Add(new CodeMethodInvokeExpression(
    //        new CodeTypeReferenceExpression("System.Console"),
    //        "WriteLine", toStringInvoke));
    //    start.Statements.Add(new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.Console"), ""));
    //    aClass.Members.Add(start);
    //}
    //public void letsMakeSomeCode(string fullpath)
    //{
    //    CodeDomProvider compiler = CodeDomProvider.CreateProvider("CSharp");
    //    CodeGeneratorOptions opt = new CodeGeneratorOptions();
    //    //Default is block, WHere {start on same line as statement...
    //    opt.BracingStyle = "C";
    //    using (StreamWriter sw = new StreamWriter(fullpath))
    //    {
    //        sw.AutoFlush = true;
    //        compiler.GenerateCodeFromCompileUnit(unit, sw, opt);
    //    }

    //}

    #endregion helper code for codedom
}

#region Helper Class

internal class clsA2 : clbAssembly.clsMath
{
    public clsA2()
    {
        prd_i = 123;
    }
}

//[Commentator("James", "None", "22-01-1997")] //only invoked on methods
public class SampleTestClass
{
    [Commentator("James", "None", "22-01-1997")]
    public void SomeMethod()
    {
        // Method intentionally left empty.
    }
}

[AttributeUsage(AttributeTargets.Method)] //method invoke //enforce
public class CommentatorAttribute : Attribute
{
    public CommentatorAttribute(string author, string testedBy, string modifiedDate)
    {
        Author = author;
        TestedBy = testedBy;
        ModifiedDate = modifiedDate;
    }

    public string Author { get; set; }
    public string TestedBy { get; set; }
    public string ModifiedDate { get; set; }
}

#endregion Helper Class
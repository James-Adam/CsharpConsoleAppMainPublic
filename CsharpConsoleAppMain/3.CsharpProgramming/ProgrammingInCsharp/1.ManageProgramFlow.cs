using CsharpConsoleAppMain.CsharpProgramming.Bank;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

//BuiltInDelegate
//you could do this
internal delegate decimal SomeMathThing(int x, int y);

//but why not just uses this instead?
internal delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);

public static class ManageProgramFlow
{
    //STEP 2: create a delegate INSTANCE
    private static MathDelegate? aMathDelegateInstance;

    //Variables
    public static void Variables()
    {
        //Start:
        // allow for decimal
        double num1;
        double num2;

        Console.WriteLine("Type a number to be multiplied: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Type another number: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("The Result is " + (num1 * num2));
        //Console.ReadKey();

        //whole numbers
        int num01;
        int num02;

        Console.WriteLine("Type a number to be divided: ");
        num01 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Type a number to divide by: ");
        num02 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Result: " + num01 + " divided by " + num02 + "is equal to " + (num01 / num02));

        //Console.ReadKey();
        //Console.WriteLine();
        //goto Start; //Jumps to Start
    }

    //SwitchStatement
    public static void SwitchStatement()
    {
        //First Method
        int Age;

        Console.WriteLine("How old are you?");
        Age = Convert.ToInt32(Console.ReadLine());

        if (Age < 18) // ==, !=, <=, >=, <, >
        {
            Console.WriteLine("Thats too bad!!! You will have to wait a couple of years.");
        }
        else if (Age == 18)
        {
            Console.WriteLine("Wheew!!! Barely Made it.");
        }
        else if (Age > 18)
        {
            Console.WriteLine("Nice!!! you can access the site.");
        }

        //Second Method
        bool numeric = short.TryParse(Console.ReadLine(), out short loveIt);

        Console.Write("How much do you like .Net?(Scale of 1 to 10)");
        _ = Console.ReadLine();

        if (numeric && loveIt >= 0 && loveIt <= 10)
        {
            string HowMuchYourLoveIt = loveIt switch
            {
                1 or 2 or 3 => "You just dont know .NET ell enough, i guess...",
                4 or 5 or 6 => "I sense a budding relationship...",
                7 or 8 or 9 => "Why dont you marry it??",
                10 => "Lets not go over board here",
                _ => "I cant do that, Dave!"
            };
            Console.WriteLine(HowMuchYourLoveIt);
        }
        else
        {
            Console.WriteLine("Enter something numeric between 1 and 10 and try again!!!");
            return;
        }

        //declans method

        //Console.WriteLine("Select 0-5");
        //string answer = Console.ReadLine();
        //Console.WriteLine("You wrote: " + answer);

        //int a;
        //bool isValidInt = int.TryParse(answer, out a);

        //if (isValidInt)
        //{
        //    Console.WriteLine("You gave me a int !!");
        //}
        //else
        //{
        //    Console.WriteLine("You gave me random nonsense");
        //}

        // 3rd method in practice

        //AccountStatus currentStatus = AccountStatus.RestrictedFraudAlert; //ienumerables

        Console.WriteLine("Select 0-5");
        string? answer = Console.ReadLine();

        Console.WriteLine("You wrote: " + answer);

        bool isValidInt = int.TryParse(answer, out int a);

        if (isValidInt)
        {
            //Console.WriteLine("You gave me a int !!");

            AccountStatus currentStatus = (AccountStatus)a; //Typecast

            //Console.WriteLine(currentStatus);

            switch (currentStatus)
            {
                case AccountStatus.OK:
                    Console.WriteLine("Account is ok");
                    break;

                case AccountStatus.Overdrawn:
                    Console.WriteLine("Account is Overdrawn");
                    break;

                case AccountStatus.Maintenance:
                    Console.WriteLine("Account is Maintenance");
                    break;

                case AccountStatus.RestrictedFraudAlert:
                    Console.WriteLine("Account is RestrictedFraudAlert");
                    break;

                case AccountStatus.SuspendedUserRequest:
                    Console.WriteLine("Account is SuspendedUserRequest");
                    break;

                case AccountStatus.SuspendedBankReview:
                    Console.WriteLine("Account is SuspendedBankReview");
                    break;

                default:
                    Console.WriteLine("Account is unknown");
                    break;
            }
        }
        else
        {
            Console.WriteLine("You gave me random nonsense");
        }

        _ = Console.ReadLine();
    }

    //IfElseStatement
    public static void IfElseStatement()
    {
        //the if/else statement
        Console.WriteLine("Enter Number X ");
        int numX = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Number Y ");
        int numY = int.Parse(Console.ReadLine());

        if (numX == numY)
        {
            Console.WriteLine("numX is equal to numY");

            if (numX % 2 == 0)
            {
                Console.WriteLine("numX is an Even Number");
            }
            else
            {
                Console.WriteLine("numX is an Odd Number");
            }
        }
        else if (numX > numY)
        {
            Console.WriteLine("numX is Greater than numY");
        }
        else
        {
            Console.WriteLine("numX is Less than numY");
        }

        Console.WriteLine("Press any key to continue!!!");
        _ = Console.ReadKey();
    }

    //ForAndForEach
    public static void ForAndForEach()
    {
        Console.WriteLine("\n ForLoop");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\n ForeachLoop");
        string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
        foreach (string i in cars)
        {
            Console.WriteLine(i);
        }

        List<string> states = SetupInMemoryCollection();
        int stateCount = states.Count;

        ResetConsole("\n With the FOR loop:", false);
        for (int i = 0; i < stateCount; i++)
        {
            if (states[i] == "Oregon")
            {
                states[i] += ", The Beaver State!";
            }

            Console.WriteLine(states[i]);
        }

        ResetConsole("\n With the FOREACH loop:", false);
        foreach (string state in states)
        {
            //Disallowe:Foreach only allows read access while enumerating
            //if (state == "Ohio")
            //{
            //    state += ", the Buckeye State!";
            //}
            Console.WriteLine(state);
        }

        ResetConsole("\n Continue statement to break out of loop iterations:", false);
        for (int i = 0; i < 5; i++)
        {
            if (string.Equals(states[i][..1], "N", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
            else
            {
                Console.WriteLine(states[i]);
            }
        }

        ResetConsole("\n Break statement to break out of loop completely:", false);
        for (int i = 0; i < stateCount; i++)
        {
            if (string.Equals(states[i][..1], "N", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine(states[i]);
            }
        }

        //Fix
        static List<string> SetupInMemoryCollection()
        {
            return new List<string>
            {
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Tennessee",
                "Ohio",
                "Oklahoma",
                "Oregon, the Beaver State!",
                "Rhode Island",
                "South Carolina",
                "South Dakota",
                "Texas",
                "Utah",
                "Washington",
                "Wisconsin"
            };
        }

        static void ResetConsole(string v1, bool v)
        {
            Console.WriteLine(v1);
        }
    }


    //OperatorAndEvalExpressions
    public static void OperatorAndEvalExpressions()
    {
        Console.WriteLine(" method 1");
        const int evalNumber = 6;
        //var = (T/F)? true part: false part:
        string EvalGrade = evalNumber >= 7 ? "Satisfactory" : "Unsatisfactory";
        Console.WriteLine(EvalGrade);

        Console.WriteLine("\n method 2");
        const int x = 10;
        const int y = 15;
        if (LessThanZero(x) && LessThanZero(y))
        {
            Console.WriteLine("Both numbers are less than zero");
        }
        else
        {
            Console.WriteLine("Someone here is positive, numerically speaker");
        }

        Console.WriteLine("\n method 3");
        int a = 10;
        int b = a++;
        Console.WriteLine("POSTFIX:A:{0}, B:{1}", a, b);

        a = 10;
        b = ++a;
        Console.WriteLine("PREFIX: A:{0}, B:{1}", a, b);
    }

    //OperatorAndEvalExpressions
    private static bool LessThanZero(int number)
    {
        return number > 0;
    }

    //BuiltInDelegate
    public static void BuiltInDelegate()
    {
        //create an instance of the delegate and use it
        SomeMathThing myMathThing = AddTwoNumbers;
        Console.WriteLine("\n method 1: create an instance of the delegate and use it");
        Console.WriteLine("Method {0} produces {1}",
            myMathThing.Method.Name, myMathThing(3333, 11));

        //or use the built in delegate
        Func<int, int, decimal> callSimpleMathDelegate = AddTwoNumbers;
        decimal result = callSimpleMathDelegate(3333, 11);
        Console.WriteLine();
        Console.WriteLine("\n Method 2: use the built in delegate");
        Console.WriteLine("Method {0} using Built in Delegate produces {1}",
            callSimpleMathDelegate.Method.Name, result);

        //Menay overloads exist for common delegate situations
        //if you have to call a method which requires no return, use the Action<T...>delegates...
        Action<int> oneParamMethodCall = VoidMethodWithOneParam;
        Action<int, string> twoParamCall = VoidMethodWithTwoParams;

        //invoke as normal.. lather, rinse ande repeat
        ResetConsole("\n using the Action<int>delegate invocation:");
        oneParamMethodCall(4);

        ResetConsole("\n using the Action<int, string>delegate invocation:");
        twoParamCall(3, ", Loopy");
    }

    //BuiltInDelegate
    private static void VoidMethodWithOneParam(int i)
    {
        Console.WriteLine(i);
    }

    private static void VoidMethodWithTwoParams(int arg1, string arg2)
    {
        Console.WriteLine(arg1 + arg2);
    }

    private static void ResetConsole(string v)
    {
        Console.WriteLine(v);
    }

    private static decimal AddTwoNumbers(int x, int y)
    {
        return x + (decimal)y;
    }

    //CreatingAndUsingDelegates
    public static void CreatingAndUsingDelegates()
    {
        //STEP 3: Attach methods to be called
        aMathDelegateInstance += AddAndGoForward;
        aMathDelegateInstance += SubtractAndBePositive;

        //STEP 4: Call the methods
        const int operator1 = 100;
        const int operator2 = 200;
        decimal returnValues = aMathDelegateInstance.Invoke(operator1, operator2);
        Console.WriteLine("INVOKE with (100,200) produced scalar result {0}", returnValues);

        //When theres a return value, call this way
        ResetConsole(string.Format("Now we're talking results for EVERYONE!(First param: {0}, Second param: {1}",
            operator1, operator2));
        foreach (MathDelegate delMethod in aMathDelegateInstance.GetInvocationList().OfType<MathDelegate>())
        {
            Console.WriteLine("Method {0} produced the result {1}", delMethod.Method.Name,
                delMethod.Invoke(operator1, operator2));
        }

        Console.WriteLine("\n DONE!");
    }

    //CreatingAndUsingDelegates
    private static decimal SubtractAndBePositive(int first, int second)
    {
        return second - (decimal)first;
    }

    private static decimal AddAndGoForward(int first, int second)
    {
        return first + (decimal)second;
    }

    //LambdaExpressions - fix
    public static void LambdaExpressions()
    {
        //LAMBDA Expressions 101:
        //Variable = ((parameter(s)=>{(statement(s)...[n]...return result(s);}
        MathDelegate myMathDelegate = (param1in, param2in) => param1in * param2in;

        const int x = 55;
        const int y = 77;

        Console.WriteLine("with params{0} - {1}, the result of {2} is {3}", x, y,
            myMathDelegate.Method.Name,
            myMathDelegate.Invoke(x, y));
    }

    //AnonoymousMethods()
    public static void AnonoymousMethods()
    {
        //And add an anonoymous method...
        Thread t1 = new(delegate ()
        {
            Console.Write("Hello, ");
            Console.WriteLine("World!");
        });

        t1.Start();
        ResetConsole("...And with the MathDelegate...");
        static decimal anotherDelegateInstance(int x, int y) { return x / y; }
        decimal result = anotherDelegateInstance(3333, 11);
        Console.WriteLine("MathDelegate call:{0}", result);
    }

    //SubscribingToEvents()
    public static void SubscribingToEvents() // cannot convert void to bool or other return type
    {
        BankAccount bankAccount = new(new MoneyInformation());
        bankAccount.OnTransactionFailed += bankAccount_OnTransactionFailed;

        bool depositCredited = bankAccount.Deposit(500M);
        if (depositCredited)
        {
            Console.WriteLine("Deposit credited...");
            Console.WriteLine();
            _ = bankAccount.Withdraw(1000M);
        }
    }

    //SubscribingToEvents()
    private static void bankAccount_OnTransactionFailed(object sender, TransactionEventArgs e)
    {
        Console.WriteLine("There was a {0} problem: \n{1}", e.WhyItFailed, e.Message);
    }

    private static void EventHandlerMethod(object s, EventArgs e) //string
    {
        Console.WriteLine("EventHandlerMethod Called at " + DateTime.Now.ToString("HH:mm:ss"));
    }

    //EventHandlers()
    public static void EventHandlers()
    {
        SetTimeOut obj = new();
        obj.ValueChanged += EventHandlerMethod;
        obj.StartNotification();
        _ = Console.ReadKey();
    }

    //EventHandlers()

    //ExceptionWIthMultiCatchBlocks()
    public static void ExceptionWIthMultiCatchBlocks()
    {
        Console.Write("Enter a path to a file: ");
        string? pathName = Console.ReadLine();

        try
        {
            //File.Open(pathName, FileMode.Create);

            Random r = new();
            int excToThrow = r.Next(1, 5);
            switch (excToThrow)
            {
                // these are exceptions that could happen with File.Open(..)

                case 1: throw new FileNotFoundException("File not found", pathName);
                case 2: throw new UnauthorizedAccessException();
                case 3: throw new PathTooLongException();
                case 4: throw new DirectoryNotFoundException();
                case 5: throw new ArgumentException();
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("You are not permitted to access this file. Your request belongs to us");
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            if (ex.GetType() == typeof(PathTooLongException))
            {
                Console.WriteLine("The file path is too long. Try Sgain without the verbosity");
            }
            else if (ex.GetType() == typeof(DirectoryNotFoundException))
            {
                Console.WriteLine("We cant find that folder.");
            }
            else
            {
                Console.WriteLine("The file system couldnt handle your request for some reason. Try later.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Happened. Were not sure what quite yet.({0})", ex);
        }
    }

    //TheFinallyBlock()
    public static void TheFinallyBlock()
    {
        //Application.ApplicationExit += Application_ApplicationExit;
        BankAccount ba = new(new MoneyInformation('$', "US Dollars"));

        Exception? logException = null;
        try
        {
            Console.Write("enter the deposit amount: ");
            decimal userInput = Convert.ToDecimal(Console.ReadLine());
            _ = ba.Deposit(userInput);
        }
        catch (BankAccountException ex)
        {
            Console.WriteLine("The transaction errored{0}", ex);
        }
        catch (FormatException ex)
        {
            logException = ex;
            Application.Exit();
        }
        catch (Exception ex)
        {
            logException = ex;
        }
        finally
        {
            if (logException != null)
            {
                try
                {
                    if (!EventLog.SourceExists("ExeptionDemo"))
                    {
                        EventLog.CreateEventSource("ExcpetionDemo", "Application");
                    }

                    EventLog.WriteEntry("Program class", logException.ToString()); //, EventLogEntryType.Error
                    Console.WriteLine("{0} logged at {1}", logException.GetType(),
                        DateTime.Now.ToString("hh:mm:ss:ff"));
                }
                catch
                {
                    Console.WriteLine("Failed to log exception");
                }
            }
        }
        //Application.ApplicationExit -= Application_ApplicationExit;
    }

    //TheFinallyBlock
    // static void Application_ApplicationExit(object sender, EventArgs e)
    //{
    //    System.Diagnostics.Debug.WriteLine("Exit event happened at" + DateTime.Now.ToString("hh:mm:ss:ff"));
    //}

    //CreateCustomExeptionClasses()
    public static void CreateCustomExeptionClasses()
    {
        BankAccount ba = new(new MoneyInformation('$', "US Dollars"));

        try
        {
            _ = ba.Deposit(-100M);
        }
        catch (BankAccountException ex)
        {
            Console.WriteLine("The transaction errored: {0}", ex.transactionNotes);
        }
    }

    //Fix
    //ContextSpecificExeptionHandling()
    public static void ContextSpecificExeptionHandling()
    {
        WCFClientSpecificException();
    }

    //ContextSpecificExeptionHandling()
    private static void WCFClientSpecificException()
    {
        WcfServiceLibrary.GreetingService wcfClient = new
            ();
        try
        {
            Console.WriteLine("Enter Your Name");
            string? usrName = Console.ReadLine();
            Console.WriteLine("The service respond: " + wcfClient.SayHi
                (usrName));
            Console.WriteLine("Press any key to Exit...");
            _ = Console.ReadKey();
        }
        catch (TimeoutException timeProblem)
        {
            Console.WriteLine("The service operation timed out. " +
                              timeProblem.Message);

            _ = Console.ReadLine();
        }
        //catch (Net.Csharp.Bank.FaultException<contractuallySpecificDetails> greetingFault)
        //{
        //    Console.WriteLine(greetingFault.Detail.SpecificDetails);
        //    Console.Read();
        //    wcfClient.Abort();
        //}
        catch (FaultException faultEx)
        {
            Console.WriteLine("An unknown exception was recieved. "
                              + faultEx.Message
                              + faultEx.StackTrace
            );
            _ = Console.Read();
        }
        catch (CoreWCF.CommunicationException commProblem)
        {
            Console.WriteLine("There was a communication problem. " +
                              commProblem.Message + commProblem.StackTrace);
            _ = Console.Read();
        }
    }

    //ExceptionHandlingInMultThreading()
    public static void ExceptionHandlingInMultThreading()
    {
        //AggregateExceptionDemo();
        Console.WriteLine("\nNestedAggregateExceptionDemo: ");
        NestedAggregateExceptionDemo();
    }

    public static void AggregateExceptionDemo()
    {
        try
        {
            //Parallel.Invoke(
            //    () => { throw new DivideByZeroException(); },
            //    () => { throw new AggregateException(); }
            //    );
        }
        catch (AggregateException ex)
        {
            foreach (Exception v in ex.InnerExceptions)
            {
                Console.WriteLine("Exception: " + v.Message);
            }
        }
    }

    public static void NestedAggregateExceptionDemo()
    {
        Console.WriteLine("...Before Call...");
        Task outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Begin outer task ");

            Task childTask2 = Task.Factory.StartNew(
                () =>
                {
                    Console.WriteLine("Child task 2 start");
                    Thread.Sleep(100);
                    Console.WriteLine("Child task 2 complete");
                    //throw new InvalidOperationException();
                },
                TaskCreationOptions.AttachedToParent);
            Task childTask1 = Task.Factory.StartNew(
                () =>
                {
                    Console.Write("Child task 1 start");
                    Thread.Sleep(100);
                    Console.WriteLine("Child task 1 complete");
                    //throw new FormatException();
                },
                TaskCreationOptions.AttachedToParent);
            Console.WriteLine("outer task complete");
        });
        Console.WriteLine("Wait for outer task");

        try
        {
            outerTask.Wait();
            Console.WriteLine("After Outer Task");

            Thread.Sleep(200);
        }
        catch (AggregateException ex)
        {
            foreach (Exception v in ex.InnerExceptions)
            {
                Console.WriteLine($"{v.GetType().Name}: {v.Message}");

                if (v is AggregateException)
                {
                    foreach (Exception childEx in (v as
                                 AggregateException).InnerExceptions)
                    {
                        Console.WriteLine($"Child Exception {childEx.GetType().Name}: {childEx.Message}");
                    }
                }
            }
        }
    }

    //CreatingAndUsingDelegates
    //STEP 1: define the delegate
    private delegate decimal MathDelegate(int first, int second);
}

//EventHandlers
internal class SetTimeOut
{
    // class SetTimeOut
    private int _snoozeInMillisec = 1000;

    public event EventHandler ValueChanged; //<string>

    public void StartNotification()
    {
        while (_snoozeInMillisec > 0)
        {
            Thread.Sleep(_snoozeInMillisec);
            ValueChanged?.Invoke(this, new EventArgs()); //"Demo value"

            Console.Write("Snooze for (in milliseconds, 0 to terminate): ");
            _snoozeInMillisec = int.Parse(Console.ReadLine());
        }
    }
}
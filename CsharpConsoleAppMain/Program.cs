using CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;
using CsharpConsoleAppMain.Data.Declan;
using CsharpConsoleAppMain.Data.Vehicles;
using CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;
using CsharpConsoleAppMain.DevFundamentals.OOPFund;
using CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals;
using CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;
using CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb;
using CsharpConsoleAppMain.WebFundamentals;

namespace CsharpConsoleAppMain;

public static class Program
{
    [STAThread]
    [Obsolete]
    public static void Main(string[] args)
    {
    Start:
        //Main Console Menu
        Console.WriteLine("Run commands:\n");
        Console.WriteLine("Dev Fundamentals: 1");
        Console.WriteLine("Web Fundamentals: 2");
        Console.WriteLine("Programming In C#: 3");
        Console.WriteLine("Developing Asp Net MVC Web Applications: 4");
        Console.WriteLine("Developing Microsoft Azure And Web Services: 5");
        Console.WriteLine("Developing Mobile Applications: 6");
        Console.WriteLine("Python: 7");
        Console.WriteLine("Java SE11 Developer: 8");
        Console.WriteLine("ISTQB Software Testing: 9");
        Console.WriteLine("Microsoft Azure DevOps: 10");
        Console.WriteLine("Declan: 11");

        string? answer = Console.ReadLine();
        Console.WriteLine("\n");
        switch (answer)
        {
            //Dev Fundamentals
            case "1":
                {
                    Console.WriteLine("Program Fundamentals: 1");
                    Console.WriteLine("Program Techniques: 2");
                    Console.WriteLine("Develop Windows And Web Applications: 3");
                    Console.WriteLine("OOP Fund: 4");
                    Console.WriteLine("Windows Store Applications And Databases: 5");

                    answer = Console.ReadLine();
                    Console.WriteLine("\n");

                    switch (answer)
                    {
                        //Programming Fundamentals
                        case "1":
                            {
                                Console.WriteLine("Intro To Programming Fundamentals: 1");
                                Console.WriteLine("Variables Arrays And Operators: 2");
                                Console.WriteLine("Working With Strings: 3");
                                Console.WriteLine("Data Structures: 4");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");
                                switch (answer)
                                {
                                    //Intro to Programming Fundamentals
                                    case "1":
                                        Console.WriteLine("Intro To Methods: 1");
                                        Console.WriteLine("Constructor Methods: 2");
                                        Console.WriteLine("Intro To NameSpaces: 3");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                IntroToProgFund.IntroToMethods();
                                                break;
                                            case "2":
                                                IntroToProgFund.ConstructorMain();
                                                break;
                                            case "3":
                                                NameSpaceProgram.NameSpaceMain();
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }

                                        break;

                                    //Variables, Arrays, and Operators
                                    case "2":
                                        Console.WriteLine("Intro To Vars And Constants: 1");
                                        Console.WriteLine("Intro To Var Data Types: 2");
                                        Console.WriteLine("Intro To Arrays: 3");
                                        Console.WriteLine("Intro To Math Ops: 4");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                VariablesArraysAndOperators.IntroToVarsAndConts();
                                                break;
                                            case "2":
                                                VariablesArraysAndOperators.IntroToVarDataTypes();
                                                break;
                                            case "3":
                                                VariablesArraysAndOperators.IntroToArrays();
                                                break;
                                            case "4":
                                                VariablesArraysAndOperators.IntroToMathOps();
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }

                                        break;

                                    //Working with Strings
                                    case "3":
                                        Console.WriteLine("Intro To C# Strings: 1");
                                        Console.WriteLine("String Literals: 2");
                                        Console.WriteLine("String Indexing: 3");
                                        Console.WriteLine("Using Char And Strings: 4");
                                        Console.WriteLine("Working With Substrings: 5");
                                        Console.WriteLine("Convert Strings To Numbers: 6");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                WorkingWithStrings.IntroToCshrpStrings();
                                                break;
                                            case "2":
                                                WorkingWithStrings.StringLiterals();
                                                break;
                                            case "3":
                                                WorkingWithStrings.StringIndexing();
                                                break;
                                            case "4":
                                                WorkingWithStrings.UsingCharAndStrings();
                                                break;
                                            case "5":
                                                WorkingWithStrings.WorkingWithSubstrings();
                                                break;
                                            case "6":
                                                WorkingWithStrings.ConvertStringToNum();
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }

                                        break;

                                    case "4":
                                        Console.WriteLine("Intro To Lists: 1");
                                        Console.WriteLine("Intro To Arrays: 2");
                                        Console.WriteLine("Intro To Queues: 3");
                                        Console.WriteLine("Intro To Stacks: 4");
                                        Console.WriteLine("Intro To Linked Lists: 5");
                                        Console.WriteLine("Select Data Structures: 6");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                DataStructures.IntroToLists();
                                                break;
                                            case "2":
                                                DataStructures.IntroToArrays();
                                                break;
                                            case "3":
                                                DataStructures.IntroToQuees();
                                                break;
                                            case "4":
                                                DataStructures.IntroToStacks();
                                                break;
                                            case "5":
                                                DataStructures.IntroToLinkedLists();
                                                break;
                                            case "6":
                                                DataStructures.SelectDataStruct();
                                                break;
                                            default:
                                                Console.WriteLine("Error");
                                                break;
                                        }

                                        break;

                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }

                            break;

                        //Programming Techniques
                        case "2":
                            {
                                Console.WriteLine("Decision Structures: 1");
                                Console.WriteLine("Basic Programming Practices: 2");
                                Console.WriteLine("Intro To Windows Application Development: 3");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        Console.WriteLine("Intro To If Statements: 1");
                                        Console.WriteLine("Intro To If Else Statements: 2");
                                        Console.WriteLine("Intro To Conditional Statements: 3");
                                        Console.WriteLine("Intro To Switch Statements: 4");
                                        Console.WriteLine("Intro To While And DoWhile Loops: 5");
                                        Console.WriteLine("Intro To For And ForEach Loops: 6");
                                        Console.WriteLine("Try Catch Finally Statements: 7");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                DecisionStuctures.IntroToIfStatements();
                                                break;
                                            case "2":
                                                DecisionStuctures.IntroToIfElseStatements();
                                                break;
                                            case "3":
                                                DecisionStuctures.IntroToConditionalStatements();
                                                break;
                                            case "4":
                                                DecisionStuctures.IntroToSwitchStatements();
                                                break;
                                            case "5":
                                                DecisionStuctures.IntroToWhileAndDoWhileLoops();
                                                break;
                                            case "6":
                                                DecisionStuctures.IntroToForAndForEachLoops();
                                                break;
                                            case "7":
                                                DecisionStuctures.TryCatchFinallyStatements();
                                                break;
                                        }

                                        break;

                                    case "2":
                                        Console.WriteLine("Intro To Recursion: 1");
                                        Console.WriteLine("Intro To Exception Handling: 2");
                                        Console.WriteLine("How To Capture User Input: 3");
                                        Console.WriteLine("Intro To Randomization: 4");
                                        Console.WriteLine("How To Create Random List Of Numbers: 5");
                                        Console.WriteLine("Intro To Sorting Algorithms: 6");
                                        Console.WriteLine("The QuickSort Algorithm: 7");
                                        Console.WriteLine("How To Read And Display Files: 8");
                                        Console.WriteLine("How To Create File And Writ eData: 9");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                BasicProgPract.IntroToRecursion();
                                                break;
                                            case "2":
                                                BasicProgPract.IntroToExceptionHandling();
                                                break;
                                            case "3":
                                                BasicProgPract.HowToCaptureUserInput();
                                                break;
                                            case "4":
                                                BasicProgPract.IntroToRandomization();
                                                break;
                                            case "5":
                                                BasicProgPract.HowToCreateRandomListOfNumbers();
                                                break;
                                            case "6":
                                                BasicProgPract.IntroToSortingAlgorithms();
                                                break;
                                            case "7":
                                                BasicProgPract.TheQuickSortAlgorithm();
                                                break;
                                            case "8":
                                                BasicProgPract.HowToReadAndDisplayFiles();
                                                break;
                                            case "9":
                                                BasicProgPract.HowToCreateFileAndWriteData();
                                                break;
                                        }

                                        break;

                                    case "3":
                                        Console.WriteLine("Programming Windows Forms Applications: 1");
                                        Console.WriteLine("Windows Forms Events: 2");
                                        Console.WriteLine("Windows Alerts And Dialogs: 3");

                                        answer = Console.ReadLine();
                                        Console.WriteLine("\n");

                                        switch (answer)
                                        {
                                            case "1":
                                                WindFormApp.WindForm();
                                                break;
                                            case "2":
                                                WindFormApp1.WindForm1();
                                                break;
                                            case "3":
                                                WindFormApp2.WindForm2();
                                                break;
                                        }

                                        break;

                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }

                            break;

                        //Develop Windows And Web Applications
                        case "3":
                            {
                                Console.WriteLine("Windows Forms: 1");
                                Console.WriteLine("Windows Applications: 2");
                                Console.WriteLine("Development Basics: 3");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    //Windows Forms
                                    case "1":
                                        {
                                            Console.WriteLine("Creating Tabbed Pages: 1");
                                            Console.WriteLine("Saving Files: 2");
                                            Console.WriteLine("Opening Files: 3");
                                            Console.WriteLine("How To Create Drop Down Menu: 4");
                                            Console.WriteLine("Multi Doc Interface Application: 5");
                                            Console.WriteLine("Create ToolBar: 6");
                                            //FIX
                                            answer = Console.ReadLine();
                                            Console.WriteLine("\n");

                                            switch (answer)
                                            {
                                                case "1":
                                                    WindFormsExecute.CreatingTabbedPages();
                                                    break;
                                                case "2":
                                                    WindFormsExecute.SavingFiles();
                                                    break;
                                                case "3":
                                                    WindFormsExecute.OpeningFiles();
                                                    break;
                                                case "4":
                                                    WindFormsExecute.CreateDropdownMenu();
                                                    break;
                                                case "5":
                                                    WindFormsExecute.MultiDocInterfaceApp();
                                                    break;
                                                case "6":
                                                    WindFormsExecute.CreateToolbar();
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        break;

                                    //Windows Application
                                    case "2":
                                        {
                                            Console.WriteLine("Create Web Browser: 1");
                                            Console.WriteLine("Create Windows Application: 2");
                                            //FIX
                                            answer = Console.ReadLine();
                                            Console.WriteLine("\n");

                                            switch (answer)
                                            {
                                                case "1":
                                                    WindowsFormsApp.Program.Main();
                                                    break;
                                                case "2":
                                                    WindowsFormsApp.Program.CreateWinApp();
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        break;

                                    //Working With Web Pages
                                    case "3":
                                        {
                                            Console.WriteLine("Working With Web Pages: 1");
                                            //FIX
                                            answer = Console.ReadLine();
                                            Console.WriteLine("\n");

                                            switch (answer)
                                            {
                                                //Create host builder
                                                case "1":
                                                    CreateHostBuilder(args).Build().Run();
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //Object Orientated Programming Fundamentals
                        case "4":
                            {
                                Console.WriteLine("Introduction To Object Orientated Programing: 1");
                                Console.WriteLine("Encapsulation And Inheritance: 2");
                                Console.WriteLine("Apply Object Orientated Programing: 3");
                                Console.WriteLine("Working With JavaScript: 4");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    //Introduction To Orientated Programming Fundamentals
                                    //Fix
                                    case "1":
                                        IntroToOOP.introToOOP();
                                        break;

                                    //Encapsulation And Inheritance
                                    case "2":
                                        {
                                            Console.WriteLine("Introduction to Encapsulation: 1");
                                            Console.WriteLine("Access Modifiers: 2");
                                            Console.WriteLine("Inheritance in OOP: 3");
                                            Console.WriteLine("Base and Derived Classes: 4");

                                            answer = Console.ReadLine();
                                            Console.WriteLine("\n");

                                            switch (answer)
                                            {
                                                case "1":
                                                    EncapsulationAndInheritance.IntroToEncapsulation();
                                                    break;
                                                case "2":
                                                    EncapsulationAndInheritance.AccessModifiers();
                                                    break;
                                                case "3":
                                                    EncapsulationAndInheritance.InheratInOOP();
                                                    break;
                                                case "4":
                                                    EncapsulationAndInheritance.BaseAndDerivedClasses();
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        break;

                                    //Apply Orientated Programming Fundamentals
                                    case "3":
                                        {
                                            Console.WriteLine("Abstract and Sealed Classes: 1");
                                            Console.WriteLine("Casting Between Types: 2");
                                            Console.WriteLine("Using Is And As: 3");
                                            Console.WriteLine("Introduction To Polymorphism: 4");
                                            Console.WriteLine("Using Override And New: 5");
                                            Console.WriteLine("Introduction To Interfaces: 6");

                                            answer = Console.ReadLine();
                                            Console.WriteLine("\n");

                                            switch (answer)
                                            {
                                                case "1":
                                                    ApplyOOP.AbstractandSealedClasses();
                                                    break;
                                                case "2":
                                                    ApplyOOP.CastingBetweenTypes();
                                                    break;
                                                case "3":
                                                    ApplyOOP.UsingIsAndAs();
                                                    break;
                                                case "4":
                                                    ApplyOOP.IntroToPolymorphism();
                                                    break;
                                                case "5":
                                                    ApplyOOP.UsingOverrideAndNew();
                                                    break;
                                                case "6":
                                                    ApplyOOP.IntroToInterfaces();
                                                    break;
                                                default:
                                                    Console.WriteLine("Error");
                                                    break;
                                            }
                                        }
                                        break;

                                    //Working With JavaScript
                                    case "4":
                                        {
                                            //FIX
                                            WorkingWithJavascript.workingWithJavascript();
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //WindStoreAppAndDb
                        case "5":
                            {
                                Console.WriteLine("Console Application And Windows Services: 1");
                                Console.WriteLine("Windows Store Applications: 2");
                                Console.WriteLine("Database Fundamentals: 3");
                                Console.WriteLine("Database Query Methods And Connections: 4");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        ConsoleAppAndWinService.WorkerService();
                                        break;
                                    case "2":
                                        Console.WriteLine("No Component Necessary");
                                        break;
                                    case "3":
                                        DbFundamentals.SqlStatements();
                                        break;
                                    case "4":
                                        DbQueryMethAndConnect.ConnectToDbStore();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
                break;

            //web Fundamentals Launch
            case "2":
                {
                    WebFundamentalsClass.webFundamentalsMethod();
                }
                break;
            //Programming In C#
            case "3":
                {
                    Console.WriteLine("Managing Program Flow: 1");
                    Console.WriteLine("Create Types: 2");
                    Console.WriteLine("Using Types: 3");
                    Console.WriteLine("Debug And Security Implementation: 4");
                    Console.WriteLine("Manipulate And Retrieve Data: 5");
                    Console.WriteLine("Manage Multi Threading: 6");
                    Console.WriteLine("Memory Management And String Operations: 7");
                    Console.WriteLine("Implementing Data Access: 8");

                    answer = Console.ReadLine();
                    Console.WriteLine("\n");

                    switch (answer)
                    {
                        //Managing Program Flow
                        case "1":
                            {
                                Console.WriteLine("Variables: 1");
                                Console.WriteLine("Switch Statement: 2");
                                Console.WriteLine("If Else Statement: 3");
                                Console.WriteLine("For And For Each: 4");
                                Console.WriteLine("Operator And Evaluation Expressions: 5");
                                Console.WriteLine("Built In Delegate: 6");
                                Console.WriteLine("Creating And Using Delegates: 7");
                                Console.WriteLine("Lambda Expressions: 8");
                                Console.WriteLine("Anonymous Methods: 9");
                                Console.WriteLine("Subscribing To Events: 10");
                                Console.WriteLine("Event Handlers: 11");
                                Console.WriteLine("Exception WIth Multiple Catch Blocks: 12");
                                Console.WriteLine("The Finally Block: 13");
                                Console.WriteLine("Create Custom Exception Classes: 14");
                                Console.WriteLine("Context Specific Exception Handling: 15");
                                Console.WriteLine("Exception Handling In MultiThreading: 16");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");
                                //Run through file and fix
                                switch (answer)
                                {
                                    case "1":
                                        ManageProgramFlow.Variables();
                                        break;
                                    case "2":
                                        ManageProgramFlow.SwitchStatement();
                                        break;
                                    case "3":
                                        ManageProgramFlow.IfElseStatement();
                                        break;
                                    case "4":
                                        ManageProgramFlow.ForAndForEach();
                                        break;
                                    case "5":
                                        ManageProgramFlow.OperatorAndEvalExpressions();
                                        break;
                                    case "6":
                                        ManageProgramFlow.BuiltInDelegate();
                                        break;
                                    case "7":
                                        ManageProgramFlow.CreatingAndUsingDelegates();
                                        break;
                                    case "8":
                                        ManageProgramFlow.LambdaExpressions();
                                        break;
                                    case "9":
                                        ManageProgramFlow.AnonoymousMethods();
                                        break;
                                    case "10":
                                        ManageProgramFlow.SubscribingToEvents();
                                        break;
                                    case "11":
                                        ManageProgramFlow.EventHandlers();
                                        break;
                                    case "12":
                                        ManageProgramFlow.ExceptionWIthMultiCatchBlocks();
                                        break;
                                    case "13":
                                        ManageProgramFlow.TheFinallyBlock();
                                        break;
                                    case "14":
                                        ManageProgramFlow.CreateCustomExeptionClasses();
                                        break;
                                    case "15":
                                        ManageProgramFlow.ContextSpecificExeptionHandling();
                                        break;
                                    case "16":
                                        ManageProgramFlow.ExceptionHandlingInMultThreading();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //CreateTypes
                        case "2":
                            {
                                Console.WriteLine("Creating Structures: 1");
                                Console.WriteLine("Creating And Using Enums: 2");
                                Console.WriteLine("Creating And Using Classes: 3");
                                Console.WriteLine("Using Constructors: 4");
                                Console.WriteLine("Using Operational And Named Parameters: 5");
                                Console.WriteLine("Static Class And Members: 6");
                                Console.WriteLine("Extension Methods: 7");
                                Console.WriteLine("Indexers: 8");
                                Console.WriteLine("Overloading Vs Overriding: 9");
                                Console.WriteLine("Overloading Methods: 10");
                                Console.WriteLine("Overriding Methods: 11");
                                Console.WriteLine("Generics: 12");
                                Console.WriteLine("Generic Type: 13");
                                Console.WriteLine("Using Generic Methods: 14");
                                Console.WriteLine("Converting Value Types: 15");
                                Console.WriteLine("Converting Reference Types: 16");
                                Console.WriteLine("Boxing And Unboxing: 17");
                                Console.WriteLine("Using The Dynamic Runtime: 18");
                                Console.WriteLine("Using IConvertable: 19");
                                Console.WriteLine("Using IFormattable: 20");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        CreateTypes.CreatingStrctures();
                                        break;
                                    case "2":
                                        CreateTypes.CreatingAndUsingEnums();
                                        break;
                                    case "3":
                                        CreateTypes.CreatingAndUsingClasses();
                                        break;
                                    case "4":
                                        CreateTypes.UsingConstructors();
                                        break;
                                    case "5":
                                        CreateTypes.UsingOperationalAndNamedParameters();
                                        break;
                                    case "6":
                                        CreateTypes.StaticClassAndMembers();
                                        break;
                                    case "7":
                                        CreateTypes.ExtensionMethods();
                                        break;
                                    case "8":
                                        CreateTypes.Indexers();
                                        break;
                                    case "9":
                                        CreateTypes.OverloadingVsOverriding();
                                        break;
                                    case "10":
                                        CreateTypes.OverloadingMethods();
                                        break;
                                    case "11":
                                        CreateTypes.OverridingMethods();
                                        break;
                                    case "12":
                                        CreateTypes.Generics();
                                        break;
                                    case "13":
                                        CreateTypes.GenericType();
                                        break;
                                    case "14":
                                        CreateTypes.UsingGenericMethods();
                                        break;
                                    case "15":
                                        CreateTypes.ConvertingValueTypes();
                                        break;
                                    case "16":
                                        CreateTypes.ConvertingRefTypes();
                                        break;
                                    case "17":
                                        CreateTypes.BoxingAndUnboxing();
                                        break;
                                    case "18":
                                        CreateTypes.UsingTheDynamicRuntime();
                                        break;
                                    case "19":
                                        CreateTypes.UsingIConvertable();
                                        break;
                                    case "20":
                                        CreateTypes.UsingIFormattable();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //UsingTypes
                        case "3":
                            {
                                Console.WriteLine("Encapsulation - Defining Properties: 1");
                                Console.WriteLine("Auto Implement Properties: 2");
                                Console.WriteLine("Access Modifiers: 3");
                                Console.WriteLine("Encapsulation - Explicit Interfaces: 4");
                                Console.WriteLine("Class Hierarchy - Interfaces: 5");
                                Console.WriteLine("Consuming Types - Inheritance: 6");
                                Console.WriteLine("Class Hierarchy - Indexers: 7");
                                Console.WriteLine("Class Based On IEnumerable: 8");
                                Console.WriteLine("Class Based On IDisposable: 9");
                                Console.WriteLine("Understanding IUnknown And COM: 10");
                                Console.WriteLine("Implementing IComparable: 11");
                                Console.WriteLine("Consuming Types - Reflection: 12");
                                Console.WriteLine("Assembly, Property Info And Method Info: 13");
                                Console.WriteLine("Working With Attributes: 14");
                                Console.WriteLine("Custom Attribute Classes: 15");
                                Console.WriteLine("Consuming Types - Using Codedom: 16");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        UsingTypes.EncapsulationDefiningProperties();
                                        break;
                                    case "2":
                                        UsingTypes.AutoImplementProperties();
                                        break;
                                    case "3":
                                        UsingTypes.AccessModifiers();
                                        break;
                                    case "4":
                                        UsingTypes.EncapsulationExplicitInterfaces();
                                        break;
                                    case "5":
                                        UsingTypes.ClassHierarchyInterfaces();
                                        break;
                                    case "6":
                                        UsingTypes.ConsumingTypesInheritance();
                                        break;
                                    case "7":
                                        UsingTypes.ClassHierarchyIndexers();
                                        break;
                                    case "8":
                                        UsingTypes.ClassBasedOnIEnumerable();
                                        break;
                                    case "9":
                                        UsingTypes.ClassBasedOnIDisposable();
                                        break;
                                    case "10":
                                        UsingTypes.UnderstandingIUnknownAndCOM();
                                        break;
                                    case "11":
                                        UsingTypes.ImplementingIComparable();
                                        break;
                                    case "12":
                                        UsingTypes.ConsumingTypesReflection();
                                        break;
                                    case "13":
                                        UsingTypes.AssemblyPropertyInfoAndMethodInfo();
                                        break;
                                    case "14":
                                        UsingTypes.WorkingWithAttributes();
                                        break;
                                    case "15":
                                        UsingTypes.CustomAttributeClasses();
                                        break;
                                    case "16":
                                        UsingTypes.ConsumingTypesUsingCodedom();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //DebugAndSecImplement
                        case "4":
                            {
                                Console.WriteLine("Using Regex: 1");
                                Console.WriteLine("Validating Json Data: 2");
                                Console.WriteLine("Validating Connection Strings: 3");
                                Console.WriteLine("Basic Encryption: 4");
                                Console.WriteLine("Managing Certificates: 5");
                                Console.WriteLine("Hashing: 6");
                                Console.WriteLine("Symmetric Vs Asymmetric Encryption: 7");
                                Console.WriteLine("Debug And Security Strong naming: 8");
                                Console.WriteLine("Create Windows MD Assembly: 9");
                                Console.WriteLine("The Global Assembly Cache: 10");
                                Console.WriteLine("Compiler Directives: 11");
                                Console.WriteLine("Diagnostics And Tracing: 12");
                                Console.WriteLine("Working With Trace Switches: 13");
                                Console.WriteLine("Creating Performance Counters: 14");
                                Console.WriteLine("Writing To EventLogs: 15");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");
                                switch (answer)
                                {
                                    case "1":
                                        DebugAndSecImplement.UsingRegex();
                                        break;
                                    case "2":
                                        DebugAndSecImplement.ValidatingJsonData();
                                        break;
                                    case "3":
                                        DebugAndSecImplement.ValidatingConnectionStrings();
                                        break;
                                    case "4":
                                        DebugAndSecImplement.BasicEncryption();
                                        break;
                                    case "5":
                                        DebugAndSecImplement.ManagingCertificates();
                                        break;
                                    case "6":
                                        DebugAndSecImplement.Hashing();
                                        break;
                                    case "7":
                                        DebugAndSecImplement.SymmetricVsAssymertricEncryption();
                                        break;
                                    case "8":
                                        DebugAndSecImplement.DebugAndSecurityStrongnaming();
                                        break;
                                    case "9":
                                        DebugAndSecImplement.CreateWinMdAssembly();
                                        break;
                                    case "10":
                                        DebugAndSecImplement.TheGlobalAsseblyCache();
                                        break;
                                    case "11":
                                        DebugAndSecImplement.CompilerDirectives();
                                        break;
                                    case "12":
                                        DebugAndSecImplement.DiagnosticsAndTracing();
                                        break;
                                    case "13":
                                        DebugAndSecImplement.WorkingWithTraceSwitches();
                                        break;
                                    case "14":
                                        DebugAndSecImplement.CreatingPerformanceCounters();
                                        break;
                                    case "15":
                                        DebugAndSecImplement.WritingToEventLogs();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //ManipulateAndRetrieveData
                        case "5":
                            {
                                Console.WriteLine("Stored Procedures In A Model: 1");
                                Console.WriteLine("Query Syntax vs Method Syntax: 2");
                                Console.WriteLine("Working With The Where LINQ Operator: 3");
                                Console.WriteLine("Select Vs Select Many LINQ Operator: 4");
                                Console.WriteLine("Query Data Using Operators: 5");
                                Console.WriteLine("ConsumingData - LINQ To XML Data Part 1: 6");
                                Console.WriteLine("ConsumingData - LINQ To XML Data Part 2: 7");
                                Console.WriteLine("ConsumingData - XML Serialization: 8");
                                Console.WriteLine("ConsumingData - Json Serialization: 9");
                                Console.WriteLine("ConsumingData - Binary Serialization: 10");
                                Console.WriteLine("Typed Vs Non Typed Collections: 11");
                                Console.WriteLine("Managing Collections: 12");
                                Console.WriteLine("Using The Dictionary Object: 13");
                                Console.WriteLine("Using The List Object: 14");
                                Console.WriteLine("Using The Queue Object: 15");
                                Console.WriteLine("Implementing Dot Net Interfaces: 16");
                                answer = Console.ReadLine();
                                Console.WriteLine("\n");
                                switch (answer)
                                {
                                    case "1":
                                        ManipulateAndRetrieveData.StoredProceduresInAModel();
                                        break;
                                    case "2":
                                        ManipulateAndRetrieveData.QuerySintaxVsMethodSyntax();
                                        break;
                                    case "3":
                                        ManipulateAndRetrieveData.WorkingWithTheWhereLinqOperator();
                                        break;
                                    case "4":
                                        ManipulateAndRetrieveData.SelectVsSelectManyLinqOperator();
                                        break;
                                    case "5":
                                        ManipulateAndRetrieveData.QueryDataUsingOperators();
                                        break;
                                    case "6":
                                        ManipulateAndRetrieveData.ConsumingDataLinqToXmlDataPart1();
                                        break;
                                    case "7":
                                        ManipulateAndRetrieveData.ConsumingDataLinqToXmlDataPart2();
                                        break;
                                    case "8":
                                        ManipulateAndRetrieveData.ConsumingDataXmlSerialization();
                                        break;
                                    case "9":
                                        ManipulateAndRetrieveData.ConsumingDataJsonSerialization();
                                        break;
                                    case "10":
                                        ManipulateAndRetrieveData.ConsumingDataBinarySerialization();
                                        break;
                                    case "11":
                                        ManipulateAndRetrieveData.TypedVsNonTypedCollections();
                                        break;
                                    case "12":
                                        ManipulateAndRetrieveData.ManagingCollections();
                                        break;
                                    case "13":
                                        ManipulateAndRetrieveData.UsingTheDictionaryObject();
                                        break;
                                    case "14":
                                        ManipulateAndRetrieveData.UsingTheListObject();
                                        break;
                                    case "15":
                                        ManipulateAndRetrieveData.UsingTheQueeObject();
                                        break;
                                    case "16":
                                        ManipulateAndRetrieveData.ImplementingDotNetInterfaces();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //ManagePrManageMultiThreadingogramFlow
                        case "6":
                            {
                                Console.WriteLine("Throw Vs Re throw: 1");
                                Console.WriteLine("Locking: 2");
                                Console.WriteLine("Synchronization: 3");
                                Console.WriteLine("Cancellation Token: 4");
                                Console.WriteLine("Race Conditions: 5");
                                Console.WriteLine("Thread Safe Methods: 6");
                                Console.WriteLine("Task Based Asynchronous Programming: 7");
                                Console.WriteLine("Parallel Invoke Method: 8");
                                Console.WriteLine("Using The Parallel For Statement: 9");
                                Console.WriteLine("Parallel ForEach Method: 10");
                                Console.WriteLine("ThreadPool: 11");
                                Console.WriteLine("Unblock UI With Task: 12");
                                Console.WriteLine("Using Parallel LINQ: 13");
                                Console.WriteLine("Concurrent Collections: 14");
                                Console.WriteLine("Using Async And Await Keywords: 15");
                                Console.WriteLine("Using Tasks: 16");
                                Console.WriteLine("Continuation Tasks: 17");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        ManageMultiThreadingogramFlow.ThrowVsRethrow();
                                        break;
                                    case "2":
                                        ManageMultiThreadingogramFlow.Locking();
                                        break;
                                    case "3":
                                        ManageMultiThreadingogramFlow.Synchronization();
                                        break;
                                    case "4":
                                        ManageMultiThreadingogramFlow.CancellationToken();
                                        break;
                                    case "5":
                                        ManageMultiThreadingogramFlow.RaceConditions();
                                        break;
                                    case "6":
                                        ManageMultiThreadingogramFlow.ThreadSafeMethods();
                                        break;
                                    case "7":
                                        ManageMultiThreadingogramFlow.TaskBasedAsynchronousProgramming();
                                        break;
                                    case "8":
                                        ManageMultiThreadingogramFlow.ParallelInkvokeMethod();
                                        break;
                                    case "9":
                                        ManageMultiThreadingogramFlow.UsingTheParallelForStatement();
                                        break;
                                    case "10":
                                        ManageMultiThreadingogramFlow.ParallelForEachMethod();
                                        break;
                                    case "11":
                                        ManageMultiThreadingogramFlow.ThreadPool();
                                        break;
                                    case "12":
                                        ManageMultiThreadingogramFlow.UnblockUIWithTask();
                                        break;
                                    case "13":
                                        ManageMultiThreadingogramFlow.UsingParallelLinq();
                                        break;
                                    case "14":
                                        ManageMultiThreadingogramFlow.ConcurrentCollections();
                                        break;
                                    case "15":
                                        ManageMultiThreadingogramFlow.UsingTasks();
                                        break;
                                    case "16":
                                        ManageMultiThreadingogramFlow.ContinuationTasks();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //MemManagAndStringOps
                        case "7":
                            {
                                Console.WriteLine("Object Lifetime Garbage Collection: 1");
                                Console.WriteLine("Managing Unmanaged Resources: 2");
                                Console.WriteLine("Destructor: 3");
                                Console.WriteLine("Using Block: 4");
                                Console.WriteLine("String builder Class: 5");
                                Console.WriteLine("String Reader And Writer: 6");
                                Console.WriteLine("Basic String Methods: 7");
                                Console.WriteLine("Searching In Strings: 8");
                                Console.WriteLine("String Interpolation: 9");
                                Console.WriteLine("String Formatting: 10");
                                Console.WriteLine("Culture Specific String Manipulation: 11");
                                answer = Console.ReadLine();
                                Console.WriteLine("\n");
                                switch (answer)
                                {
                                    case "1":
                                        MemManagAndStringOps.ObjectLifetimeGarbageCollection();
                                        break;
                                    case "2":
                                        MemManagAndStringOps.ManagingUnmanagedResources();
                                        break;
                                    case "3":
                                        MemManagAndStringOps.Destructor();
                                        break;
                                    case "4":
                                        MemManagAndStringOps.UsingBlock();
                                        break;
                                    case "5":
                                        MemManagAndStringOps.StringbuilderClass();
                                        break;
                                    case "6":
                                        MemManagAndStringOps.StringReaderAndWriter();
                                        break;
                                    case "7":
                                        MemManagAndStringOps.BasicStringMethods();
                                        break;
                                    case "8":
                                        MemManagAndStringOps.SearchingInStrings();
                                        break;
                                    case "9":
                                        MemManagAndStringOps.StringInterpolation();
                                        break;
                                    case "10":
                                        MemManagAndStringOps.StringFormatting();
                                        break;
                                    case "11":
                                        MemManagAndStringOps.CultureSpecificStringManipulation();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;

                        //ImplementingDataAccess
                        case "8":
                            {
                                Console.WriteLine("IO Operations - Using FileStreams: 1");
                                Console.WriteLine("IO Operations - System.Net: 2");
                                Console.WriteLine("IO Operations - Network Credentials: 3");
                                Console.WriteLine("IO Operations - GZip Stream: 4");
                                Console.WriteLine("IO Operations - Asynchronous IO: 5");
                                Console.WriteLine("Selecting From Database: 6");
                                Console.WriteLine("Selecting With Anonymous Types: 7");
                                Console.WriteLine("Updating Through AModel: 8");
                                Console.WriteLine("Consuming Data Using LINQ Operators: 9");
                                Console.WriteLine("Forcing Query Execution: 10");
                                Console.WriteLine("Consuming Data From A Web Service: 11");
                                Console.WriteLine("Consuming Types Extension Methods: 12");

                                answer = Console.ReadLine();
                                Console.WriteLine("\n");

                                switch (answer)
                                {
                                    case "1":
                                        ImplementingDataAccess.IOOperationsUsingFilestreams();
                                        break;
                                    case "2":
                                        ImplementingDataAccess.IOOperationsSystemNet();
                                        break;
                                    case "3":
                                        ImplementingDataAccess.IOOperationsNetworkCredentials();
                                        break;
                                    case "4":
                                        ImplementingDataAccess.IOOperationsGZipStream();
                                        break;
                                    case "5":
                                        ImplementingDataAccess.IOOperationsAsynchronousIO();
                                        break;
                                    case "6":
                                        ImplementingDataAccess.SelectingFromDatabase();
                                        break;
                                    case "7":
                                        ImplementingDataAccess.SelectingWithAnonomousTypes();
                                        break;
                                    case "8":
                                        ImplementingDataAccess.UpdatingThroughAModel();
                                        break;
                                    case "9":
                                        ImplementingDataAccess.ConsumingDataUsingLinqOperators();
                                        break;
                                    case "10":
                                        ImplementingDataAccess.ForcingQueryExecution();
                                        break;
                                    case "11":
                                        ImplementingDataAccess.ConsumingDataFromAWebService();
                                        break;
                                    case "12":
                                        ImplementingDataAccess.ConsumingTypesExtentionMethods();
                                        break;
                                    default:
                                        Console.WriteLine("Error");
                                        break;
                                }
                            }
                            break;
                    }
                }
                break;

            //Developing Asp Net MVC Web Applications
            case "4":

                break;

            //Developing Microsoft Azure And Web Services
            case "5":

                break;

            //Developing Mobile Applications
            case "6":
                {
                    //System.Windows.Application app = new();
                    //_ = app.Run(new Project1.MainWindow());
                }
                break;

            //Python
            case "7":

                break;

            //Java SE 11 Developer
            case "8":

                break;

            //ISTQBSoftwareTesting
            case "9":

                break;

            //MicrosoftAzureDevOps
            case "10":

                break;

            //Declan
            case "11":
                {
                    Console.WriteLine("vehicleMain: 1");
                    Console.WriteLine("Sort: 2");
                    Console.WriteLine("DelegateLambdaAnonoymousFunctions: 3");

                    answer = Console.ReadLine();
                    Console.WriteLine("\n");

                    switch (answer)
                    {
                        case "1":
                            VehicleMain.vehicleMain();
                            break;
                        case "2":
                            Sort.BubbleSort();
                            break;
                        case "3":
                            DelegateLambdaAnonoymousFunctions.delegateLambdaAnonoymousFunctions();
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
                break;

            default:
                Console.WriteLine("Unknown command");
                break;
        }

        _ = Console.ReadKey();
        Console.WriteLine();

        goto Start; //Jumps to Start
    }

    //HTML Helper code Web Dev Basics
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            _ = webBuilder.UseStartup<Startup>();
            _ = webBuilder.ConfigureKestrel(options =>
            {
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(15);
                //webBuilder.Build();
            });
        });
    }
}
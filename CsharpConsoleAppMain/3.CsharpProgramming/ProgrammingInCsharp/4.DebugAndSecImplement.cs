#define DEBUG
#define TRACE

using CsharpConsoleAppMain.CsharpProgramming.Bank;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#pragma warning disable S1133

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class DebugAndSecImplement
{
    public static void UsingRegex()
    {
        Console.WriteLine("\nUsingRegex\n");
        ValidateREGEX();
        Console.WriteLine("Press any key to continue.\n");
        _ = Console.ReadKey();
    }

    // validate data using data annotations
    [Obsolete]
    public static void ValidatingJsonData()
    {
        Console.WriteLine("ValidatingJsonData");

        #region JSon Validation Basic

        JSchema schema = JSchema.Parse(@"{
            'Type': 'object',
            'properties': {
                'name': {'type':'string'},
                'roles': {'type': 'array'}
                }
          }");

        JObject user = JObject.Parse(@"{
    'name': 'James Bond',
    'roles': ['Security', 'Administrator']
}"
        );

        bool valid = user.IsValid(schema);
        Console.WriteLine(valid);

        #endregion JSon Validation Basic

        #region JSon Schema Generator

        Console.WriteLine("\nJSon Schema Generator");
        JSchemaGenerator generator = new();
        schema = generator.Generate(typeof(BankAccountDemo));
        //{
        //    "Type": "object",
        //    "properties" : {
        //        "email" : { "type": "string", "format": "email"}
        //    },
        //    "required" : ["email"]
        //}
        Console.WriteLine(schema);

        #endregion JSon Schema Generator

        #region Using JSchemaValidatingReader

        Console.WriteLine("\nUsing JSchema Validating Reader");
        schema = JSchema.Parse(@"{'type': 'array', 'item': {'type':'string'}}");
        JsonTextReader reader = new(
            new StringReader(@"['Developer', 'Administrator']"));

        JSchemaValidatingReader validatingReader = new(reader)
        {
            Schema = schema
        };

        JsonSerializer serializer = new();
        List<string> roles = serializer.Deserialize<List<string>>(validatingReader);
        Console.WriteLine("\nOutput");
        Console.WriteLine(reader.ToString());
        Console.WriteLine(schema);
        Console.WriteLine(serializer.ToString());
        Console.WriteLine(roles.ToString());
        Console.WriteLine(validatingReader.ToString());

        #endregion Using JSchemaValidatingReader

        #region Validate JSON with IsValid Example

        Console.WriteLine("\nValidate JSON with IsValid Example\n");

        const string schemaJson1 = @"{
                  'description': 'A person',
                  'type': 'object',
                  'properties':
                  {
                    'name': {'type':'string'},
                    'hobbies': {
                      'type': 'array',
                      'items': {'type':'string'}
                    }
                  }
                }";

        JsonSchema schema1 = JsonSchema.Parse(schemaJson1);

        JObject person1 = JObject.Parse(@"{
    'name': 'James',
    'hobbies': ['.NET', 'Blogging', 'Reading', 'Xbox', 'LOLCATS']
}");

        bool valid1 = person1.IsValid(schema1);
        Console.WriteLine(valid1);

        #endregion Validate JSON with IsValid Example

        #region Create new JSON Schemas in code example

        #endregion Create new JSON Schemas in code example

        #region Validate JSON with JsonValidatingReader

        #endregion Validate JSON with JsonValidatingReader
    }

    public static void ValidatingConnectionStrings()
    {
        Console.WriteLine("ValidatingConnectionStrings");

        SqlConnection c = new();
        Console.Write("Enter the data source: ");
        string? dataSource = Console.ReadLine();

        Console.Write("Enter the database name: ");
        string? catalog = Console.ReadLine();

        Console.Write("Enter your user ID: ");
        string? userid = Console.ReadLine();

        Console.Write("Enter your password: ");
        string? password = Console.ReadLine();
        c.ConnectionString = string.Format("server={0}; database={1}; user id = {2}; password={3}",
            dataSource, catalog, userid, password);
        Console.WriteLine("Connection String without validation: {0}", c.ConnectionString);

        SqlConnectionStringBuilder sb = new()
        {
            DataSource = dataSource,
            InitialCatalog = catalog,
            UserID = userid,
            Password = password
        };
        Console.WriteLine("Connection String Builder String: {0}", sb.ConnectionString);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void BasicEncryption()
    {
        Console.WriteLine("BasicEncryption");

        try
        {
            const string original = "The Quick Brown Fox Jumped Over The Lazy Dogs.";

            using AesCryptoServiceProvider myAes = new();
            byte[] encrypted = AesEncryptor.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

            string roundtrip = AesEncryptor.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

            Console.WriteLine("Original : \n {0}", original);
            Console.WriteLine("Encrypted Byte Array:");
            PrintByteArray(encrypted);
            Console.WriteLine("Round Trip: \n{0}", roundtrip);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region

    public static void PrintByteArray(byte[] encrypted)
    {
        Console.WriteLine(BitConverter.ToString(encrypted));
    }

    #endregion

    //fix
    public static void ManagingCertificates()
    {
        Console.WriteLine("ManagingCertificates");

        //WindowsFormsApp.Program.ManageCertificate();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void Hashing()
    {
        Console.WriteLine("Hashing");

        const string directory = @"C:\inetpub\wwwroot\CsharpConsoleAppMain.Net\Csharp\Hashing\";

        DirectoryInfo dir = new(directory);
        FileInfo[] files = dir.GetFiles();
        SHA256 aHasher = SHA256.Create();
        byte[] hashBytes;

        foreach (FileInfo flInfo in files)
        {
            FileStream fs = flInfo.Open(FileMode.Open);
            fs.Position = 0;
            hashBytes = aHasher.ComputeHash(fs);
            Console.Write(flInfo.Name + ":");
            HaveSomeHash(hashBytes);
            fs.Close();
        }
    }

    #region

    private static void HaveSomeHash(byte[] hashBytes)
    {
        Console.WriteLine(BitConverter.ToString(hashBytes));
    }

    #endregion

    public static void SymmetricVsAssymertricEncryption()
    {
        Console.WriteLine("SymmetricVsAssymertricEncryption");

        using (TripleDES tDES = TripleDES.Create())
        {
            Console.Write("Symmetric key generated in:\n");
            HaveSomeHash(tDES.Key);
            Console.Write("\nIV generated:");
            HaveSomeHash(tDES.IV);

            tDES.GenerateKey();
            tDES.GenerateIV();
            Console.WriteLine("----");
            Console.WriteLine("New Symmetric key generated in:\n");
            HaveSomeHash(tDES.Key);
            Console.Write("\nNew IV generated:");
            HaveSomeHash(tDES.IV);
        }

        ResetConsole("\nRSA Encryption is an example of Asymmetric:");

        try
        {
            UnicodeEncoding ByteConverter = new();
            const string original = "The quick brown fox jumped over the lazy dogs.";

            byte[] dataToEncrypt = ByteConverter.GetBytes(original);
            //Create byte arrays to hold original, encrypted, and decrypted data.

            byte[] encryptedData;
            byte[] decryptedData;

            using RSACryptoServiceProvider RSA = new();
            encryptedData = HugeKeysWithRSA.Cipher_It(dataToEncrypt, RSA.ExportParameters(false), false);
            decryptedData = HugeKeysWithRSA.Uncipher_It(encryptedData!, RSA.ExportParameters(true), false);
            Console.WriteLine("\nEncrypted Cipher\n");
            SomeHash(encryptedData!);
            Console.WriteLine("\nDecrypted plaintext: \n{0}", ByteConverter.GetString(decryptedData!));
        }
        catch (ArgumentNullException)
        {
            //Catch this exception in case the encryption did
            //not succeed.
            Console.WriteLine("Encryption failed.");
        }

        Console.WriteLine("\nPress enter to continue");
        _ = Console.ReadKey();

        Console.WriteLine("Second Asymetric encryption method");

        try
        {
            //initialze the byte arrays to the public key information.
            byte[] PublicKey =
            {
                214, 46, 220, 83, 160, 73, 40, 39, 201, 155, 19, 202, 3, 11, 191, 178, 56,
                74, 90, 36, 248, 103, 18, 144, 170, 163, 145, 87, 54, 61, 34, 220, 222,
                207, 137, 149, 173, 14, 92, 120, 206, 222, 158, 28, 40, 24, 30, 16, 175,
                108, 128, 35, 230, 118, 40, 121, 113, 125, 216, 130, 11, 24, 90, 48, 194,
                240, 105, 44, 76, 34, 57, 249, 228, 125, 80, 38, 9, 136, 29, 117, 207, 139,
                168, 181, 85, 137, 126, 10, 126, 242, 120, 247, 121, 8, 100, 12, 201, 171,
                38, 226, 193, 180, 190, 117, 177, 87, 143, 242, 213, 11, 44, 180, 113, 93,
                106, 99, 179, 68, 175, 211, 164, 116, 64, 148, 226, 254, 172, 147
            };

            byte[] Exponent = { 1, 0, 1 };

            //Values to store encrypted symmetric keys.
            byte[] EncryptedSymmetricKey;
            byte[] EncryptedSymmetricIV;

            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new();

            //Create a new instance of RSAParameters.
            RSAParameters RSAKeyInfo = new()
            {
                //Set RSAKeyInfo to the public key values.
                Modulus = PublicKey,
                Exponent = Exponent
            };

            //Import key parameters into RSA.
            RSA.ImportParameters(RSAKeyInfo);

            //Create a new instance of the Aes class.
            Aes aes = Aes.Create();

            //Encrypt the symmetric key and IV.
            EncryptedSymmetricKey = RSA.Encrypt(aes.Key, false);
            EncryptedSymmetricIV = RSA.Encrypt(aes.IV, false);

            Console.WriteLine("Aes Key and IV have been encrypted with RSACryptoServiceProvider.");

            Console.WriteLine("\nKey is {0}", EncryptedSymmetricKey);
            Console.WriteLine("IV is {0}", EncryptedSymmetricIV);
        }
        //Catch and display a CryptographicException
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            //Create a UnicodeEncoder to convert between byte array and string.
            ASCIIEncoding ByteConverter = new();

            const string dataString = "\nData to Encrypt";

            //Create byte arrays to hold original, encrypted, and decrypted data.
            byte[] dataToEncrypt = ByteConverter.GetBytes(dataString);
            byte[] encryptedData;
            byte[] decryptedData;

            //Create a new instance of the RSACryptoServiceProvider class
            // and automatically create a new key-pair.
            RSACryptoServiceProvider RSAalg = new();

            //Display the origianl data to the console.
            Console.WriteLine("Original Data: {0}", dataString);

            //Encrypt the byte array and specify no OAEP padding.
            //OAEP padding is only available on Microsoft Windows XP or
            //later.
            encryptedData = RSAalg.Encrypt(dataToEncrypt, false);

            //Display the encrypted data to the console.
            Console.WriteLine("Encrypted Data: {0}", ByteConverter.GetString(encryptedData));

            //Pass the data to ENCRYPT and boolean flag specifying
            //no OAEP padding.
            decryptedData = RSAalg.Decrypt(encryptedData, false);

            //Display the decrypted plaintext to the console.
            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
        }
        catch (CryptographicException e)
        {
            //Catch this exception in case the encryption did
            //not succeed.
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("\nPress any key to continue.");
        _ = Console.ReadKey();
    }

    #region

    private static void SomeHash(byte[] encryptedData)
    {
        Console.WriteLine(BitConverter.ToString(encryptedData));
    }

    #endregion

    public static void DebugAndSecurityStrongnaming()
    {
        Console.WriteLine("DebugAndSecurityStrongnaming");
        //ildasm.exe path
        //ilasm.exe full path
        //WindowsFormsApp.Program c = new WindowsFormsApp.Program();
        //Console.WriteLine(c.GetSomeInfo());
        //Console.WriteLine();

        //CsharpConsoleAppMain.Utilities u = new CsharpConsoleAppMain.Utilities();
        //Console.WriteLine(u.ComponentVersion);

        //developer command line
        //sn /?
        //sn - k C:\inetpub\wwwroot\CsharpConsoleAppMain.Net\Csharp\StrongNameKey\filename.snk

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void CreateWinMdAssembly()
    {
        Console.WriteLine("CreateWinMdAssembly");

        //Fix reference to assembly file
        //AppMath.App app = new AppMath.App();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void TheGlobalAsseblyCache()
    {
        Console.WriteLine("TheGlobalAsseblyCache");
        //drag and drop into global assembly cache
        //method two command prompt
        //gacutil /?
        //gacutil -i // only for development purpose..
        //prefered is using windows install
        //add project to do setup and deploment
        //install MSI in gacutil
        //change copy local to false in project properties
        //reference one in global cache instead of local
        //create switch statement
        //0: strong namig an assembly
        //1: Adding an assemblt ro the Gac

        //MyStrongNamedCompenent.Utilities u = new MyStrongNamedCompenent.Utilities();
        //Console.WriteLine(u.ComponentVersion);
        //var items = AppDomain.CurrentDomain.GetAssemblies()
        //    .Where(a => a.FullName.Contains("MyStrongNamedComponent"))
        //    .Select(a => String.Format("Assembly {0} GAC attribute: {1}, loaded from {2}", a.FullName, a.GlobalAssemblyCache));
        //foreach (var item in items)
        //{
        //    Console.WriteLine(item);
        //}
        IGacked();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region Helper code for Global Assembly Cache

    private static void IGacked()
    {
        //CsharpConsoleAppMain.Utilities utilities = new CsharpConsoleAppMain.Utilities();
        //Console.WriteLine(utilities.ComponentVersion);
        IEnumerable<string> items = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName.Contains("CsharpConsoleAppMain"))
            .Select(a => string.Format("Assembly {0} GAC attribute: {1}", a.FullName, a.GlobalAssemblyCache));
        foreach (string? item in items)
        {
            Console.WriteLine(item);
        }
    }

    //change copy local from property of strong named component to false, remove and add global cache reference
    //watch https://www.youtube.com/watch?v=NOkBUoP54b8 for install

    #endregion

    public static void CompilerDirectives()
    {
        Console.WriteLine("CompilerDirectives");

        //SetupUI();
        //GetChoice();
        CompileDirectives();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region Helper Code for Compiler Directives

    private static void CompileDirectives()
    {
        //note the meaning of the debug constant has nothing to do with running a debug build
        //But you can define the setting per build type (i.e. Usually do it for debug build, but not for release build)
        string isDebugDefined = string.Empty;
#if DEBUG
        isDebugDefined = "YES";
#else
            IsDebugDefined = "NO";
#endif

        Console.WriteLine("Defined? {0}", isDebugDefined);
        try
        {
            throw new UnauthorizedAccessException("Don't you even! UnauthorizedAccessException");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Don't do it, pal! Exception Warning");

#if DEBUG
            Console.WriteLine("Message for developer(s): {0}", ex);
#endif
        }

        ResetConsole("check output console for implementation");
#if DEBUG
#warning You're still in debug mode. Don't you want to deploy the release build?
#endif
    }

    #endregion

    public static void DiagnosticsAndTracing()
    {
        Console.WriteLine("DiagnosticsAndTracing");

        TracingMethod();
        //SecondCompileMethod();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void WorkingWithTraceSwitches()
    {
        Console.WriteLine("WorkingWithTraceSwitches");

        TraceSwitchFromConfig();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void CreatingPerformanceCounters()
    {
        Console.WriteLine("CreatingPerformanceCounters");

        ArrayList samplesList = new();

        // If the category does not exist, create the category and exit. Performance counters
        // should not be created and immediately used. There is a latency time to enable the
        // counters, they should be created prior to executing the application that uses the
        // counters. Execute this sample a second time to use the category.
        if (SetupCategory())
        {
            return;
        }

        CreateCounters();
        CollectSamples(samplesList);
        CalculateResults(samplesList);

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    public static void WritingToEventLogs()
    {
        Console.WriteLine("WritingToEventLogs");
        //fix location and output
        //output Bankaccount has written a log entry
        UsingTypes.EncapsulationExplicitInterfaces();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #region helper code for regex

    private static void ValidateREGEX()
    {
        const string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
        string[] names =
        {
            "Mr. Henry Hunt", "Ms. Sara Samuels",
            "Abraham Adams", "Ms. Nicole Norris"
        };
        foreach (string name in names)
        {
            Console.WriteLine(Regex.Replace(name, pattern, string.Empty));
        }

        ResetConsole("\nIdentify Duplicate Words:\n");

        const string pattern2 = @"\b(\w+?)\s\1\b";
        const string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.\n";
        foreach (Match match in Regex.Matches(input, pattern2, RegexOptions.IgnoreCase))
        {
            Console.WriteLine("{0} (duplicates '{1}') at position {2}\n",
                match.Value, match.Groups[1].Value, match.Index);
        }

        ResetConsole("Regex to catch HREF tags..\n");

        const string inputString = "My favorite web sites include:<p>\n" +
                                   "<A HREF=\"http://www.google.com\">" +
                                   "Google Home Page</A><P/>" +
                                   "<A HREF=\"http://www.microsoft.com\">" +
                                   "Microsoft Home Page</A><P/>" +
                                   "<A HREF=\"http://www.google.com\">" +
                                   "Google Home Page</A><P/>" +
                                   "<A HREF=\"http://www.yahoo.com\">" +
                                   "Yahoo Home Page</A><P/>";

        DumpHREFs(inputString);
    }

    private static void ResetConsole(string v)
    {
        Console.WriteLine(v);
    }

    private static void DumpHREFs(string inputString)
    {
        Match m;
        const string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

        try
        {
            m = Regex.Match(inputString, HRefPattern,
                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                TimeSpan.FromSeconds(10));
            while (m.Success)
            {
                Console.WriteLine("Found href" + m.Groups[1] + " at "
                                  + m.Groups[1].Index);
                m = m.NextMatch();
            }
        }
        catch (RegexMatchTimeoutException)
        {
            throw new Exception();
        }
    }

    #endregion helper code for regex

    #region Helper code for Diagnostics and Tracing

    //Create a class level trace switch
    private static readonly TraceSwitch traceSwitch = new("General", "Entire Application");

    //Run this on a "fresh" run through, so that the TraceLevel is not affected by the other method
    public static void TraceSwitchFromConfig()
    {
        AddListenerMethod();
        //Lets see what the setting is now
        Console.WriteLine("Current Trace Level Setting: {0} ({1})", (int)traceSwitch.Level, traceSwitch.Level);
        Console.WriteLine("Innitiate Trace Writer");

        //pass the value from the config file
        int valueFromConfig = (int)traceSwitch.Level;
        TraceWriterHelper(valueFromConfig);
    }

    public static void TracingMethod()
    {
        Console.WriteLine("\nAvailable TraceSwitch levels:\n");

        int[] traceNumber = (int[])Enum.GetValues(typeof(TraceLevel));
        string[] traceName = Enum.GetNames(typeof(TraceLevel));

        for (int i = 0; i < traceNumber.Length; i++)
        {
            Console.WriteLine("Trace Level {0} is {1}", traceNumber[i], traceName[i]);
        }

        //Default TraceListener: The Console
        foreach (int i in Enum.GetValues(typeof(TraceLevel)))
        {
            TraceLevel traceLevel = (TraceLevel)i;
            Console.WriteLine("\nMessage for TraceLevel {0}", traceLevel);
            Console.WriteLine();
            //DefaultTraceListener wrties to the Output Window
            TraceWriterHelper(traceLevel);
        }

        AddListenerMethod();

        Console.WriteLine("\nAdded Listeners");
        Console.WriteLine("\nTrace Listeners currently configured:");
        foreach (TraceListener traceListener in Trace.Listeners)
        {
            Console.WriteLine(traceListener.ToString());
        }
    }

    private static void AddListenerMethod()
    {
        //Setup additional TraceListener
        ConsoleTraceListener consoleListener = new(false) { Name = "Your Console Listener" };
        _ = Trace.Listeners.Add(consoleListener);
        Trace.WriteLine(consoleListener.Name);
        Trace.WriteLine(consoleListener.Attributes);
        Trace.WriteLine(consoleListener.ToString());

        //if the text file is out there, get rid of it for demo purposes...
        if (File.Exists("DontTraceFile.txt"))
        {
            File.Delete("DontTraceFile.txt");
        }

        TextWriterTraceListener txtListener = new("DontTraceFile.txt") { Name = "Your Text Listener" };
        _ = Trace.Listeners.Add(txtListener);
        Trace.WriteLine(txtListener.Name);
        Trace.WriteLine(txtListener.Attributes);
        Trace.WriteLine(txtListener.ToString());

        //Create the EventLog component first...
        const string sourceName = "EventLogCompenent";
        const string logName = "CSharpApplicationLog";

        if (EventLog.SourceExists(sourceName) || EventLog.Exists(logName))
        {
            EventLog.DeleteEventSource(sourceName);
            EventLog.Delete(logName);
        }
        else
        {
            EventLog.CreateEventSource(sourceName, logName);
        }

        EventLog eLog = new(logName, ".", sourceName);

        EventLogTraceListener eventListener = new(eLog) { Name = "Total Event Log" };
        _ = Trace.Listeners.Add(eventListener);

        Trace.WriteLine(eventListener.Name);
        Trace.WriteLine(eventListener.Attributes);
        Trace.WriteLine(eventListener.ToString());
    }

    //Todo :Change this to return VOID and write the traceSystem.ArgumentException: 'Source EventLogCompenent already exists on the local computer.'
    //so that it works with the other listeners
    private static void TraceWriterHelper(TraceLevel newLevel)
    {
        traceSwitch.Level = newLevel;

        try
        {
            // Create code for trace output
        }
        catch (Exception ex)
        {
            //No Need to do anything if the switch is off
            //Error
            Trace.WriteLineIf(traceSwitch.TraceError, string.Format("Error Level {0}", ex.Message));
            //Warning
            Trace.WriteLineIf(traceSwitch.TraceWarning, string.Format("Warning Level {0}", ex.TargetSite));
            //Info
            Trace.WriteLineIf(traceSwitch.TraceInfo, string.Format("Info Level {0}", ex.StackTrace));
            //Verbose
            Trace.WriteLineIf(traceSwitch.TraceVerbose, string.Format("Verbose Level {0}", ex));

            //Especially important when using TextWriterTraceListener
            //Without FLush, object might get destroyed too quickly to write
            Trace.Flush();
            Trace.Close();
        }
    }

    private static void TraceWriterHelper(int traceLevelNumber)
    {
        TraceWriterHelper((TraceLevel)traceLevelNumber);
    }

    public static void SecondCompileMethod()
    {
        Console.WriteLine("\nAlternative Method for Console Output:\n");

        _ = Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

        Trace.Indent();
        Trace.WriteLine("Entering Main method");
        Console.WriteLine("Hello World.");
        Trace.WriteLine("Exiting Main method");
        Trace.Unindent();
        Trace.Flush();

        Trace.Close();

        Console.WriteLine("Press any key to continue.");
        _ = Console.ReadKey();
    }

    #endregion

    #region Helper code for performance counters

    private static PerformanceCounter? avgCounter64Sample;
    private static PerformanceCounter? avgCounter64SampleBase;

    private static bool SetupCategory()
    {
        if (!PerformanceCounterCategory.Exists("AverageCounter64SampleCategory"))
        {
            CounterCreationDataCollection counterDataCollection = new();

            // Add the counter.
            CounterCreationData averageCount64 = new()
            {
                CounterType = PerformanceCounterType.AverageCount64,
                CounterName = "AverageCounter64Sample"
            };
            _ = counterDataCollection.Add(averageCount64);

            // Add the base counter.
            CounterCreationData averageCount64Base = new()
            {
                CounterType = PerformanceCounterType.AverageBase,
                CounterName = "AverageCounter64SampleBase"
            };
            _ = counterDataCollection.Add(averageCount64Base);

            // Create the category.
            _ = PerformanceCounterCategory.Create("AverageCounter64SampleCategory",
                "Demonstrates usage of the AverageCounter64 performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, counterDataCollection);

            return true;
        }

        Console.WriteLine("Category exists - AverageCounter64SampleCategory");
        return false;
    }

    private static void CreateCounters()
    {
        // Create the counters.

        avgCounter64Sample = new PerformanceCounter("AverageCounter64SampleCategory",
            "AverageCounter64Sample",
            false);

        avgCounter64SampleBase = new PerformanceCounter("AverageCounter64SampleCategory",
            "AverageCounter64SampleBase",
            false);

        avgCounter64Sample.RawValue = 0;
        avgCounter64SampleBase.RawValue = 0;
    }

    private static void CollectSamples(ArrayList samplesList)
    {
        Random r = new(DateTime.Now.Millisecond);

        // Loop for the samples.
        for (int j = 0; j < 100; j++)
        {
            int value = r.Next(1, 10);
            Console.Write(j + " = " + value);

            _ = avgCounter64Sample.IncrementBy(value);

            _ = avgCounter64SampleBase.Increment();

            if (j % 10 == 9)
            {
                OutputSample(avgCounter64Sample.NextSample());
                _ = samplesList.Add(avgCounter64Sample.NextSample());
            }
            else
            {
                Console.WriteLine();
            }

            Thread.Sleep(50);
        }
    }

    private static void CalculateResults(ArrayList samplesList)
    {
        for (int i = 0; i < samplesList.Count - 1; i++)
        {
            // Output the sample.
            OutputSample((CounterSample)samplesList[i]);
            OutputSample((CounterSample)samplesList[i + 1]);

            // Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " +
                              CounterSampleCalculator.ComputeCounterValue((CounterSample)samplesList[i],
                                  (CounterSample)samplesList[i + 1]));

            // Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                              MyComputeCounterValue((CounterSample)samplesList[i],
                                  (CounterSample)samplesList[i + 1]));
        }
    }

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    //    Description - This counter type shows how many items are processed, on average,
    //        during an operation. Counters of this type display a ratio of the items
    //        processed (such as bytes sent) to the number of operations completed. The
    //        ratio is calculated by comparing the number of items processed during the
    //        last interval to the number of operations completed during the last interval.
    // Generic type - Average
    //      Formula - (N1 - N0) / (D1 - D0), where the numerator (N) represents the number
    //        of items processed during the last sample interval and the denominator (D)
    //        represents the number of operations completed during the last two sample
    //        intervals.
    //    Average (Nx - N0) / (Dx - D0)
    //    Example PhysicalDisk\ Avg. Disk Bytes/Transfer
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    private static float MyComputeCounterValue(CounterSample s0, CounterSample s1)
    {
        float numerator = s1.RawValue - (float)s0.RawValue;
        float denomenator = s1.BaseValue - (float)s0.BaseValue;
        float counterValue = numerator / denomenator;
        return counterValue;
    }

    // Output information about the counter sample.
    private static void OutputSample(CounterSample s)
    {
        Console.WriteLine("\r\n+++++++++++");
        Console.WriteLine("Sample values - \r\n");
        Console.WriteLine("   BaseValue        = " + s.BaseValue);
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
        Console.WriteLine("   CounterType      = " + s.CounterType);
        Console.WriteLine("   RawValue         = " + s.RawValue);
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
        Console.WriteLine("++++++++++++++++++++++");
    }

    //private static bool SetupCategory()
    //{
    //    if(!PerformanceCounterCategory.Exists("DiagnosticsCategory"))
    //    {
    //        CounterCreationDataCollection performanceCounterCollection = new CounterCreationDataCollection();
    //        CounterCreationData performanceAverageCount = new CounterCreationData();

    // performanceAverageCount.CounterType = PerformanceCounterType.AverageCount64;
    // performanceAverageCount.CounterName = "averageSample"; performanceCounterCollection.Add(performanceAverageCount);

    // CounterCreationData performanceCountBase = new CounterCreationData();

    // performanceCountBase.CounterType = PerformanceCounterType.AverageBase;
    // performanceCountBase.CounterName = "averageSampleBase"; performanceCounterCollection.Add(performanceCountBase);

    // PerformanceCounterCategory.Create("DiagnosticsCategory", "Demonstrates usage of the
    // AverageCounter64 performance couner type.",
    // PerformanceCounterCategoryType.SingleInstance, performanceCounterCollection);

    //        return (true);
    //    }
    //    else
    //    {
    //        Console.WriteLine("Category exists - DiagnosticsCategory");
    //        return (false);
    //    }
    //}
    //public static void CreateCounter()
    //{
    //    averageReading = new PerformanceCounter("DiagnosticsCategory",
    //        "averageSample",
    //        false);

    // averageBase = new PerformanceCounter("DiagnosticsCategory", "averageSampleBase", false);

    //    averageReading.RawValue = 0;
    //    averageBase.RawValue = 0;
    //}
    //public static void CollectSamples(ArrayList samples)
    //{
    //    Random random = new Random(DateTime.Now.Millisecond);

    // for (int counter = 0; counter < 100; counter++) { int value = random.Next(1, 10);
    // Console.Write(counter + " = " + value);

    // averageReading.IncrementBy(value); averageBase.Increment();

    // if ((counter % 10) == 9) { ShowSampleInfo(averageReading.NextSample());
    // samples.Add(averageReading.NextSample()); } else Console.WriteLine(); System.Threading.Thread.Sleep(10);

    // }

    //}
    //public static void CalculateResults(ArrayList samplesList)
    //{
    //}
    //private static Single ComputerACounter(CounterSample s0, CounterSample s1)
    //{
    //}
    //public static void ShowSampleInfo(CounterSample s)
    //{
    //    s.GetType();

    //    s.ToString();
    //    Console.WriteLine("Method to string: {0} \nMethod get Type: {1}", s.ToString(),s.GetType());
    //}

    #endregion
}

#region helper code for Json Validate

public class BankAccountDemo
{
    //Json Validation
    [EmailAddress]
    [JsonProperty("email", Required = Required.Always)]
    public string? UserEmailId;
}

#endregion

#region helper code HugeKeysWithRSA

internal static class HugeKeysWithRSA
{
    public static byte[]? Cipher_It(byte[] DataToEncrypt, RSAParameters rsa_params, bool DoOAEPPadding)
    {
        try
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new())
            {
                RSA.ImportParameters(rsa_params);
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }

            return encryptedData;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return null;
        }
    }

    //public override byte[] Uncipher_It(byte[] encryptedData, System.Security.Cryptography.RSAEncryptionPadding padding) // bool fOAEP
    //{
    //    try
    //    {
    //        byte[] decryptedData;
    //        using (RSACryptoServiceProvider RSA = new())
    //        {
    //           decryptedData = RSA.Decrypt(encryptedData, true);
    //        }
    //        return decryptedData;
    //    }
    //    catch (CryptographicException e)
    //    {
    //        //Catch this exception in case the encryption did
    //        //not succeed.
    //        Console.WriteLine(e.Message);
    //    }
    //}
    public static byte[]? Uncipher_It(byte[] DataToDecrypt, RSAParameters rsa_params, bool DoOAEPPadding)
    {
        try
        {
            byte[] decryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new())
            {
                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(rsa_params);

                //Decrypt the passed byte array and specify OAEP padding.
                //OAEP padding is only available on Microsoft Windows XP or
                //later.
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }

            return decryptedData;
        }
        //Catch and display a CryptographicException
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.ToString());

            return null;
        }
    }
}

#endregion
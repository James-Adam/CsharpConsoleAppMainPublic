using ADOclass;
using CsharpConsoleAppMain.CsharpProgramming.Bank;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class ImplementingDataAccess
{
    public static void IOOperationsUsingFilestreams()
    {
        CleanUpFileDirectory();
        //Reading data from a FileStream
        const string assemblyPath =
            @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\";
        using FileStream fs = new(assemblyPath + "/SharedFolderForFileRequests/BigFile.txt",
            FileMode.Open, FileAccess.Read, FileShare.Read);
        byte[] bytes = new byte[fs.Length];
        int bytesToRead = (int)fs.Length;
        int bytesRead = 0;
        while (bytesToRead > 0)
        {
            int n = fs.Read(bytes, bytesRead, bytesToRead);
            if (n == 0)
            {
                break;
            }

            bytesRead += n;
            bytesToRead -= n;
        }

        bytesToRead = bytes.Length;
        Console.WriteLine("Read {0} bytes from original file...", bytesRead);

        //now lets write it somewhere else
        using (FileStream fsWrite = new(assemblyPath + "/SharedFolderForFileRequests/StreamedFile.txt",
                   FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
        {
            fsWrite.Write(bytes, 0, bytesToRead);
        }

        Console.WriteLine("Wrote new file successfully");
    }

    #region Helper code for IOOperationsUsingFilestreams

    private static void CleanUpFileDirectory()
    {
        // Method intentionally left empty.
    }

    #endregion Helper code for IOOperationsUsingFilestreams

    public static void IOOperationsSystemNet()
    {
        Console.WriteLine(WindowsIdentity.GetCurrent().Name);
        _ = Environment.MachineName;
        const string assemblyPath =
            @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\";
        WebRequest fileRequest =
            WebRequest.Create(assemblyPath +
                              "/SharedFolderForFileRequests/ForFileRequest.txt"); //@"file://" + computer_name +
        fileRequest.Method = "POST";

        Console.WriteLine("Object of type {0} created by WebRequest.Create...", fileRequest.GetType());

        string goAgain;
        Stream? readStream;
        do
        {
            Console.WriteLine("Enter the string you want to write:");

            string userInput = Console.ReadLine() + "\n";

            ASCIIEncoding encoder = new();
            byte[] byteArray = encoder.GetBytes(userInput);

            fileRequest.ContentLength = byteArray.Length;
            string contentLength = fileRequest.ContentLength.ToString();

            Console.WriteLine("\nThe content length id {0}.", contentLength);

            try
            {
                readStream = fileRequest.GetRequestStream();
            }
            catch
            {
                Console.WriteLine("Something bad happened. Try Again");
                return;
            }

            readStream.Write(byteArray, 0, userInput.Length);
            Console.WriteLine("\nThe string you entered was successfully written to the file");
            Console.Write("Go Again? (Y for Yes, Anything else for No):");
            goAgain = Console.ReadLine()[..1].ToUpper();
        } while (goAgain == "Y");

        readStream.Close();
    }

    public static void IOOperationsNetworkCredentials()
    {
        const string SecurelyStoredUserName = @"SomeDomain\UserName1";

        SecureString SecurelyStoredPassword = new();
        const string samplePassword = "P@ssw0rd!";
        foreach (char c in samplePassword)
        {
            SecurelyStoredPassword.AppendChar(c);
        }

        SecurelyStoredPassword.MakeReadOnly();
        Console.WriteLine("UserName: {0}", SecurelyStoredUserName);
        //This will not result = happy
        Console.WriteLine("Password: {0}", SecurelyStoredPassword);

        const string SecurelyStoredDomain = "";

        NetworkCredential myCred = new(
            SecurelyStoredUserName, SecurelyStoredPassword, SecurelyStoredDomain);

        CredentialCache myCache = new()
        {
            { new Uri("http://faculty.mathemetric.com"), "Basic", myCred },
            { new Uri("http://sales.mathemetric.com"), "Basic", myCred }
        };

        WebRequest wr = WebRequest.Create("http://www.mathemetric.com/getMetrics.svc");
        wr.Credentials = myCache;
        SecurelyStoredPassword.Dispose();
    }

    public static void IOOperationsGZipStream()
    {
        const string assemblyPath =
            @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\";

        FileInfo fi = new(assemblyPath + "/SharedFolderForFileRequests/BigFile.txt");
        _ = GZippy.Squish_It(fi);

        GZippy.Blow_it_Back_Up(new FileInfo
            (fi.FullName + ".gz"));
    }

    public static void IOOperationsAsynchronousIO()
    {
        //ResetEnvironment();

        Task t = Task.Factory.StartNew(Some_Expensive_File_Operation);
        Task t1 = new(somevoidmethod);
        Task<int> t2 = new(anIntReturnMethod);
        CancellationToken cToken = new();
        Task t3 = new(Some_Expensive_File_Operation, cToken);
        t3.Start();

        Console.WriteLine("The task is running now, but it's on another thread...");

        for (int x = 0; x < 100; x++)
        {
            Thread.Sleep(75);
            Console.WriteLine("...................Back in caller thread #{0}, X's value is {1}",
                Environment.CurrentManagedThreadId, x);
        }

        Console.WriteLine("Threads used for async  operation:");
        foreach (int i in threadsUsed)
        {
            Console.WriteLine(i + ",");
        }

        Console.WriteLine();
    }

    public static void SelectingFromDatabase()
    {
        //Querying through a model
        NORTHWNDEntities n = new();

        //Get a random country name
        Random r = new();
        int skipTo = r.Next(0, 20);
        IQueryable<string> query1 = (from c in n.Customers orderby c.Country select c.Country).Skip(skipTo).Take(1);
        string? selectedCountry = query1.FirstOrDefault();

        Console.WriteLine();
        Console.WriteLine("Listing customers from {0}", selectedCountry);

        //Get all the customers associated with that country
        //Notice: in the last query, we chose a PROPERTY. In this one, we're choosing the entire OBJECT
        IQueryable<Customer> query2 = from c in n.Customers where c.Country == selectedCountry select c;

        foreach (Customer? cust in query2)
        {
            Console.WriteLine("Customer {0,-20} is from {1,-10}, {2,-20}", cust.ContactName, cust.City, cust.Phone);
        }
    }

    public static void SelectingWithAnonomousTypes()
    {
        //Entity object
        NORTHWNDEntities entities = new();

        //Specific query: The whole object
        //just get the first 20 orders
        IQueryable<Order> orders = (from ord in entities.Orders select ord).Take(20);
        foreach (Order? order in orders)
        {
            Console.WriteLine("OrderID {0} was shipped to {1} on {2}",
                order.OrderID, order.ShipCity,
                DateTime.Parse(order.ShippedDate.ToString()).ToShortDateString());
        }

        Console.WriteLine("\nDo the same thing with anonymous types:");
        //How do you get "columns" in a LINQ query? With anonymous types...
        var orders2 = (from ord in entities.Orders
                       select new
                       {
                           ID = ord.OrderID,
                           WhereItWent = ord.ShipCity,
                           ShortenedDate = (DateTime)ord.ShippedDate
                       }).Take(20);

        //iterated over the new type... Note The Intellisense
        //Also LINQ to entities doesn't understand ToSHortDateString in the query,
        //so we have to cast it here
        Console.WriteLine();
        Console.WriteLine("Selecting With Anonymous Types");
        foreach (var order in orders2)
        {
            Console.WriteLine("Order {0} was shipped to {1} on {2}", order.ID,
                order.WhereItWent,
                order.ShortenedDate.ToShortDateString());
        }
    }

    public static void UpdatingThroughAModel()
    {
        //Get user Input on what to select... Always retrieve the Primary Key
        NORTHWNDEntities entities = new();
        var employeeList = from e in entities.Employees
                           select new
                           {
                               e.EmployeeID,
                               e.FirstName,
                               e.LastName
                           };
        foreach (var emp in employeeList)
        {
            Console.WriteLine("{0}{1} (ID: {2})", emp.FirstName, emp.LastName, emp.EmployeeID);
        }

        Console.WriteLine();
        Console.Write("Choose an employee by ID: ");
        int chosenID = int.Parse(Console.ReadLine());

        //Get a single "row, i.e. a single instance of an object in the model.
        //Don't use the anonymous type, we want an attached record
        ADOclass.Employee? empToUpdate = (from e in entities.Employees
                                          where e.EmployeeID == chosenID
                                          select e).SingleOrDefault();

        //make your required changes
        Console.Write("Enter new First Name for {0}{1}:",
            empToUpdate.FirstName, empToUpdate.LastName);
        empToUpdate.FirstName = Console.ReadLine();

        try
        {
            //changes show up on next run if not overwritten by newly copied database
            //i.e if Northwind SDF is not set to CopyToOutputDirectory=CopyAlways
            _ = entities.SaveChanges();
            Console.WriteLine("Save changes was successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("you ran into an error: {0}", ex.Message);
        }

        //Re-query to verify changed value exists in the database
        Console.WriteLine("Record for Employee {0} now in database:", empToUpdate.EmployeeID);
        ADOclass.Employee? updatedEmp = (from e in entities.Employees
                                         where e.EmployeeID == chosenID
                                         select e).SingleOrDefault();
        Console.WriteLine("Employee {0}: {1}{2}", updatedEmp.EmployeeID,
            updatedEmp.FirstName, updatedEmp.LastName);
    }

    public static void ConsumingDataUsingLinqOperators()
    {
        string[] names =
            { "Cody", "Raj", "Verne", "Julio", "Zachary", "Maria", "Dana", "Chen", "Martha", "Harriet" };

        IEnumerable<string> shortNames =
            from n in names
            where n.Length < 5
            select n;

        Console.WriteLine("WHERE: String Length < 5:");
        foreach (string x in shortNames)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine("\n");

        string[] full_names =
        {
            "Cody Blackwell", "Raj Chawanda", "Verne McKeagney", "Julio Chavez",
            "Zachary MacKenzie", "Maria Martinez", "Dana Powell", "Chen Lin", "Martha Stewart", "Harriet Lipsey"
        };

        IEnumerable<string> long_names =
            from n in full_names
            select n[n.IndexOf(' ', 0)..];

        Console.WriteLine("Select: Last Names (After the space, at least...)");
        foreach (string name in long_names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n");

        //compound From Clause
        string[] namesFirst =
            { "Cody", "Raj", "Verne", "Julio", "Zachary", "Maria", "Dana", "Chen", "Martha", "Harriet" };
        string[] namesLast =
        {
            "Blackwell", "Chawanda", "McKeagney", "Chavez", "MacKenzie", "Martinez", "Powell", "Lin", "Stewart",
            "Lipsey"
        };

        var selected_names =
            from first in namesFirst
            from last in namesLast
            where first.Length > last.Length
            select new { first, last };

        Console.WriteLine("Pairs where first name longer than last name:");
        foreach (var name in selected_names)
        {
            Console.WriteLine("{0} is less than {1}", name.first, name.last);
        }

        Console.WriteLine("\n");
        string[] names_again =
            { "Cody", "Raj", "Verne", "Julio", "Zachary", "Maria", "Dana", "Chen", "Martha", "Harriet" };
        IEnumerable<string> namesFromTheThird = names_again.Skip(2).Take(3);
        Console.WriteLine("Skip 2, Take 3:");

        foreach (string? n in namesFromTheThird)
        {
            Console.WriteLine(n);
        }

        NORTHWNDEntities entities = new();

        Console.WriteLine("\n");
        Console.WriteLine("Orderby: Sorted Regions (Decending):");
        IOrderedQueryable<ADOclass.Region> backwards_regions =
            from r in entities.Regions
            orderby r.RegionDescription descending
            select r;
        foreach (ADOclass.Region? region in backwards_regions)
        {
            Console.WriteLine("{0} : {1:C}", region.RegionID, region.RegionDescription);
        }

        Console.WriteLine("\n");

        var name_groups =
            from n in names_again
            group n by n.Length
            into g
            select new { namelength = g.Key, names = g };

        foreach (var g in name_groups)
        {
            Console.WriteLine("Names with a length of {0}:", g.namelength);
            foreach (string? n in g.names)
            {
                Console.WriteLine(n);
            }
        }

        Console.WriteLine("\n");

        //Aggregate
        int[] bunch_of_numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        double the_average = bunch_of_numbers.Average();
        Console.WriteLine("The average number is {0}.", the_average);

        int lowest = bunch_of_numbers.Min();
        int highest = bunch_of_numbers.Max();
        int sum = bunch_of_numbers.Sum();
        Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}", lowest, highest, sum);

        double[] readings = { 1.7, 2.3, 1.9, 4.1, 2.9 };
        double result =
            readings.Aggregate((running_result, next_factor) => Math.Atan(running_result) * next_factor);
        Console.WriteLine("Total product of all numbers: {0}", result);
        Console.WriteLine("\n");
    }

    public static void ForcingQueryExecution()
    {
        //Default behavior is to run query when iterated over
        Console.WriteLine("\nDefault behavior is to run query when iterated over");
        NORTHWNDEntities entities = new();
        IQueryable<Product> query = from p in entities.Products where p.ProductID % 5 == 0 select p;

        foreach (Product? product in query)
        {
            Console.WriteLine("{0}-{1}-{2:C}", product.ProductID, product.ProductName, product.UnitPrice);
        }

        //Create a static copy of data with ToArray, ToList
        Console.WriteLine("\nCreate a static copy of data with ToArray, ToList");
        List<Product> CertainProducts = query.ToList();

        //Do "List-type things" with it
        Console.WriteLine("\nDo 'List - type things' with it");
        Console.WriteLine("There are {0} products in the list", CertainProducts.Count);

        //Do array tings
        Console.WriteLine("\nDo array tings");
        Product[] CertainProductsArray = query.ToArray();
        Console.WriteLine("The UpperBound of the array is {0}", CertainProductsArray.GetUpperBound(0));

        //Add a new record through the model
        Console.WriteLine("\nAdd a new record through the model");
        try
        {
            _ = entities.Products.Add(new Product
            {
                ProductID = 99,
                ProductName = "Chaplan Home Stores decor package"
            });
            _ = entities.SaveChanges();
            Console.WriteLine("New record added to database for ProductID 99...");
        }
        catch (Exception)
        {
            Console.WriteLine("New record not saved");
            throw;
        }

        //is it in the List? is it not
        Console.WriteLine("\nis it in the List? is it not");
        Product? newRecordQuery = (from p in CertainProducts
                                   where p.ProductID == 99
                                   select p).SingleOrDefault();

        if (newRecordQuery == null)
        {
            Console.WriteLine("New record is not in list");
        }
        else
        {
            Console.WriteLine("New record inserted successfully");
        }
    }

    public static void ConsumingDataFromAWebService()
    {
        //// We need a proxy by creating a service reference first...
        //localhost.Service1 customerServiceProxy = new localhost.Service1();

        //Console.Write("Choose a customer ID:");
        //string customerID = Console.ReadLine();

        //string output = customerServiceProxy.GetCustomerByID(customerID);
        //Console.WriteLine("Raw XML Return:");
        //Console.WriteLine(output);

        //Console.WriteLine();
        //Console.WriteLine("Lets see that in a local object...");

        ////parse it out with LINQ to XML
        //XDocument doc = XDocument.Parse(output);
        //MathServiceConsole.MathServiceConsole mathServiceConsole = new MathServiceConsole.MathServiceConsole();

        //MathService.Program program = new MathService.Program();
    }

    public static void ConsumingTypesExtentionMethods()
    {
        MoneyInformation currency = new('$', "US Dollars") { MoneyAcronym = "USD" };
        CheckingAccount a1 = new("User 10", 50M, currency, 1500, "1234567890123");

        //Heres all the recent checks
        foreach (Check ck in a1.RecentCheckCollection)
        {
            Console.WriteLine("Check for account {0} posted on {1}", ck.AccountNumber,
                ck.DatePosted.ToShortDateString());
        }

        Console.WriteLine("{0} Total checks in Recent Checks Collection", a1.RecentCheckCollection.Count);
        Console.WriteLine();

        TimeSpan ts = new(7, 0, 0, 0);
        DateTime min = DateTime.Today - ts;
        //Bring Extension Method into scope if not in same namespace
        Console.WriteLine("{0} of which have been posted on or after {1}",
            a1.CustomTransactionCount(ts), min.ToLongDateString());
    }

    #region helper code for IOOperationsAsynchronousIO

    /// <summary>
    private static void somevoidmethod()
    {
        // Method intentionally left empty.
    }

    private static int anIntReturnMethod()
    {
        return 0;
    }

    /// <summary>
    /// </summary>
    /// </summary>
    public static List<int>? threadsUsed;

    //public static void ResetEnvironment()
    //{
    //}
    public static void Some_Expensive_File_Operation()
    {
        const int iterations = 100;

        StreamReader[] sr = new StreamReader[iterations];
        StreamWriter[] sw = new StreamWriter[iterations];
        threadsUsed = new List<int>();

        _ = Parallel.For(0, iterations, Console.WriteLine);
    }

    #endregion helper code for IOOperationsAsynchronousIO
}

#region helper code for IOOperationsGZipStream

public static class GZippy
{
    public static long Squish_It(FileInfo unsquished_file)
    {
        using FileStream unsquished_stream = unsquished_file.OpenRead();
        //what are we validating?
        Console.WriteLine(File.GetAttributes(unsquished_file.FullName));
        Console.WriteLine(FileAttributes.Hidden);
        Console.WriteLine(unsquished_file.Extension);
        _ = Console.ReadKey();
        long squished_length = 0;
        if ((File.GetAttributes(unsquished_file.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden &&
            unsquished_file.Extension != ".gz")
        {
            using FileStream squished_stream = File.Create(unsquished_file.FullName + ".gz");
            using GZipStream squisher = new(squished_stream, CompressionMode.Compress);
            unsquished_stream.CopyTo(squisher);
            Console.WriteLine("Original file ({0}) was {1} bytes, " + "Now its {2} bytes", unsquished_file.Name,
                unsquished_file.Length.ToString(),
                squished_stream.Length.ToString());
            squished_length = squished_stream.Length;
        }

        return squished_length;
    }

    public static void Blow_it_Back_Up(FileInfo squished_file)
    {
        using FileStream squished_stream = squished_file.OpenRead();
        string existing_file = squished_file.FullName;
        string new_file = existing_file.Remove(existing_file.Length - squished_file.Extension.Length);

        using FileStream expanded_stream = File.Create(new_file);
        using GZipStream expanded_zip_stream = new(squished_stream, CompressionMode.Decompress);
        expanded_zip_stream.CopyTo(expanded_stream);
        Console.WriteLine("We just decompressed it!");
    }
}

#endregion helper code for IOOperationsGZipStream
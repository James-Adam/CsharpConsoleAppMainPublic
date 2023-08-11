using Microsoft.Data.SqlClient;

namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService;

public static class DevAzureAndWebServiceIntroduction
{
    // Create and Configure a Data Provider
    //Need to connect to a new database
    public static void CreateAndConfigureDataProvider()
    {
        SqlConnection sc = new("server=localhost;database=ReportServer;integrated security=SSPI");
        sc.Open();
        SqlCommand scmd = new("select username from Users")
        {
            Connection = sc
        };
        SqlDataReader dr = scmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Console.WriteLine(dr["UserName"].ToString());
            }
        }

        dr.Close();
        sc.Close();

        Console.WriteLine();
    }

    //Building Queries that use Deferred Execution
    public static void BuildingQueriesThatUseDeferredExecution()
    {
        int[] numbers = { 1, 2, 3 };
        IEnumerable<double> query = from n in numbers
                                    select Square(n);
        foreach (double n in query)
        {
            Console.WriteLine(n);
        }
    }

    //helper class
    private static double Square(double n)
    {
        Console.WriteLine("Computing Square(" + n + ")...");
        return Math.Pow(n, 2);
    }
}
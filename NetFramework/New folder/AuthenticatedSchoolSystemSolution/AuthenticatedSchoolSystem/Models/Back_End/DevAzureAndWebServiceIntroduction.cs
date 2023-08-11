using System;
using System.Data.SqlClient;
using System.Linq;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public static class DevAzureAndWebServiceIntroduction
    {
        // Create and Configure a Data Provider
        //Need to connect to a new database
        public static void CreateAndConfigureDataProvider()
        {
            SqlConnection sc = new SqlConnection("server=localhost;database=ReportServer;integrated security=SSPI");
            sc.Open();
            SqlCommand scmd = new SqlCommand("select username from Users")
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

        public static void OnDuplicateKey()
        {
            int[] listOfItems = { 4, 2, 3, 1, 6, 4, 3 };
            System.Collections.Generic.IEnumerable<int> duplicates = listOfItems
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);
            foreach (int d in duplicates)
            {
                Console.WriteLine(d);
            }
        }
    }
}
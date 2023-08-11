using AuthenticatedSchoolSystem.Models;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace AuthenticatedSchoolSystem.Back_End.ADO
{
    public class ADO
    {
        //performing synchronous tasks with ADO.Net
        public void SynchronousADO()
        {
            SqlConnection sc =
                new SqlConnection("server=(localdb)\\MSSQLLocalDB; database=ReportServer;integrated security=SSPI");
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

            _ = Console.ReadLine();
        }

        //performing Asynchronous tasks with ADO.Net
        public async void ASynchronousADO()
        {
            SqlConnection sc = new SqlConnection("");
            await sc.OpenAsync();

            SqlCommand scmd = new SqlCommand("select username from Users")
            {
                Connection = sc
            };
            SqlDataReader dr = await scmd.ExecuteReaderAsync();
            if (dr.HasRows)
            {
                while (await dr.ReadAsync())
                {
                    Console.WriteLine(dr["UserName"].ToString());
                }
            }

            dr.Close();
            sc.Close();

            _ = Console.ReadLine();
        }

        //Using asynchronouse Operations in Entity
        public async void MainEFAsync()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var result = await (from u in dbContext.Users
                                    select new
                                    {
                                        Username = u.UserName
                                    }).ToListAsync();

                foreach (var s in result)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
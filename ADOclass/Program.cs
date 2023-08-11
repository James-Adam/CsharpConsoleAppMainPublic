using System;
using System.Linq;

namespace ADOclass
{
    public static class Program
    {
        public static void StoredProceduresInAModel()
        {
            NORTHWNDEntities entities = new NORTHWNDEntities();
            System.Collections.Generic.IEnumerable<CustOrderHist_Result> orderHistory = from e in entities.CustOrderHist("ALFKI")
                                                                                        select e;

            Console.WriteLine("Product Name {0,-27} Total", "");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (CustOrderHist_Result order in orderHistory)
            {
                Console.WriteLine("{0,-40}{1,7:C}", order.ProductName, order.Total);
            }
            _ = Console.ReadKey();
        }

        public static void QuerySintaxVsMethodSyntax()
        {
            EmpDbContext db = new EmpDbContext();
            System.Collections.Generic.IEnumerable<Employee> qry = db.Employees.Where(e => e.DepartmentID >= 10);

            var demo = db.Employees.Where(e => e.DepartmentID == 10)
                .Select(e => new { e.EmpName, e.Zone });

            var WhereExpr =
                from e in db.Employees
                where e.DepartmentID == 10
                select new { e.EmpName, e.Zone };

            Console.WriteLine("Employee Name {0,-27} Zone", "");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (var e in demo)
            {
                Console.WriteLine("{0,-40}{1,7:C}", e.EmpName, e.Zone);
            }
            _ = Console.ReadKey();
        }

        public static void WorkingWithTheWhereLinqOperator()
        {
            EmpDbContext db1 = new EmpDbContext();

            System.Collections.Generic.List<Employee> qry1 = db1.Employees.Where(e1 => e1.DepartmentID == 10).ToList();
            System.Collections.Generic.List<Employee> qry2 = db1.Employees.Where((e1, idx) => idx > 1).ToList();

            var WhereExpr1 =
                from e1 in db1.Employees
                where e1.DepartmentID == 10
                select new { e1.DepartmentID, e1.EmpName };

            System.Collections.Generic.IEnumerable<Employee> WhereExpr2 = db1.Employees.Where(e1 => e1.DepartmentID == 10);

            Console.WriteLine("Department ID\t\tEmployee Name");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (var e1 in WhereExpr1)
            {
                Console.WriteLine("{0}\t\t\t{1}", e1.DepartmentID, e1.EmpName);
            }
            _ = Console.ReadKey();

            Console.WriteLine("\nDepartment ID\t\tEmployee Name");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (Employee e1 in qry2)
            {
                Console.WriteLine("{0}\t\t\t{1}", e1.DepartmentID, e1.EmpName);
            }
            _ = Console.ReadKey();
        }

        public static void SelectVsSelectManyLinqOperator()
        {
            EmpDbContext db2 = new EmpDbContext();

            //var rstSelect = db2.Employees.Select(e2 => e2.Addresses);
            System.Collections.Generic.IEnumerable<Address> rstSelectMany = db2.Employees.SelectMany(e2 => e2.Addresses);

            //Console.WriteLine("Department Name\t\tEmployee Address");
            //Console.WriteLine("-".PadRight(70, '-'));

            //foreach (var e2 in rstSelect)
            //{
            //    Console.WriteLine("{0}", e2.);
            //}
            //Console.ReadKey();

            Console.WriteLine("\nDepartment ID\t\tEmployee Name");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (Address e2 in rstSelectMany)
            {
                Console.WriteLine("{0}\t\t\t\t{1}", e2.AddressLine, e2.City);
            }
            _ = Console.ReadKey();
        }

        public static void QueryDataUsingOperators()
        {
            //List<Employee> lstEmp = new List<Employee>
            //{
            //    new Employee {EmpId=1000, EmpName="John"},
            //    new Employee {EmpId=1001, EmpName="Smith"},
            //    new Employee {EmpId=1002, EmpName="Jane"}
            //};

            ////lstEmp.Select
            //lstEmp.SelectMany

            //    //join operators
            //lstEmp.Join
            //lstEmp.GroupJoin

            //    //partition operators
            //lstEmp.Take
            //lstEmp.TakeWhile
            //lstEmp.Skip
            //lstEmp.SkipWhile

            //    //aggregate operators
            //lstEmp.Sum
            //lstEmp.Min
            //lstEmp.Max
            //lstEmp.Aggregate
            //lstEmp.Average
            //lstEmp.Count
        }

        public static void ConsumingDataLinqToXmlDataPart1()
        {
            // Method intentionally left empty.
        }

        public static void ConsumingDataLinqToXmlDataPart2()
        {
            // Method intentionally left empty.
        }

        public static void ConsumingDataXmlSerialization()
        {
            // Method intentionally left empty.
        }

        public static void ConsumingDataJsonSerialization()
        {
            // Method intentionally left empty.
        }

        public static void ConsumingDataBinarySerialization()
        {
            // Method intentionally left empty.
        }

        public static void TypedVsNonTypedCollections()
        {
            // Method intentionally left empty.
        }

        public static void ManagingCollections()
        {
            // Method intentionally left empty.
        }

        public static void UsingTheDictionaryObject()
        {
            // Method intentionally left empty.
        }

        public static void UsingTheListObject()
        {
            // Method intentionally left empty.
        }

        public static void UsingTheQueeObject()
        {
            // Method intentionally left empty.
        }

        public static void ImplementingDotNetInterfaces()
        {
            // Method intentionally left empty.
        }
    }

    #region Helper code for QuerySintaxVsMethodSyntax

    public class EmpDbContext
    {
        public Employee[] Employees { get; } =
        {
            new Employee{ EmpId=1000, EmpName="James", Salary=10000, DepartmentID=10, Zone="North",

                Addresses= new Address[]
                {
                    new Address { AddressLine="96950 Hidden Ln",    City="Ashland", State="OH"},
                    new Address { AddressLine="8284 Hart St", City="Troy", State="NY"}
                }
            },
            new Employee{ EmpId=1001, EmpName="John", Salary=12000, DepartmentID=10, Zone="North",

                Addresses= new Address[]
                {
                    new Address { AddressLine="6980 Dorsett Rd", City="Troy", State="NY"}
                }
            },
            new Employee{ EmpId=1002, EmpName="Smith", Salary=11000, DepartmentID=20, Zone="North",

                Addresses= new Address[]
                {
                    new Address { AddressLine="5 E Truman Rd", City="Troy", State="NY"}
                }
            },
            new Employee{ EmpId=1003, EmpName="Jones", Salary=15000, DepartmentID=30, Zone="East",

                Addresses= new Address[]
                {
                    new Address { AddressLine="74 S Westgate St", City="Ashland", State="OH"},
                    new Address { AddressLine="8573 Lincoln Blvd", City="Troy", State="NY"},
                }
            },
            new Employee{ EmpId=1004, EmpName="Morgan", Salary=20000, DepartmentID=10, Zone="East",

                Addresses= new Address[]
                {
                    new Address { AddressLine="37 N Elm St #916", City="Ashland", State="OH"},
                    new Address { AddressLine="62 Austin St", City="Troy", State="NY"},
                }
            },
            new Employee{ EmpId=1005, EmpName="Gane", Salary=17000, DepartmentID=30, Zone="East",

                Addresses= new Address[]
                {
                    new Address { AddressLine="5 N Cleveland Massillon Rd", City="Ashland", State="OH"},
                    new Address { AddressLine="62 Monroe St", City="Troy", State="NY"},
                }
            },
        };

        public Department[] Departments { get; } = {
            new Department { DepId = 10, DeptName = "Sales" },
            new Department { DepId = 20, DeptName = "Accounting" },
            new Department { DepId = 30, DeptName = "Research" }
        };
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public int DepartmentID { get; set; }
        public string Zone { get; set; }
        public Address[] Addresses { get; set; }
    }

    public class Department
    {
        public int DepId { get; set; }
        public string DeptName { get; set; }
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    #endregion Helper code for QuerySintaxVsMethodSyntax
}
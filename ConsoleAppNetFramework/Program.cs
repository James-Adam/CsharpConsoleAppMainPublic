using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleAppNetFramework
{
    public class Program
    {
      
        public static void StoredProceduresInAModel()
        {
            NORTHWNDEntities entities = new NORTHWNDEntities();
            var orderHistory = from e in entities.CustOrderHist("ALFKI")
                               select e;

            Console.WriteLine("Product Name {0,-27} Total", "");
            Console.WriteLine("-".PadRight(70, '-'));

            foreach (var order in orderHistory)
            {
                Console.WriteLine("{0,-40}{1,7:C}", order.ProductName, order.Total);
            }
            Console.ReadKey();





        }
        public static void QuerySintaxVsMethodSyntax()
        {

        }
        public static void WorkingWithTheWhereLinqOperator()
        {

        }
        public static void SelectVsSelectManyLinqOperator()
        {

        }
        public static void QueryDataUsingOperators()
        {

        }
        public static void ConsumingDataLinqToXmlDataPart1()
        {

        }
        public static void ConsumingDataLinqToXmlDataPart2()
        {

        }
        public static void ConsumingDataXmlSerialization()
        {

        }
        public static void ConsumingDataJsonSerialization()
        {

        }
        public static void ConsumingDataBinarySerialization()
        {

        }
        public static void TypedVsNonTypedCollections()
        {

        }
        public static void ManagingCollections()
        {

        }
        public static void UsingTheDictionaryObject()
        {

        }
        public static void UsingTheListObject()
        {

        }
        public static void UsingTheQueeObject()
        {

        }
        public static void ImplementingDotNetInterfaces()
        {

        }
    }
}

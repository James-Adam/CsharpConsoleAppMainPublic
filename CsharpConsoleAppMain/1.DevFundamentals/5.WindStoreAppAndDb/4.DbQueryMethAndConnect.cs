using System.Xml;

namespace CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb;

public static class DbQueryMethAndConnect
{
    //using xml and accessing data stores
    public static void ConnectToDbStore()
    {
        using XmlReader reader = XmlReader.Create("Invoice.xml");

        while (reader.Read())
        {
            switch (reader.Name)
            {
                case "Date":
                    if (reader.Read())
                    {
                        Console.WriteLine("Date: {0}", reader.Value);
                    }

                    break;

                case "Number":
                    if (reader.Read())
                    {
                        Console.WriteLine("Invoice #: {0}", reader.Value);
                    }

                    break;

                case "Name":
                    if (reader.Read())
                    {
                        Console.WriteLine("Contact Name: {0}", reader.Value);
                    }

                    break;

                case "Company":
                    if (reader.Read())
                    {
                        Console.WriteLine("Company: {0}", reader.Value);
                    }

                    break;
            }
        }
    }
}
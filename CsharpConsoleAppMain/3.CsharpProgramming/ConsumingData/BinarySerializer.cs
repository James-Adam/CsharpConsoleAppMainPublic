using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CsharpConsoleAppMain.CsharpProgramming.ConsumingData;

public static class BinarySerializer
{
    public static void BinarySerializerMain()
    {
        try
        {
            Serialize();
            Console.WriteLine("Successfully created binary file");
            _ = Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error serializing: {0}", ex.Message);
        }

        try
        {
            Console.WriteLine("\nSuccessfully deserialized binary file\n");
            Deserialize();

            _ = Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deserializing: {0}", ex.Message);
        }
    }

    public static void Serialize()
    {
        PurchaseOrder purchaseOrder1 = new()
        {
            OrderDate = DateTime.Today.ToShortDateString(),
            SubTotal = 333,
            ShipCost = 12
        };
        PurchaseOrder purchaseOrder2 = new()
        {
            OrderDate = DateTime.Today.AddDays(-30).ToShortDateString(),
            SubTotal = 555,
            ShipCost = 12
        };
        PurchaseOrder purchaseOrder3 = new()
        {
            OrderDate = DateTime.Today.AddDays(-90).ToShortDateString(),
            SubTotal = 777,
            ShipCost = 12
        };

        //Create a hashtable of values that will eventually be serialized
        Hashtable currentPurchaseOrders = new()
        {
            { "Sundries", purchaseOrder1 },
            { "Office Supplies", purchaseOrder2 },
            { "Electronics", purchaseOrder3 }
        };

        FileStream fs =
            new(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\purchaseOrder-Data.dat",
                FileMode.Create);

        BinaryFormatter formatter = new();
        {
            try
            {
                formatter.Serialize(fs, currentPurchaseOrders);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize, Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }

    public static void Deserialize()
    {
        Hashtable? purchasOrders = null;

        FileStream fs =
            new(
                @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\3.CsharpProgramming\ConsumingData\purchaseOrder-Data.dat",
                FileMode.Open);
        try
        {
            BinaryFormatter formatter = new();

            purchasOrders = (Hashtable)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to deserialize, Reason:" + e.Message);
        }
        finally
        {
            fs.Close();
        }

        foreach (DictionaryEntry de in purchasOrders)
        {
            Console.WriteLine("{0}'s Information: {1}", de.Key, de.Value);
        }
    }
}
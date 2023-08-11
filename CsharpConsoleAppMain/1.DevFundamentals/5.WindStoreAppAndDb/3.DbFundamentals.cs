namespace CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb;

public static class DbFundamentals
{
    public static void SqlStatements()
    {
        Console.WriteLine("SQL Statements");
        Console.WriteLine("\nPress any key to continue");
        _ = Console.ReadKey();

        Console.WriteLine("\nDatebaseCreation:");
        Console.WriteLine("\nCreate database");
        Console.WriteLine("alter database");
        Console.WriteLine("drop database");
        Console.WriteLine("use");

        Console.WriteLine("\nDatabase Manipulation");
        Console.WriteLine("\nselect");
        Console.WriteLine("insert");
        Console.WriteLine("update");
        Console.WriteLine("delete");
        Console.WriteLine("replace");

        Console.WriteLine("\nTable");
        Console.WriteLine("\ncreate table");
        Console.WriteLine("alter table");
        Console.WriteLine("drop table");
        Console.WriteLine("create index");
        Console.WriteLine("drop index");

        Console.WriteLine("\nLogical Operators");
        Console.WriteLine("\nOperator:    Function:                       Example:");
        Console.WriteLine("\nAll          Compare to all values           SELECT ALL FROM customers");
        Console.WriteLine("AND          More than one condition         SELECT customerid AND customername");
        Console.WriteLine(
            "ANY          Compares to any prvdd condition SELECT invoice FROM sales WHERE total > ANY (100, 200, 300)");
        Console.WriteLine("AS           Change field name (alias)       SELECT customerid AS customername");
        Console.WriteLine("BETWEEN      Select a range of values        SELECT total BETWEEN 100 AND 300");
        Console.WriteLine("IN           Equal to provided value         total IN (100, 200, 300");
        Console.WriteLine("IS           Compare to empty value (null)   total is NULL");
        Console.WriteLine(
            "LIKE         Searches pattern                SELECT total FROM sales WHERE total LIKE 100");
        Console.WriteLine("OR           Logical OR                      SELECT customerid OR customername");

        Console.WriteLine("\nPress any key to continue");
        _ = Console.ReadKey();
    }
}
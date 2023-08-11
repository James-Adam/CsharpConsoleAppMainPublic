namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals;

public static class DataStructures
{
    public static void IntroToLists()
    {
        Console.WriteLine("Example 1");
        List<string> listed = new()
        {
            "This",
            "is",
            "a",
            "C# List"
        };
        Console.WriteLine(listed.Count);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2");
        List<string> list = new()
        {
            "This",
            "is",
            "a",
            "C# List"
        };
        Console.WriteLine(list[3]);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        List<string> list1 = new()
        {
            "This",
            "is",
            "a",
            "C# List"
        };
        foreach (string item in list1)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 4");
        List<string> list2 = new()
        {
            "This",
            "is",
            "a",
            "C# List"
        };
        _ = list2.Remove("a");
        foreach (string item in list2)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void IntroToArrays()
    {
        Console.WriteLine("Example 1");
        string[] sentence = new string[4] { "The", "Quick", "Brown", "Fox" };
        foreach (string word in sentence)
        {
            Console.Write("{0} ", word);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2");
        string[,] names = new string[3, 2] { { "John", "Smith" }, { "Anna", "Johnson" }, { "Sally", "Jones" } };
        Console.WriteLine(names[1, 0] + names[1, 1]);
        Console.WriteLine();
        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        string[,] names1 = new string[3, 2] { { "John", "Smith" }, { "Anna", "Johnson" }, { "Sally", "Jones" } };

        //Console.WriteLine((names1[1, 0] + names1[1, 1]));
        for (int j = 0; j < names1.GetLength(0); j++)
        {
            int k = 0;
            Console.Write("{0} {1}", names1[j, k], names[j, k + 1]);
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void IntroToQuees()
    {
        Console.WriteLine("Example 1");
        Console.WriteLine("Queue");
        Queue<int> queue = new();
        queue.Enqueue(10);
        queue.Enqueue(100);
        queue.Enqueue(500);
        queue.Enqueue(1000);
        foreach (int i in queue)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2");
        Console.WriteLine("Array");
        int[] myArray = new int[queue.Count];
        queue.CopyTo(myArray, 0); //copy queue to array
        foreach (int j in myArray)
        {
            Console.WriteLine(j);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        Console.WriteLine("Dequeue");
        Queue<int> queue1 = new();
        queue1.Enqueue(10);
        queue1.Enqueue(100);
        queue1.Enqueue(500);
        _ = queue1.Dequeue();
        foreach (int i in queue1)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 4");
        Console.WriteLine("Search for Queues");
        if (queue1.Contains(500))
        {
            Console.WriteLine("Found 500");
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 5");
        Console.WriteLine("Clear  Queues");
        queue1.Clear();

        Console.WriteLine();
        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void IntroToStacks()
    {
        Console.WriteLine("Example 1");
        Stack<int> stack = new();
        stack.Push(10);
        stack.Push(100);
        stack.Push(500);
        stack.Push(1000);

        foreach (int i in stack)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2, copy stack to array");
        Stack<int> stack1 = new();
        stack1.Push(10);
        stack1.Push(100);
        stack1.Push(500);
        stack1.Push(1000);

        int[] array = new int[stack1.Count];
        stack1.CopyTo(array, 0);
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");
        int k = stack1.Count;
        Console.WriteLine(k);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 4");
        if (stack.Contains(500))
        {
            Console.WriteLine("Found 5000");
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 5");
        _ = stack.Pop();
        foreach (int i in stack)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void IntroToLinkedLists()
    {
        Console.WriteLine("Example 1");

        LinkedList<string> MyLL = new();
        _ = MyLL.AddLast("orange");
        _ = MyLL.AddFirst("apple");
        _ = MyLL.AddLast("cherry");
        _ = MyLL.AddFirst("banana");

        foreach (string fruit in MyLL)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2");
        LinkedListNode<string>? i = MyLL.Find("banana");
        _ = MyLL.AddBefore(i!, "Fruit:");
        foreach (string fruit in MyLL)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        Console.WriteLine("Example 3");

        _ = MyLL.Remove("banana");
        foreach (string fruit in MyLL)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }

    public static void SelectDataStruct()
    {
        Console.WriteLine("Listed Above Examples");

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();
    }
}
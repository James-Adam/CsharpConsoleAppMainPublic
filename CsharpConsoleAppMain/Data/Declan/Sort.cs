namespace CsharpConsoleAppMain.Data.Declan;

public static class Sort
{
    public static void BubbleSort()
    {
        int[] data = { 7, 3, 9, 10, 5, 11 };

        Console.WriteLine("Before");
        //printing data
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + ",");
        }

        Console.WriteLine();

        // @NOTE: Bubble sort
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    // @SWAP THE VALUES
                    (data[j + 1], data[j]) = (data[j], data[j + 1]);
                }
            }
        }

        // length = 4
        //[5][4][6][3]
        // temp = 5

        // 0 1 2 3

        Console.WriteLine("After");
        //printing data out
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + ",");
        }

        Console.WriteLine();

        _ = Console.ReadLine();
    }
}
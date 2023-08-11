using System.IO;

namespace CsharpConsoleAppMain.DevFundamentals.ProgramTechniques;

public static class BasicProgPract
{
    public static void IntroToRecursion()
    {
        Console.WriteLine("Example 1: Recursion");
        const int number = 0;
        Console.WriteLine("Even Numbers:");
        evenNums(number);
        Console.WriteLine("Done!");

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    //Intro to Recursion method 2
    private static void evenNums(int i)
    {
        if (i <= 1000)
        {
            Console.Write("{0}", i);
            i += 2;
            evenNums(i);
        }
    }

    public static void IntroToExceptionHandling()
    {
        Console.WriteLine("Example 1: Exception Handling");

        try
        {
            int i = 1 / int.Parse("0"); //get passed debugging and forcing an error
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void HowToCaptureUserInput()
    {
        Console.WriteLine("Example 1: Capture user input");

        Console.WriteLine("Type an Integer");
        string? input = Console.ReadLine(); //read string from console
        Console.WriteLine("You typed {0}", input);

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();

        Console.WriteLine("Example 2: Capture user input a step further");

        if (int.TryParse(input, out int num)) //try to parse string as integer
        {
            Console.Write("Multiply by 1000: ");
            Console.WriteLine(num * 1000);
        }
        else
        {
            Console.WriteLine("Not an Integer!");
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToRandomization()
    {
        Console.WriteLine("Example 1: Randomization");
        Random random = new();
        for (int i = 0; i < 10; i++)
        {
            int randomNumber = random.Next(0, 3); // not include 3
            string fruit;
            switch (randomNumber)
            {
                case 0:
                    fruit = "an apple";
                    break;

                case 1:
                    fruit = "an orange";
                    break;

                case 2:
                    fruit = "a banana";
                    break;

                default:
                    return;
            }

            Console.WriteLine("i think you should have {0}", fruit);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void HowToCreateRandomListOfNumbers()
    {
        Console.WriteLine("Example 1: How To Create Random List Of Numbers");

        int[] RandomNums = new int[100];
        byte k = 0;
        Random random = new();
        while (k < 100)
        {
            int randomNumber = random.Next(1, 101); //not include 0 and up to 100, not 101
            bool addToArray = true;
            for (int l = 0; l < k; l++)
            {
                if (RandomNums[l] == randomNumber)
                {
                    addToArray = false;
                    break;
                }
            }

            if (addToArray)
            {
                RandomNums[k] = randomNumber;
                k++;
            }
        }

        Console.WriteLine(Environment.NewLine + "Length: " + RandomNums.Length + Environment.NewLine);
        foreach (int i in RandomNums)
        {
            Console.Write("{0}, ", i);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void IntroToSortingAlgorithms()
    {
        Console.WriteLine(
            "Insertion" +
            "\nSelection" +
            "\nBubble" +
            "\nShell" +
            "\nMerge" +
            "\nHeap" +
            "\nQuick" +
            "\nQuick3");
        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    public static void TheQuickSortAlgorithm()
    {
        Console.WriteLine("Example 1: How To Create a quick sort algorithm from Random List Of Numbers");

        int[] SortList = new int[100];
        byte i = 0;
        Random random = new();
        while (i < 100)
        {
            int randomNumber = random.Next(1, 101); //not include 0 and up to 100, not 101
            bool addToArray = true;
            for (int j = 0; j < i; j++)
            {
                if (SortList[j] == randomNumber)
                {
                    addToArray = false;
                    break;
                }
            }

            if (addToArray)
            {
                SortList[i] = randomNumber;
                i++;
            }
        }

        Console.WriteLine(Environment.NewLine + "Unsorted: " + Environment.NewLine);
        foreach (int k in SortList)
        {
            Console.Write("{0}, ", k);
        }

        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press ENTER");
        _ = Console.ReadLine();

        quickSort(SortList, 0, SortList.Length - 1);
        Console.WriteLine("Sorted: " + Environment.NewLine);
        foreach (int m in SortList)
        {
            Console.Write("{0}, ", m);
        }

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    //quicksort method
    private static void quickSort(int[] SortList, int left, int right) //left and right never change but l and r do
    {
        int l = left;
        int r = right;
        int Pivot = SortList[(l + r) / 2];

        while (l <= r) //loop until l is equal to r
        {
            while (SortList[l] < Pivot) //move the left point up one
            {
                l++;
            }

            while (Pivot < SortList[r]) //move the r down one
            {
                r--;
            }

            if (l <= r) //swapping numbers
            {
                (SortList[r], SortList[l]) = (SortList[l], SortList[r]);
                l++;
                r--;
            }

            if (left < r)
            {
                quickSort(SortList, left, r); //recursion - call quicksort
            }

            if (l < right)
            {
                quickSort(SortList, l, right);
            }
        }
    }

    public static void HowToReadAndDisplayFiles()
    {
        Console.WriteLine("Read and display File");

        LoadFile();

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }

    //load file method
    private static void LoadFile()
    {
        StreamReader inpFile = File.OpenText("C:/inetpub/wwwroot/CsharpConsoleAppMain/info.txt");
        Console.WriteLine(inpFile.ReadToEnd());
    }

    public static void HowToCreateFileAndWriteData()
    {
        Console.WriteLine("How To Create File And Write Data");
        const string TextToAdd = "The quick brown fox jumped over the lazy dogs.";
        StreamWriter outfile = new("../../newfile.txt");
        outfile.WriteLine(TextToAdd);
        outfile.Close();

        Console.WriteLine("Press Enter");
        _ = Console.ReadKey();
    }
}
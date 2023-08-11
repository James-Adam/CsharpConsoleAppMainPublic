namespace CsharpConsoleAppMain.DevFundamentals.OOPFund;

public static class IntroToOOP
{
    public static void introToOOP()
    {
        //How to Create Objects
        // Object variable = new object (var)

        Console.WriteLine("\ncreating a class in C#");
        Fruit fruit = new("Apple", 0.5, 12);
        string newFruit = fruit.GetFruit();
        double total = fruit.GetCost();
        Console.WriteLine("\nHow to Create Objects");
        Console.WriteLine("\nKind of fruit: {0}", newFruit);
        Console.WriteLine("Cost per dozon: ${0}", total);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        //Object Properties
        Console.WriteLine("\nObject Properties");

        Fruit1 fruit1 = new()
        {
            Kind = "Macintosh",
            Cost = 0.5
        };
        string newFruit1 = fruit1.GetFruit();
        double total1 = fruit1.GetCost();
        Console.WriteLine("\nKind of fruit: {0}", newFruit1);
        Console.WriteLine("Cost per dozon: ${0}", total1);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        //Access objects with the This Keyword
        Console.WriteLine("\nAccess objects with the This Keyword");
        Fruit2 fruit2 = new("Apple", 0.5);
        _ = fruit2.GetKind();
        double total2 = fruit2.GetCost();

        Console.WriteLine("\nCost per dozon: ${0}", total2);

        Console.WriteLine("Press Enter to Continue");
        _ = Console.ReadKey();

        ////intro to events
        //Console.WriteLine("\nIntro to Events");
        //Fruit3 fruit3 = new Fruit3();
        //fruit3.NewEvent3 += new EventHandler(NewKind3);

        //Console.WriteLine("Press Enter to Continue");
        //Console.ReadKey();

        //Intro to Static Members
        Console.WriteLine("\nIntro to Static Members");

        Fruit4 fruit4 = new() { Kind = "Macintosh", Cost = 0.5, Amount = 12 };
        Console.WriteLine("\nFruit: {0}{1}", Fruit4.FruitType, fruit4.GetFruit4());
        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();

        //Intro to structs
        Console.WriteLine("\nIntro to structs");

        Coords c1 = new()
        {
            X = 100,
            Y = 500
        };
        Coords c2 = c1;
        Console.WriteLine(c2.X + c2.Y);

        Console.WriteLine("\nPress Enter to Continue");
        _ = Console.ReadKey();
    }

    //creating a class in C#
    private class Fruit //template for object
    {
        private readonly double amount;

        private readonly double cost;

        //variables
        private readonly string kind;

        //fruit object
        public Fruit(string k, double c, double a)
        {
            //asign
            kind = k;
            cost = c;
            amount = a;
        }

        // method
        public string GetFruit()
        {
            return kind + ", Cost: $" + cost;
        }

        public double GetCost()
        {
            return cost * amount;
        }
    }

    //Object Properties
    private class Fruit1
    {
        private double cost;
        private string? kind;

        //properties use capital letter
        public string Kind
        {
            get => kind;
            set
            {
                if (value == "Macintosh")
                {
                    kind = "Apple";
                }
            }
        }

        public double Cost
        {
            set
            {
                if (cost < 0.6)
                {
                    cost = 0.6;
                }
            }
        }

        //method
        public string GetFruit()
        {
            return Kind;
        }

        public double GetCost()
        {
            return cost * 12;
        }
    }

    //Access objects with the This Keyword
    private class Fruit2
    {
        private readonly double cost;
        private readonly string kind;

        //property
        public Fruit2(string k, double c)
        {
            kind = k;
            cost = c;
        }

        //methods
        public string GetKind()
        {
            return kind;
        }

        public double GetCost()
        {
            return cost * 12;
        }
    }

    // //intro to events
    // public static void NewKind3(object newk3, EventArgs e)
    // {
    //     Fruit3 fruit3 = (Fruit3)newk3;
    //     Console.WriteLine("Fruit change to {0}", Fruit3.Kind3);
    // }
    //public class Fruit3
    // {
    //     public event EventHandler NewEvent3;
    //     private string kind3;
    //     public string Kind3
    //     {
    //         get { return kind3; }
    //         set
    //         {
    //             kind3 = value;
    //             NewEvent3(this, EventArgs.Empty);
    //         }
    //     }
    // }

    //Intro to Static Members
    private class Fruit4
    {
        public static string FruitType => "apple";

        public string? Kind { get; set; }
        public double Amount { get; set; }
        public double Cost { get; set; }

        public string GetFruit4()
        {
            return Kind + " $" + Cost + " each, $" + Amount + " per dozon";
        }
    }
}

//Intro to structs
public struct Coords
{
    public double X, Y;
}
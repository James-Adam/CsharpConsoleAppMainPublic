using CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals.Apple;

namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals
{
    public static class IntroToProgFund
    {
        //Intro to Constructors
        public static void ConstructorMain()
        {
            _ = new MyConstructor();

            Console.WriteLine("Enter any key to continue!");
            _ = Console.ReadKey();

            //second constructor with cost
            Console.WriteLine("\nSecond constructor with cost.");

            Cost eggs = new(12, .25); //constructor overload
            double cost = eggs.Calc();

            Console.WriteLine("\nCost of 12 eggs: ${0}", cost);
            Console.WriteLine("Enter any key to continue!");
            _ = Console.ReadKey();
        }

        //Intro to Methods
        public static void IntroToMethods()
        {
            addNumber(5);

            Console.WriteLine("Enter any key to continue!");
            _ = Console.ReadKey();
        }

        #region Method Helper Code

        private static void addNumber(int x)
        {
            x += 5;

            Console.WriteLine("addNumber");
            Console.WriteLine(x);
        }

        #endregion
    }

    #region Constructor Helper Code

    //second constructor with cost
    public class Cost
    {
        private readonly double amount;
        private readonly double price;

        public Cost(double a, double p)
        {
            amount = a;
            price = p;
        }

        public Cost(double a)
        {
            amount = a;
            price = .35;
        }

        public double Calc()
        {
            return amount * price;
        }
    }

    public class MyConstructor
    {
        public MyConstructor()
        {
            Console.WriteLine("Hello World from constructor");
        }
    }

    #endregion

    //Intro to NameSpaces
    public static class NameSpaceProgram
    {
        public static void NameSpaceMain()
        {
            Fruit fruit1 = new("Macintosh", 0.5, 12);

            string newFruit1 = fruit1.GetFruit();
            double total1 = fruit1.GetCost();

            Console.WriteLine("Fruit Kind: {0}", newFruit1);
            Console.WriteLine("Total Cost: ${0}{1}", total1, Environment.NewLine);

            Orange.Fruit fruit2 = new("Navel", 0.6, 12);

            string newFruit2 = fruit2.GetFruit();
            double total2 = fruit2.GetCost();

            Console.WriteLine("Fruit Kind: {0}", newFruit2);
            Console.WriteLine("Total Cost: ${0}{1}", total2, Environment.NewLine);

            Console.WriteLine("Enter any key to continue");
            _ = Console.ReadKey();
        }
    }
}

#region NameSpace Helper Code

namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals.Apple
{
    public class Fruit
    {
        private readonly double amount;
        private readonly double cost;
        private readonly string fruit;
        private readonly string kind;

        public Fruit(string k, double c, double a)
        {
            fruit = "Apple";
            kind = k;
            cost = c;
            amount = a;
        }

        public double GetCost()
        {
            return cost * amount;
        }

        public string GetFruit()
        {
            return fruit + " " + kind;
        }
    }
}

namespace CsharpConsoleAppMain.DevFundamentals.ProgramFundamentals.Orange
{
    public class Fruit
    {
        private readonly double amount;
        private readonly double cost;
        private readonly string fruit;
        private readonly string kind;

        public Fruit(string k, double c, double a)
        {
            fruit = "Orange";
            kind = k;
            cost = c;
            amount = a;
        }

        public double GetCost()
        {
            return cost * amount;
        }

        public string GetFruit()
        {
            return fruit + " " + kind;
        }
    }
}

#endregion
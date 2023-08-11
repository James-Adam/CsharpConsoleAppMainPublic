namespace CsharpConsoleAppMain.DevFundamentals.OOPFund;

public static class ApplyOOP
{
    public static void AbstractandSealedClasses()
    {
        Console.WriteLine("Before Method");
        Fruit1 apple1 = new("\nMacintosh", 0.5);
        Console.WriteLine("Type: {0}, cost per dozen: {1}", apple1.Kind1, apple1.GetCost1());

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();

        Console.WriteLine("After Method");

        Fruit2 apple2 = new("\nMacintosh", 0.5);
        Console.WriteLine("Type: {0}, cost per dozen: {1}", apple2.Kind2, apple2.GetCost2());

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    public static void CastingBetweenTypes()
    {
        Console.WriteLine("CastingBetweenTypes");
        object apple3 = new Apple3("Granny Smith", 0.6);
        Apple3 granny = (Apple3)apple3;
        Console.WriteLine("\nType: {0}, cost per dozen: {1}", granny.Kind3, granny.GetCost3());

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    public static void UsingIsAndAs()
    {
        Console.WriteLine("UsingIsAndAs");
        Console.WriteLine("\nchange to Apple4 to see result");

        object apple4 = new Orange4("Navel", 0.6); //change to Apple4 to see result
        //Orange4 navel = (Orange4)apple4;
        if (apple4 is Apple4 navel) //check
        {
            Console.WriteLine("\nType: {0}, cost per dozen: {1}", navel.Kind4, navel.GetCost4());
        }
        else
        {
            Console.WriteLine("THis is not an apple");
        }

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    public static void IntroToPolymorphism()
    {
        Console.WriteLine("IntroToPolymorphism");

        Fruit5 f1 = new();
        f1.GetCost5();
        Fruit5 f2 = new Apple5(.5);
        f2.GetCost5();
        Fruit5 f3 = new Orange5(.6);
        f3.GetCost5();
        Fruit5 f4 = new Banana5(.25);
        f4.GetCost5();

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    public static void UsingOverrideAndNew()
    {
        Apple6 apple6 = new(.5); //invoking directly on the derived class
        apple6.GetCost6();
        Fruit6 fruit6 = apple6; //invoking on derived class cast as base clss
        fruit6.GetCost6();

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    public static void IntroToInterfaces()
    {
        Apple7 Macintosh7 = new() { Amount7 = 12, Cost7 = .5 };
        Apple7 Grannymith7 = new() { Amount7 = 12, Cost7 = .6 };
        int difference = Macintosh7.CompareTo(Grannymith7);
        string result7 = difference == 0 ? "the same price as" :
            difference == 1 ? "more expensive than" : "Less expensive";
        Console.WriteLine("Macintosh apples are {0} Granny Smith Apples", result7);

        Console.WriteLine("Press Enter to continue");
        _ = Console.ReadKey();
    }

    //before method
    private class Fruit1 //base class
    {
        public Fruit1(string k1, double c1)
        {
            Kind1 = k1;
            Cost1 = c1;
        }

        public string Kind1 { get; }
        public double Cost1 { get; }

        public string GetCost1()
        {
            return "$" + (Cost1 * 12);
        }
    }

    //after method
    private abstract class Apple2 //base class; abstract cannot be instantiated
    {
        public string? Kind2 { get; protected set; }
        public double Cost2 { get; protected set; }
    }

    private sealed class
        Fruit2 : Apple2 //derived class; sealed cannot be used for base classes but can for derived; again self contained
    {
        public Fruit2(string k2, double c2)
        {
            Kind2 = k2;
            Cost2 = c2;
        }

        public string GetCost2() //override coant be overriden by
        {
            return "$" + (Cost2 * 12);
        }
    }

    private abstract class Fruit3 //base class; abstract cannot be instantiated
    {
        public string? Kind3 { get; protected set; }
        public double Cost3 { get; protected set; }
    }

    private sealed class
        Apple3 : Fruit3 //derived class; sealed cannot be used for base classes but can for derived; again self contained
    {
        public Apple3(string k3, double c3)
        {
            Kind3 = k3;
            Cost3 = c3;
        }

        public string GetCost3() //override coant be overriden by
        {
            return "$" + (Cost3 * 12);
        }
    }

    private abstract class Fruit4 //base class; abstract cannot be instantiated
    {
        public string? Kind4 { get; protected set; }
        public double Cost4 { get; protected set; }
    }

    private sealed class
        Apple4 : Fruit4 //derived class; sealed cannot be used for base classes but can for derived; again self contained
    {
        public string GetCost4() //override coant be overriden by
        {
            return "$" + (Cost4 * 12);
        }
    }

    private sealed class
        Orange4 : Fruit4 //derived class; sealed cannot be used for base classes but can for derived; again self contained
    {
        public Orange4(string k4, double c4)
        {
            Kind4 = k4;
            Cost4 = c4;
        }
    }

    //class fruit
    private class Fruit5 //base class
    {
        public double Cost5 { get; protected set; }

        public virtual void GetCost5() // changed to virtual; virtual lets derived classes override the method
        {
            Console.WriteLine("Getting Cost of Fruit...");
        }
    }

    private class Apple5 : Fruit5 // derived class- apple is a fruit
    {
        public Apple5(double c5)
        {
            Cost5 = c5;
        }

        public override void GetCost5() //add override
        {
            Console.WriteLine("Apples are ${0} a dozen", Cost5 * 12);
        }
    }

    private class Orange5 : Fruit5 // derived class- Orange5 is a fruit
    {
        public Orange5(double c5)
        {
            Cost5 = c5;
        }

        public override void GetCost5() //add override
        {
            Console.WriteLine("Apples are ${0} a dozen", Cost5 * 12);
        }
    }

    private class Banana5 : Fruit5 // derived class- Banana5 is a fruit
    {
        public Banana5(double c5)
        {
            Cost5 = c5;
        }

        public override void GetCost5() //add override
        {
            Console.WriteLine("Apples are ${0} a dozen", Cost5 * 12);
        }
    }

    private class Fruit6 //base class
    {
        public double Cost6 { get; protected set; } //override

        public virtual void GetCost6()
        {
            Console.WriteLine("Getting Cost of Fruit...");
        }
    }

    private class Apple6 : Fruit6 // derived class - appple is a fruit
    {
        public Apple6(double c6)
        {
            Cost6 = c6;
        }

        public new void GetCost6() //creates new definition and ignore original
        {
            Console.WriteLine("Appples are ${0} a dozen", Cost6 * 12);
        }
    }

    public class Fruit7 //base class
    {
        public double Amount7 { get; set; }
        public double Cost7 { get; set; }

        public virtual void GetCost7()
        {
            Console.WriteLine("Getting Cost of Fruit...");
        }
    }

    public class Apple7 : Fruit7, IComparable // implement ICOmperable
    {
        public new double Amount7 { get; set; }
        public new double Cost7 { get; set; }

        public int CompareTo(object fruit7)
        {
            Apple7 toCompare = (Apple7)fruit7;
            double compare = GetCost7() - toCompare.GetCost7();
            return compare == 0 ? 0 : compare > 0 ? 1 : -1;
        }

        public new double GetCost7()
        {
            return Amount7 * Cost7;
        }
    }
}
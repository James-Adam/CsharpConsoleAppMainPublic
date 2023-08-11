namespace CsharpConsoleAppMain.Data.Vehicles;

public static class VehicleMain
{
    //public static AccountStatus MyFunc()
    //{
    //    /*

    // LOGIC

    // */

    //    //return 1;
    //    return AccountStatus.OK;
    //}

    //public static void Caller()
    //{
    //    AccountStatus a = MyFunc();
    //}
    public static void vehicleMain()
    {
        //declaration // instantiation
        Car car1 = new();
        _ = new
            Boat
        {
            speed = 2,
            colour = Colour.BLUE
        };

        //instantiating the variables of car obj
        car1.model = "X3";
        car1.cylinderCount = 6;
        car1.Brand = Brand.BMW;
        car1.speed = 12;
        car1.colour = Colour.RED;

        Console.WriteLine(car1.model);
        Console.WriteLine(car1.cylinderCount);
        Console.WriteLine(car1.Brand);

        int price = car1.GetPurchasingPrice();
        Console.WriteLine("The price is: " + price);

        _ = Console.ReadLine();
    }
}
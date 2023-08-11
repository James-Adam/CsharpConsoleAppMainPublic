namespace CsharpConsoleAppMain.Data.Vehicles;

public class Car : Vehicle, Purchasable //Inherate interface
{
    //Declaring Variables for car object
    public int cylinderCount;

    public string? model;

    //Properties
    public Brand Brand { get; set; }

    //Implimenting interface
    public int GetPurchasingPrice()
    {
        // //return 1;
        {
            return Brand switch
            {
                Brand.BMW => 9999,
                Brand.MERC => 100,
                Brand.VW => 0,
                _ => -1
            };
        }
    }

    //public Brand Brand { get; set; } syntax suger

    ////Defining function/Method for car object
    //public int GetPrice()
    //{
    //    switch (brand)
    //    {
    //        case Brand.BMW: return 9999;
    //        case Brand.MERC: return 100;
    //        case Brand.VW: return 0;
    //    }

    //    return -1;
    //}
}
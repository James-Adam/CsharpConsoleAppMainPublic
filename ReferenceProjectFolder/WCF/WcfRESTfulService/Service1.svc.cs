namespace WcfRESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name
    // "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc
    // or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            //create sine answer based on the value strin
            return "If your voice travels " + value + " feet, then the influence of your voice will cover " +
                   (int.Parse(value) * int.Parse(value) * 3.14) + " sq feet";
        }

        public string SayHello()
        {
            return "Say Hello from Service1.SayHello();";
        }

        public HelloObject GetModelObjet(string id)
        {
            HelloObject helloObject = new HelloObject();
            if (int.Parse(id) > 0)
            {
                helloObject.happyHello = true;
                helloObject.helloMessage = "Great day, couldnt be better?";
            }
            else
            {
                helloObject.happyHello = false;
                helloObject.helloMessage = "Feeling Blue";
            }

            return helloObject;
        }
    }
}
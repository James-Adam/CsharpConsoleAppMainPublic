using Microsoft.AspNetCore.DataProtection;

namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService.MiddleWare;

public static class Program
{
    public static void MainMiddlware(string[] args)
    {
        //add data protection services
        ServiceCollection serviceCollection = new();
        _ = serviceCollection.AddDataProtection();
        ServiceProvider services =
            serviceCollection.BuildServiceProvider();

        //create an instance of MyClass using the service
        MyClass instance =
            ActivatorUtilities.CreateInstance<MyClass>
                (services);
        instance.RunSample();
        _ = Console.ReadLine();
    }

    public class MyClass
    {
        private readonly IDataProtector _protector;

        //the provider parameter is provided by DI

        public MyClass(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Contoso.MyClass.v1");
        }

        internal void RunSample()
        {
            Console.Write("Enter Input: ");
            string? input = Console.ReadLine();

            //protect the payload
            string protectedPayload = _protector.Protect(input!);
            Console.WriteLine($"Protect returned {protectedPayload}");

            //unprotect the payload
            string unprotetectedPayload = _protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotetectedPayload}");
        }
    }
}
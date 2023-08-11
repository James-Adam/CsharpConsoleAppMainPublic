using System;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name
    // "Service1" in both code and config file together.
    public class GreetingService : IGreeting
    {
        public string SayHi(string name)
        {
            //Thread.Sleep(5 * 60 * 1000);
            return $"Hi {name} have a great day!";
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }
    }
}
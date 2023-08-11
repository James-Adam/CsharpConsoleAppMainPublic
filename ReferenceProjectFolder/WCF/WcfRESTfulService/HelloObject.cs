using System.Runtime.Serialization;

namespace WcfRESTfulService
{
    public class HelloObject
    {
        [DataMember] public bool happyHello { get; set; }

        [DataMember] public string helloMessage { get; set; } = "Hello";
    }
}
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CsharpConsoleAppMain.CsharpProgramming.ConsumingData;

[DataContract]
public class Member
{
    [DataMember] internal int memberAge;
    [DataMember] internal string? memberName;
}

public static class JSONSerializer
{
    public static void JSONSerializerMain()
    {
        GetMockJSONData(out MemoryStream? stream1, out DataContractJsonSerializer? ser);

        //So lets just look at this in its unadulterated state
        Encoding localEncoding = Encoding.UTF8;
        string jsonData = localEncoding.GetString(stream1.ToArray());
        Console.WriteLine("Raw JSON: {0}", jsonData);

        stream1.Position = 0;
        Member? m1 = (Member)ser.ReadObject(stream1);

        if (m1 != null)
        {
            Console.WriteLine("\nmember object created");
            Console.WriteLine("Name: {0}\tAge: {1}", m1.memberName, m1.memberAge);
        }
    }

    //JSON to object
    internal static void GetMockJSONData(out MemoryStream stream1, out DataContractJsonSerializer ser)
    {
        Member member = new() { memberName = "Harriet Lipsey", memberAge = 99 };
        //Set up person Object
        stream1 = new MemoryStream();

        DataContractJsonSerializerSettings settings = new()
        {
            UseSimpleDictionaryFormat = true
        };
        ser = new DataContractJsonSerializer(typeof(Member), settings);
        ser.WriteObject(stream1, member);
    }
}
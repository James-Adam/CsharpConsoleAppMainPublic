using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name
    // "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //this file fefine the urls that will be used in the rest service. in this example we will create
        //1) simple string response
        //2) url that accepts a parameter tumber
        //3) a url that will return a full obect to the browser

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SayHello/")]
        string SayHello();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetData/{value}/")]
        string GetData(string value);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetModelObjet/{id}/")]
        HelloObject GetModelObjet(string id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
    }
}
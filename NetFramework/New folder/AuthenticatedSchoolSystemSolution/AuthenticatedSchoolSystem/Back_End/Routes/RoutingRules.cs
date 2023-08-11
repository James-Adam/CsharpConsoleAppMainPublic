using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace AuthenticatedSchoolSystem.Back_End.Routes
{
    //Create Routing Rules
    public class RoutingRules
    {
        //Creating Routing Rules
        public void RouteConfig()
        {
            _ = new RoutingConfiguration
            {
                RouteOnHeadersOnly = false
            };
            MessageFilterTable<List<ServiceEndpoint>> mft = new MessageFilterTable<List<ServiceEndpoint>>();
            MessageFilter mf = new MatchAllMessageFilter();
            ContractDescription cd = new ContractDescription("myCOntract");
            ServiceEndpoint se = new ServiceEndpoint(cd);
            List<ServiceEndpoint> endpoint = new List<ServiceEndpoint>
            {
                se
            };

            mft.Add(mf, endpoint);
        }
    }
}
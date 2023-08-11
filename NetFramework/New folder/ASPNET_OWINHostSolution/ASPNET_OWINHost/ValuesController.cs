using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASPNET_OWINHost
{
    internal class ValuesController : ApiController
    {
        //Get api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id) 
        {
            return "value";
        }

        public void Post([FromBody] string value) 
        { 
        
        }
    }
}

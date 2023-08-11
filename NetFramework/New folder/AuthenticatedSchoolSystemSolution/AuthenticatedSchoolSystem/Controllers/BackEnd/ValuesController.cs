using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuthenticatedSchoolSystem.Controllers.BackEnd
{
    public class ValuesController : ApiController
    {
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        //Get api/values/5

        //handling exeptions in service requests
        public IHttpActionResult Get(int id)
        {
            if (id > 10)
            {
                HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Cant deal with numbers above ten")
                };
                throw new HttpResponseException(m);
            }

            return Ok(id);
        }

        //Creating Asynchronous task
        public async Task<string> Get2(int id)
        {
            using (StreamReader sr = File.OpenText("~/MyLargeFile.txt"))
            {
                return await sr.ReadToEndAsync();
            }
        }

        public string Get(int ida, int idb)
        {
            return string.Concat(ida.ToString(), "**", idb.ToString());
        }

        //Post api/values
        public void Post([FromBody] string value)
        {
            // Method intentionally left empty.
        }

        //PUT api/values/5
        public void Put(int id, [FromBody] string val)
        {
            // Method intentionally left empty.
        }

        public void Delete(int id)
        {
            // Method intentionally left empty.
        }
    }
}
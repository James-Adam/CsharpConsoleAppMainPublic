using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public class _CallWebService
    {
        //ocnsuming a service using HttpClient
        public async void CallWebService()
        {
            HttpClient hc = new HttpClient
            {
                BaseAddress = new Uri("http://api.geonames.org/")
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage hrm =
                await hc.GetAsync("citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demou");
            if (hrm.IsSuccessStatusCode)
            {
                _ = JsonConvert.DeserializeObject(await hrm.Content.ReadAsStringAsync());
            }
        }

        //USING A REQUEST BATCH TO REDUCE REQUESTS
        public async void SendBatch()
        {
            HttpRequestMessage hrmGet = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/mybatch");

            MultipartContent content = new MultipartContent
            {
                new HttpMessageContent(hrmGet),
                new HttpMessageContent(hrmGet),
                new HttpMessageContent(hrmGet)
            };

            HttpRequestMessage hrmPost = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/mybatch")
            {
                Content = content
            };

            HttpClient hc = new HttpClient(GlobalConfiguration.DefaultServer);
            _ = await hc.SendAsync(hrmPost);
        }
    }
}
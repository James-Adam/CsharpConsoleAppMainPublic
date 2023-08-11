using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.BackEnd
{
    public class DecisionTreeController : Controller
    {
        //{
        ////    {
        ////        {
        ////            {
        ////                {
        ////                    ParentQuestionId = d.ParentQuestionId,
        ////                    ParentResponseIdArray = d.ParentResponceIdArray
        ////                };
        ////                _decisionTreeAttributeService.InsertDepenency(dpNew);
        ////            }
        ////        }
        ////    }
        ////    return Json(new
        ////    {
        ////        Result = "Success"
        ////    });
        //}
        //using an async wait
        [AsyncTimeout(5000)]
        public async Task<int> Sample(byte[] fileContent, string newFileName, int productId, string basePath)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ByteArrayContent content = new ByteArrayContent(fileContent);
                    client.BaseAddress = new Uri("http://www.testportal.com");

                    Task<HttpResponseMessage> thumbnailTask = client.PostAsync(@"/api/jpeg", content);
                    HttpResponseMessage response = await thumbnailTask;

                    Stream res = await response.Content.ReadAsStreamAsync();
                    string fileguid = newFileName;
                    using (FileStream fileStream = new FileStream($"{basePath}{fileguid}.jpg", FileMode.Create))
                    {
                        await res.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception)
            {
                ThrowExeptionAsync();
                //or

                //e.stacktrace
                //write to a log or file
            }

            return 1;
        }

        private void ThrowExeptionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
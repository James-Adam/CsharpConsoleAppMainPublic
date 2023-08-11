using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolSystem.Controllers
{
    public class DecisionTreeController : Controller
    {
        // IList<DecisionTreeAttribute> allQuestions = new List<DecisionTreeAttribute>();
        //{
        //    {
        //        {
        //            {
        //                {
        //                    ParentQuestionId = d.ParentQuestionId,
        //                    ParentResponseIdArray = d.ParentResponceIdArray
        //                };
        //                _decisionTreeAttributeService.InsertDepenency(dpNew);
        //            }    
        //        }
        //    }
        //    return Json(new
        //    {
        //        Result = "Success"
        //    });
        //}
        //using an async wait 
        [AsyncTimeout(5000)]
        public async Task<int> Sample(byte[] fileContent, string newFileName, int productId, string basePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new ByteArrayContent(fileContent);
                    client.BaseAddress = new Uri("http://www.testportal.com");

                    var thumbnailTask = client.PostAsync(@"/api/jpeg", content);
                    var response = await thumbnailTask;

                    var res = await response.Content.ReadAsStreamAsync();
                    var fileguid = newFileName;
                    using (var fileStream = new FileStream($"{basePath}{fileguid}.jpg", FileMode.Create))
                    {
                        await res.CopyToAsync(fileStream);
                    }
                }


            }
            catch (Exception ex)
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
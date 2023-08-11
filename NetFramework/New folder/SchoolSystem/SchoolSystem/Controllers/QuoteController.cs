//using SchoolSystem.Models;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace SchoolSystem.Controllers
//{
//    public class QuoteController : Controller
//    {


//        // GET: Quote
//        //parallel Tasks

//        public ActionResult CalculateInParallel()
//        {
//            var allQuestions = _decisionTreeAttributeService.GetAllDecisionTreeAttributes();


//            var pquery = from x in allQuestions.AsParallel()
//                         where x.Critical
//                         select x;
//            pquery.ForAll((e) => ReviewCriteria(e));

//            return Content("");
//        }

//        public void ReviewCriteria(DecisionTreeAttribute e)
//        {
//            if (e.DependancyLineRule == 1)
//            {
//                //ect
//            }
//        }
//        public async Task<ActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
//            }
//            //Do some work

//            return View("EditMergeList");
//        }

//        public byte[] ConvertPdfToImage(Stream fileStream)
//        {
//            using (var client = new System.Net.Http.HttpClient())
//            {
//                var content = new System.Net.Http.StreamContent(fileStream);
//                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

//                client.BaseAddress = new Uri("http://test.com");

//                System.Net.Http.HttpResponseMessage response = client.PostAsync(@"/api/Image", content).GetAwaiter().GetResult();

//                System.Net.Http.StreamContent contentResult = (System.Net.Http.StreamContent)response.Content;
//                return contentResult.ReadAsByteArrayAsync().GetAwaiter().GetResult();
//            }
//        }

//        public async Task<ActionResult> MapProductFileToProject(int projectId, int itemId)
//        {
//            await CreateTOShell(1);
//            return Content("");
//        }
//        private System.Threading.Tasks.Task CreateTOShell(int v)
//        {
//            throw new NotImplementedException();
//        }

//        //[TestMethod]
//        public async System.Threading.Tasks.Task GeneralTest()
//        {
//            await CreateTOShell(1);
//        }


//    }
//}
using AuthenticatedSchoolSystem.Models.Back_End;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.BackEnd
{
    public class QuoteController : Controller
    {
        // GET: Quote
        public ActionResult CalculateInParallel()
        {
            //var _testService = EngineContext.Current.Resolve<IDecisionTreeAttributeService>();
            //var alLQuestions = _decissionTreeAttributeService.GetAlLDecisionTreeAttributes();

            //var pquery = from x in alLQuestions.AssParallel()
            //             where x.Critical
            //             select x;
            //pquery.forAll((e) => ReviewCriteria(e));

            return Content("");
        }

        public void ReviewCriteria(DecisionTreeAttribute e)
        {
            if (e.DependancyLineRule == 1)
            {
                //ect....
            }
        }
    }
}
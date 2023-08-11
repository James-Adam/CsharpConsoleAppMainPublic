//using SchoolSystem.Models;
//using SchoolSystem.Services;
//using System.Threading.Tasks;
//using System.Web.Mvc;




//namespace Suteki.AsyncMvcTpl.Controllers
//{
//    public class TPLController : AsyncController
//    {
//        readonly UserService userService = new UserService();

//        [HttpGet]
//        public void IndexAsync()
//        {
//            AsyncManager.OutstandingOperations.Increment();
//            userService.GetCurrentUser().ContinueWith(t1 =>
//            {
//                var user = t1.Result;
//                userService.SendUserAMessage(user, "Hi From the MVC TPL experiment").ContinueWith(_ =>
//                {
//                    AsyncManager.Parameters["user"] = user;
//                    AsyncManager.OutstandingOperations.Decrement();
//                });
//            });

//        }

//        public ViewResult IndexCompleted(User user)
//        {
//            return View(user);
//        }

//        // this would be very nice if it actually worked :)
//        [HttpGet]
//        //public Task<ViewResult> IndexLinq()
//        //{
//        //    return from user in userService.GetCurrentUser()
//        //           from _ in userService.SendUserAMessage(user, "Hi From the MVC TPL experiment")
//        //           select View(user);
//        //}


//    }
//}
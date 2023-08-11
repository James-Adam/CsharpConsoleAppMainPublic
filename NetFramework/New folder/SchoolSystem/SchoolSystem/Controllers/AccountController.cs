using SchoolSystem.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolSystem.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            //MembershipCreateStatus status;

            if (ModelState.IsValid)
            {
                using (EntityContext db = new EntityContext())
                {
                    db.userAccount.Add(account);

                    db.SaveChanges();
                }
                //ModelState.Clear();
                ViewBag.Message = account.UserName + " Created Successfully";
            }
            return View();
        }

        //Get method

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (EntityContext db = new EntityContext())
            {
                var usr = db.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.UserName.ToString();
                    //return RedirectToAction("LoggedIn");



                    //Store preference in a cookie

                    HttpCookie myCookie = new HttpCookie("SportCookie");
                    myCookie.Value = "Hockey";
                    myCookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(myCookie);

                    FormsAuthentication.RedirectFromLoginPage(Session["Username"].ToString(), false);
                }
                else
                {
                    ModelState.AddModelError("", "Username or password do not match");
                }
                return View();
            }
        }

    }

}
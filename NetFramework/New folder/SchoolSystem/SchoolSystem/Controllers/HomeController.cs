using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Controllers
{
    public class HomeController : AsyncController
    {




        //output cache
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Server)]





        public ActionResult Index()
        {
            IList<Student> studentList = new List<Student>();

            studentList.Add(new Student() { Name = "Steve" });
            studentList.Add(new Student() { Name = "Ram" });

            TempData["name"] = "Bill";

            //ViewData.Add("Id", 1);
            //ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            //ViewData.Add(new KeyValuePair<string, object>("DOB", 20));

            ViewData["students"] = studentList;

            //ViewBag.Id = 1;

            //ViewData.Add("Id", 1); // throw runtime exception as it already has "Id" key
            //ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            //ViewData.Add(new KeyValuePair<string, object>("DOB", 20));

            ViewBag.TotalStudents = studentList.Count();

            return View();
        }
        [OutputCache(CacheProfile = "myCacheProfile")]
        public ActionResult About()
        {
            string name;

            if (TempData.ContainsKey("name"))
                name = TempData["name"].ToString(); // returns "Bill" 

            ViewBag.Message = "Your application description page.";
            Response.Cache.SetExpires(DateTime.Now.AddYears(1));
            Response.Cache.SetCacheability(HttpCacheability.Public); //other options

            return View();
        }
        //
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult Contact()
        {
            HttpCookie c = new HttpCookie("myCookie", "my Cookie's Value");
            Response.Cookies.Add(c);
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Creating url links to web api controllers
        public void URLTest()
        {
            //    var link = new TestLink();
            //    link.URL = Url.Link("Default", new {controller= "Home", action = "Index"});
        }



    }
}
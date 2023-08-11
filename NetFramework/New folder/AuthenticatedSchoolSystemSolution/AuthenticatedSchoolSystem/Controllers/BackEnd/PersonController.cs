using AuthenticatedSchoolSystem.Models.Back_End;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.BackEnd
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<Person> personList = new List<Person>();

            return View(personList);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            Person person = new Person();
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            Person person = new Person();
            return View(person);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = new Person();
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            Person person = new Person();
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
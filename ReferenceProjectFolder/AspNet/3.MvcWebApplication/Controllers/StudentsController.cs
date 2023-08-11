using _3.MvcWebApplication.Models.cf;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

#pragma warning disable S4144

namespace _3.MvcWebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);
            return student == null ? HttpNotFound() : (ActionResult)View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,DOB,Grade")] Student student)
        {
            if (ModelState.IsValid)
            {
                _ = db.Students.Add(student);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);
            return student == null ? HttpNotFound() : (ActionResult)View(student);
        }

        // POST: Students/Edit/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,DOB,Grade")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);
            return student == null ? HttpNotFound() : (ActionResult)View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            _ = db.Students.Remove(student);
            _ = db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
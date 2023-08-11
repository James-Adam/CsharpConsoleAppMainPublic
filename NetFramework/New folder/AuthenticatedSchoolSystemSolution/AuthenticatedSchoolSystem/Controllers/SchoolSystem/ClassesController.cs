using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class ClassesController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class @class = db.Classes.Find(id);
            return @class == null ? HttpNotFound() : (ActionResult)View(@class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _ = db.Classes.Add(@class);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class @class = db.Classes.Find(id);
            return @class == null ? HttpNotFound() : (ActionResult)View(@class);
        }

        // POST: Classes/Edit/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@class);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class @class = db.Classes.Find(id);
            return @class == null ? HttpNotFound() : (ActionResult)View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            _ = db.Classes.Remove(@class);
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
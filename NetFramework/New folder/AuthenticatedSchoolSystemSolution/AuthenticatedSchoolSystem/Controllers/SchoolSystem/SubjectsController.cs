using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class SubjectsController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Subjects
        public ActionResult Index()
        {
            IQueryable<Subject> subjects = db.Subjects.Include(s => s.Class);
            return View(subjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subject = db.Subjects.Find(id);
            return subject == null ? HttpNotFound() : (ActionResult)View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: Subjects/Create To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,ClassId,SubjectName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _ = db.Subjects.Add(subject);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        // POST: Subjects/Edit/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,ClassId,SubjectName")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subject = db.Subjects.Find(id);
            return subject == null ? HttpNotFound() : (ActionResult)View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            _ = db.Subjects.Remove(subject);
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
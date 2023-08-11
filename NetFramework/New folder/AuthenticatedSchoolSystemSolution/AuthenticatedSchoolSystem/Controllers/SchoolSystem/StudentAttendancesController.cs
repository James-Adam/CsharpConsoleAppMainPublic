using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class StudentAttendancesController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: StudentAttendances
        public ActionResult Index()
        {
            IQueryable<StudentAttendance> studentAttendances =
                db.StudentAttendances.Include(s => s.Class).Include(s => s.Subject);
            return View(studentAttendances.ToList());
        }

        // GET: StudentAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            return studentAttendance == null ? HttpNotFound() : (ActionResult)View(studentAttendance);
        }

        // GET: StudentAttendances/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: StudentAttendances/Create To protect from overposting attacks, enable the specific
        // properties you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,ClassId,SubjectId,RollNo,Status,Date")]
            StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                _ = db.StudentAttendances.Add(studentAttendance);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", studentAttendance.SubjectId);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", studentAttendance.SubjectId);
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Edit/5 To protect from overposting attacks, enable the specific
        // properties you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,ClassId,SubjectId,RollNo,Status,Date")]
            StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendance).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", studentAttendance.SubjectId);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            return studentAttendance == null ? HttpNotFound() : (ActionResult)View(studentAttendance);
        }

        // POST: StudentAttendances/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            _ = db.StudentAttendances.Remove(studentAttendance);
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
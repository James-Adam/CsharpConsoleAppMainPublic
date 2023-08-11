using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class TeacherSubjectsController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: TeacherSubjects
        public ActionResult Index()
        {
            IQueryable<TeacherSubject> teacherSubjects =
                db.TeacherSubjects.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Teacher);
            return View(teacherSubjects.ToList());
        }

        // GET: TeacherSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            return teacherSubject == null ? HttpNotFound() : (ActionResult)View(teacherSubject);
        }

        // GET: TeacherSubjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: TeacherSubjects/Create To protect from overposting attacks, enable the specific
        // properties you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,SubjectId,TeacherId")] TeacherSubject teacherSubject)
        {
            if (ModelState.IsValid)
            {
                _ = db.TeacherSubjects.Add(teacherSubject);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", teacherSubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            if (teacherSubject == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", teacherSubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // POST: TeacherSubjects/Edit/5 To protect from overposting attacks, enable the specific
        // properties you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,SubjectId,TeacherId")] TeacherSubject teacherSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherSubject).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", teacherSubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            return teacherSubject == null ? HttpNotFound() : (ActionResult)View(teacherSubject);
        }

        // POST: TeacherSubjects/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            _ = db.TeacherSubjects.Remove(teacherSubject);
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
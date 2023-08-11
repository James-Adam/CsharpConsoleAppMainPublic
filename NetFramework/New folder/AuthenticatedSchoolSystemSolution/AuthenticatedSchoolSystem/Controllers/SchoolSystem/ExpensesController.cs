using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class ExpensesController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Expenses
        public ActionResult Index()
        {
            IQueryable<Expense> expenses = db.Expenses.Include(e => e.Class).Include(e => e.Subject);
            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Expense expense = db.Expenses.Find(id);
            return expense == null ? HttpNotFound() : (ActionResult)View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Expenses/Create To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseId,ClassId,SubjectId,ChargeAmount")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _ = db.Expenses.Add(expense);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", expense.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", expense.SubjectId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", expense.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", expense.SubjectId);
            return View(expense);
        }

        // POST: Expenses/Edit/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseId,ClassId,SubjectId,ChargeAmount")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", expense.ClassId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", expense.SubjectId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Expense expense = db.Expenses.Find(id);
            return expense == null ? HttpNotFound() : (ActionResult)View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            _ = db.Expenses.Remove(expense);
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
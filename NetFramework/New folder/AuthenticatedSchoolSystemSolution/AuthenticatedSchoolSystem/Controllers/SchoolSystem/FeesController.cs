using AuthenticatedSchoolSystem.Models.SchoolSystem;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.SchoolSystem
{
    public class FeesController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Fees
        public ActionResult Index()
        {
            IQueryable<Fee> fees = db.Fees.Include(f => f.Class);
            return View(fees.ToList());
        }

        // GET: Fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fee fee = db.Fees.Find(id);
            return fee == null ? HttpNotFound() : (ActionResult)View(fee);
        }

        // GET: Fees/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: Fees/Create To protect from overposting attacks, enable the specific properties you
        // want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeesId,ClassId,FeesAmount")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                _ = db.Fees.Add(fee);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", fee.ClassId);
            return View(fee);
        }

        // GET: Fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fee fee = db.Fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", fee.ClassId);
            return View(fee);
        }

        // POST: Fees/Edit/5 To protect from overposting attacks, enable the specific properties you
        // want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeesId,ClassId,FeesAmount")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", fee.ClassId);
            return View(fee);
        }

        // GET: Fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fee fee = db.Fees.Find(id);
            return fee == null ? HttpNotFound() : (ActionResult)View(fee);
        }

        // POST: Fees/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fee fee = db.Fees.Find(id);
            _ = db.Fees.Remove(fee);
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
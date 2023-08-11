using _3.MvcWebApplication.Models.cf;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

#pragma warning disable S4144

namespace _3.MvcWebApplication.Controllers
{
    public class StaffsController : Controller
    {
        private readonly EntityContext db = new EntityContext();

        // GET: Staffs
        public ActionResult Index()
        {
            return View(db.Staffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = db.Staffs.Find(id);
            return staff == null ? HttpNotFound() : (ActionResult)View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,FirstName,LastName,AnnualSalary")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _ = db.Staffs.Add(staff);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = db.Staffs.Find(id);
            return staff == null ? HttpNotFound() : (ActionResult)View(staff);
        }

        // POST: Staffs/Edit/5 To protect from overposting attacks, enable the specific properties
        // you want to bind to, for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,FirstName,LastName,AnnualSalary")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = db.Staffs.Find(id);
            return staff == null ? HttpNotFound() : (ActionResult)View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Staff staff = db.Staffs.Find(id);
            _ = db.Staffs.Remove(staff);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusDepot.DAL;
using BusDepot.Models;
using System.Data.Entity.Infrastructure;


namespace BusDepot.Controllers
{
    public class WithdrawItemReportController : Controller
    {
        private BusDepotContext db = new BusDepotContext();

        // GET: WithdrawItemReport
        public ActionResult Index()
        {
            var withdrawItemReports = db.WithdrawItemReports.Include(w => w.Employee).Include(w => w.Item).Include(w => w.Bus).Include(w => w.Car);
            return View(withdrawItemReports.ToList());
        }

        // GET: WithdrawItemReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithdrawItemReport withdrawItemReport = db.WithdrawItemReports.Find(id);
            if (withdrawItemReport == null)
            {
                return HttpNotFound();
            }
            return View(withdrawItemReport);
        }

        // GET: WithdrawItemReport/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator");
            return View();
        }

        // POST: WithdrawItemReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,NumberOfTakenItems,EmployeeID,VehicleID,WithdrawItemDateTime,WithdrawItemReportNotes")] WithdrawItemReport withdrawItemReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.WithdrawItemReports.Add(withdrawItemReport);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists " +
                    "see your system administrator.");

            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", withdrawItemReport.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", withdrawItemReport.ItemID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", withdrawItemReport.VehicleID);
            return View(withdrawItemReport);
        }

        // GET: WithdrawItemReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithdrawItemReport withdrawItemReport = db.WithdrawItemReports.Find(id);
            if (withdrawItemReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", withdrawItemReport.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", withdrawItemReport.ItemID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", withdrawItemReport.VehicleID);
            return View(withdrawItemReport);
        }

        // POST: WithdrawItemReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WithdrawItemReportID,ItemID,NumberOfTakenItems,EmployeeID,VehicleID,WithdrawItemDateTime,WithdrawItemReportNotes")] WithdrawItemReport withdrawItemReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withdrawItemReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", withdrawItemReport.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", withdrawItemReport.ItemID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", withdrawItemReport.VehicleID);
            return View(withdrawItemReport);
        }

        // GET: WithdrawItemReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithdrawItemReport withdrawItemReport = db.WithdrawItemReports.Find(id);
            if (withdrawItemReport == null)
            {
                return HttpNotFound();
            }
            return View(withdrawItemReport);
        }

        // POST: WithdrawItemReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WithdrawItemReport withdrawItemReport = db.WithdrawItemReports.Find(id);
            db.WithdrawItemReports.Remove(withdrawItemReport);
            db.SaveChanges();
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

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
    public class RepairReportController : Controller
    {
        private BusDepotContext db = new BusDepotContext();

        // GET: RepairReport
        public ActionResult Index()
        {
            var repairReports = db.RepairReports.Include(r => r.Employee).Include(r => r.Bus).Include(r => r.Car);
            return View(repairReports.ToList());
        }

        // GET: RepairReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairReport repairReport = db.RepairReports.Find(id);
            if (repairReport == null)
            {
                return HttpNotFound();
            }
            return View(repairReport);
        }

        // GET: RepairReport/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "SideNumber");
            return View();
        }

        // POST: RepairReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,VehicleID,RepairDateTime,RepairReportNotes")] RepairReport repairReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RepairReports.Add(repairReport);
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

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", repairReport.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", repairReport.VehicleID);
            return View(repairReport);
        }

        // GET: RepairReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairReport repairReport = db.RepairReports.Find(id);
            if (repairReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", repairReport.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", repairReport.VehicleID);
            return View(repairReport);
        }

        // POST: RepairReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairReportID,EmployeeID,VehicleID,RepairDateTime,RepairReportNotes")] RepairReport repairReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", repairReport.EmployeeID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", repairReport.VehicleID);
            return View(repairReport);
        }

        // GET: RepairReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairReport repairReport = db.RepairReports.Find(id);
            if (repairReport == null)
            {
                return HttpNotFound();
            }
            return View(repairReport);
        }

        // POST: RepairReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairReport repairReport = db.RepairReports.Find(id);
            db.RepairReports.Remove(repairReport);
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

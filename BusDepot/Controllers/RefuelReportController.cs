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
    public class RefuelReportController : Controller
    {
        private BusDepotContext db = new BusDepotContext();

        // GET: RefuelReport
        public ActionResult Index()
        {
            var refuelReports = db.RefuelReports.Include(r => r.Employee).Include(r => r.Fuel).Include(r => r.Bus).Include(r => r.Car);
            return View(refuelReports.ToList());
        }

        // GET: RefuelReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelReport refuelReport = db.RefuelReports.Find(id);
            if (refuelReport == null)
            {
                return HttpNotFound();
            }
            return View(refuelReport);
        }

        // GET: RefuelReport/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator");
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "Name");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator");
            return View();
        }

        // POST: RefuelReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuelID,AmountOfTakenFuel,EmployeeID,VehicleID,RefuelDateTime,RefuelReportNotes")] RefuelReport refuelReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RefuelReports.Add(refuelReport);
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

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", refuelReport.EmployeeID);
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "Name", refuelReport.FuelID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", refuelReport.VehicleID);
            return View(refuelReport);
        }

        // GET: RefuelReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelReport refuelReport = db.RefuelReports.Find(id);
            if (refuelReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", refuelReport.EmployeeID);
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "Name", refuelReport.FuelID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", refuelReport.VehicleID);
            return View(refuelReport);
        }

        // POST: RefuelReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RefuelReportID,FuelID,AmountOfTakenFuel,EmployeeID,VehicleID,RefuelDateTime,RefuelReportNotes")] RefuelReport refuelReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refuelReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullIdentificator", refuelReport.EmployeeID);
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "Name", refuelReport.FuelID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "FullIdentificator", refuelReport.VehicleID);
            return View(refuelReport);
        }

        // GET: RefuelReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelReport refuelReport = db.RefuelReports.Find(id);
            if (refuelReport == null)
            {
                return HttpNotFound();
            }
            return View(refuelReport);
        }

        // POST: RefuelReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RefuelReport refuelReport = db.RefuelReports.Find(id);
            db.RefuelReports.Remove(refuelReport);
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

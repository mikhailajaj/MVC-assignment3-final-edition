using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_assignment3_final_edition.Models;

namespace MVC_assignment3_final_edition.Controllers
{
    public class tbl_vehicleController : Controller
    {
        private db_employeesEntities1 db = new db_employeesEntities1();

        // GET: tbl_vehicle
        public ActionResult Index()
        {
            var tbl_vehicle = db.tbl_vehicle.Include(t => t.tbl_employee);
            return View(tbl_vehicle.ToList());
        }

        // GET: tbl_vehicle/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vehicle tbl_vehicle = db.tbl_vehicle.Find(id);
            if (tbl_vehicle == null)
            {
                return HttpNotFound();
            }
            return View(tbl_vehicle);
        }

        // GET: tbl_vehicle/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.tbl_employee, "Id", "employee_status");
            return View();
        }

        // POST: tbl_vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,plateNumber,make,model")] tbl_vehicle tbl_vehicle)
        {
            if (ModelState.IsValid)
            {
                db.tbl_vehicle.Add(tbl_vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.tbl_employee, "Id", "employee_status", tbl_vehicle.id);
            return View(tbl_vehicle);
        }

        // GET: tbl_vehicle/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vehicle tbl_vehicle = db.tbl_vehicle.Find(id);
            if (tbl_vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.tbl_employee, "Id", "employee_status", tbl_vehicle.id);
            return View(tbl_vehicle);
        }

        // POST: tbl_vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,plateNumber,make,model")] tbl_vehicle tbl_vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.tbl_employee, "Id", "employee_status", tbl_vehicle.id);
            return View(tbl_vehicle);
        }

        // GET: tbl_vehicle/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_vehicle tbl_vehicle = db.tbl_vehicle.Find(id);
            if (tbl_vehicle == null)
            {
                return HttpNotFound();
            }
            return View(tbl_vehicle);
        }

        // POST: tbl_vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_vehicle tbl_vehicle = db.tbl_vehicle.Find(id);
            db.tbl_vehicle.Remove(tbl_vehicle);
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

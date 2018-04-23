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
    public class tbl_employeeController : Controller
    {
        private db_employeesEntities1 db = new db_employeesEntities1();

        // GET: tbl_employee
        public ActionResult Index()
        {
            var tbl_employee = db.tbl_employee.Include(t => t.tbl_status);
            return View(tbl_employee.ToList());
        }

        // GET: tbl_employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // GET: tbl_employee/Create
        public ActionResult Create()
        {
            ViewBag.employee_status = new SelectList(db.tbl_status, "employee_status", "employee_status");
            return View();
        }

        // POST: tbl_employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_status,Id,employeeName,employeeAge,salary,bouns,rate,hoursWorked")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_employee.Add(tbl_employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_status = new SelectList(db.tbl_status, "employee_status", "employee_status", tbl_employee.employee_status);
            return View(tbl_employee);
        }


        // GET: tbl_employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_status = new SelectList(db.tbl_status, "employee_status", "employee_status", tbl_employee.employee_status);
            return View(tbl_employee);
        }

        // POST: tbl_employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_status,Id,employeeName,employeeAge,salary,bouns,rate,hoursWorked")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_status = new SelectList(db.tbl_status, "employee_status", "employee_status", tbl_employee.employee_status);
            return View(tbl_employee);
        }

        // GET: tbl_employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // POST: tbl_employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            db.tbl_employee.Remove(tbl_employee);
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

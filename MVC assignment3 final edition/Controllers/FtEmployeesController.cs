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
    public class FtEmployeesController : Controller
    {
        private db_employeesEntities1 db = new db_employeesEntities1();
        // GET: FtEmployees
        public ActionResult Index()
        {

            return View(db.FtEmployees.ToList());
        }

        // GET: FtEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FtEmployee ftEmployee = db.FtEmployees.Find(id);
            if (ftEmployee == null)
            {
                return HttpNotFound();
            }
            return View(ftEmployee);
        }

        // GET: FtEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FtEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bouns,Salary,Name,Age")] FtEmployee ftEmployee)
        {
            if (ModelState.IsValid)
            {
                db.FtEmployees.Add(ftEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ftEmployee);
        }

        // GET: FtEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FtEmployee ftEmployee = db.FtEmployees.Find(id);
            if (ftEmployee == null)
            {
                return HttpNotFound();
            }
            return View(ftEmployee);
        }

        // POST: FtEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bouns,Salary,Name,Age")] FtEmployee ftEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ftEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ftEmployee);
        }

        // GET: FtEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FtEmployee ftEmployee = db.FtEmployees.Find(id);
            if (ftEmployee == null)
            {
                return HttpNotFound();
            }
            return View(ftEmployee);
        }

        // POST: FtEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FtEmployee ftEmployee = db.FtEmployees.Find(id);
            db.FtEmployees.Remove(ftEmployee);
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

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
    public class tbl_statusController : Controller
    {
        private db_employeesEntities1 db = new db_employeesEntities1();

        // GET: tbl_status
        public ActionResult Index()
        {
            return View(db.tbl_status.ToList());
        }

        // GET: tbl_status/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_status tbl_status = db.tbl_status.Find(id);
            if (tbl_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_status);
        }

        // GET: tbl_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_status")] tbl_status tbl_status)
        {
            if (ModelState.IsValid)
            {
                db.tbl_status.Add(tbl_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_status);
        }

        // GET: tbl_status/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_status tbl_status = db.tbl_status.Find(id);
            if (tbl_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_status);
        }

        // POST: tbl_status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_status")] tbl_status tbl_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_status);
        }

        // GET: tbl_status/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_status tbl_status = db.tbl_status.Find(id);
            if (tbl_status == null)
            {
                return HttpNotFound();
            }
            return View(tbl_status);
        }

        // POST: tbl_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_status tbl_status = db.tbl_status.Find(id);
            db.tbl_status.Remove(tbl_status);
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

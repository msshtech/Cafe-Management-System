using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cafe.Models;

namespace Cafe.Controllers
{
    public class cafeRecordsController : Controller
    {
        private cafeDbEntity db = new cafeDbEntity();

        // GET: cafeRecords
        public ActionResult Index()
        {
            return View(db.cafeRecords.ToList());
        }

        // GET: cafeRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeRecord cafeRecord = db.cafeRecords.Find(id);
            if (cafeRecord == null)
            {
                return HttpNotFound();
            }
            return View(cafeRecord);
        }

        // GET: cafeRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cafeRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,C_Name,Food_Name,Quantity,C_Payment_method,Waited_By")] cafeRecord cafeRecord)
        {
            if (ModelState.IsValid)
            {
                db.cafeRecords.Add(cafeRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cafeRecord);
        }

        // GET: cafeRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeRecord cafeRecord = db.cafeRecords.Find(id);
            if (cafeRecord == null)
            {
                return HttpNotFound();
            }
            return View(cafeRecord);
        }

        // POST: cafeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,C_Name,Food_Name,Quantity,C_Payment_method,Waited_By")] cafeRecord cafeRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafeRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cafeRecord);
        }

        // GET: cafeRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeRecord cafeRecord = db.cafeRecords.Find(id);
            if (cafeRecord == null)
            {
                return HttpNotFound();
            }
            return View(cafeRecord);
        }

        // POST: cafeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cafeRecord cafeRecord = db.cafeRecords.Find(id);
            db.cafeRecords.Remove(cafeRecord);
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

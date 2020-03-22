using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class addmedicinesController : Controller
    {
        private Pharmacy_DBEntities db = new Pharmacy_DBEntities();

        // GET: addmedicines
        public ActionResult Index()
        {
            return View(db.medicines.ToList());
        }

        // GET: addmedicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: addmedicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: addmedicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,quantity,price")] medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        //// GET: addmedicines/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    medicine medicine = db.medicines.Find(id);
        //    if (medicine == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(medicine);
        //}

        //// POST: addmedicines/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,name,quantity,price")] medicine medicine)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(medicine).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(medicine);
        //}

        //// GET: addmedicines/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    medicine medicine = db.medicines.Find(id);
        //    if (medicine == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(medicine);
        //}

        //// POST: addmedicines/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    medicine medicine = db.medicines.Find(id);
        //    db.medicines.Remove(medicine);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Controllers
{
    public class MistakeOccurrenceFactorsController : Controller
    {
        private StatisticalQualityControlModel db = new StatisticalQualityControlModel();

        // GET: MistakeOccurrenceFactors
        public ActionResult Index()
        {
            return View(db.MistakeOccurrenceFactors.ToList());
        }

        // GET: MistakeOccurrenceFactors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurrenceFactor mistakeOccurrenceFactor = db.MistakeOccurrenceFactors.Find(id);
            if (mistakeOccurrenceFactor == null)
            {
                return HttpNotFound();
            }
            return View(mistakeOccurrenceFactor);
        }

        // GET: MistakeOccurrenceFactors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MistakeOccurrenceFactors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MistakeOccurenceFactorName")] MistakeOccurrenceFactor mistakeOccurrenceFactor)
        {
            if (ModelState.IsValid)
            {
                db.MistakeOccurrenceFactors.Add(mistakeOccurrenceFactor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mistakeOccurrenceFactor);
        }

        // GET: MistakeOccurrenceFactors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurrenceFactor mistakeOccurrenceFactor = db.MistakeOccurrenceFactors.Find(id);
            if (mistakeOccurrenceFactor == null)
            {
                return HttpNotFound();
            }
            return View(mistakeOccurrenceFactor);
        }

        // POST: MistakeOccurrenceFactors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MistakeOccurenceFactorName")] MistakeOccurrenceFactor mistakeOccurrenceFactor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mistakeOccurrenceFactor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mistakeOccurrenceFactor);
        }

        // GET: MistakeOccurrenceFactors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurrenceFactor mistakeOccurrenceFactor = db.MistakeOccurrenceFactors.Find(id);
            if (mistakeOccurrenceFactor == null)
            {
                return HttpNotFound();
            }
            return View(mistakeOccurrenceFactor);
        }

        // POST: MistakeOccurrenceFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MistakeOccurrenceFactor mistakeOccurrenceFactor = db.MistakeOccurrenceFactors.Find(id);
            db.MistakeOccurrenceFactors.Remove(mistakeOccurrenceFactor);
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

using System;
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
    public class MistakeOccurenceFactorDetailsController : Controller
    {
        private StatisticalQualityControlModel db = new StatisticalQualityControlModel();

        // GET: MistakeOccurenceFactorDetails
        public ActionResult Index()
        {
            var mistakeOccurenceFactorDetails = db.MistakeOccurenceFactorDetails.Include(m => m.MistakeOccurrenceFactor);
            return View(mistakeOccurenceFactorDetails.ToList());
        }

        // GET: MistakeOccurenceFactorDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = db.MistakeOccurenceFactorDetails.Find(id);
            if (mistakeOccurenceFactorDetail == null)
            {
                return HttpNotFound();
            }
            return View(mistakeOccurenceFactorDetail);
        }

        // GET: MistakeOccurenceFactorDetails/Create
        public ActionResult Create()
        {
            ViewBag.MistakeOccurenceFactorID = new SelectList(db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName");
            return View();
        }

        // POST: MistakeOccurenceFactorDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MistakeOccurenceFactorID,MistakeOccurenceFactorDetailName")] MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail)
        {
            if (ModelState.IsValid)
            {
                db.MistakeOccurenceFactorDetails.Add(mistakeOccurenceFactorDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MistakeOccurenceFactorID = new SelectList(db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
            return View(mistakeOccurenceFactorDetail);
        }

        // GET: MistakeOccurenceFactorDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = db.MistakeOccurenceFactorDetails.Find(id);
            if (mistakeOccurenceFactorDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MistakeOccurenceFactorID = new SelectList(db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
            return View(mistakeOccurenceFactorDetail);
        }

        // POST: MistakeOccurenceFactorDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MistakeOccurenceFactorID,MistakeOccurenceFactorDetailName")] MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mistakeOccurenceFactorDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MistakeOccurenceFactorID = new SelectList(db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
            return View(mistakeOccurenceFactorDetail);
        }

        // GET: MistakeOccurenceFactorDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = db.MistakeOccurenceFactorDetails.Find(id);
            if (mistakeOccurenceFactorDetail == null)
            {
                return HttpNotFound();
            }
            return View(mistakeOccurenceFactorDetail);
        }

        // POST: MistakeOccurenceFactorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = db.MistakeOccurenceFactorDetails.Find(id);
            db.MistakeOccurenceFactorDetails.Remove(mistakeOccurenceFactorDetail);
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

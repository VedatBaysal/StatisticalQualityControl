using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;
using static StatisticalQualityControl.Services.SingletonDbModel;

namespace StatisticalQualityControl.Controllers
{
    public class MistakeOccurenceFactorDetailsController : Controller
    {

        // GET: MistakeOccurenceFactorDetails
        public ActionResult Index()
        {
            var mistakeOccurenceFactorDetails = Db.MistakeOccurenceFactorDetails.Include(m => m.MistakeOccurrenceFactor);
            return View(mistakeOccurenceFactorDetails.ToList());
        }
        // GET: MistakeOccurenceFactorDetails/Create
        public ActionResult Create()
        {
            ViewBag.MistakeOccurenceFactorID = new SelectList(Db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName");
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
                Db.MistakeOccurenceFactorDetails.Add(mistakeOccurenceFactorDetail);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MistakeOccurenceFactorID = new SelectList(Db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
            return View(mistakeOccurenceFactorDetail);
        }

        // GET: MistakeOccurenceFactorDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = Db.MistakeOccurenceFactorDetails.Find(id);
            if (mistakeOccurenceFactorDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MistakeOccurenceFactorID = new SelectList(Db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
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
                Db.Entry(mistakeOccurenceFactorDetail).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MistakeOccurenceFactorID = new SelectList(Db.MistakeOccurrenceFactors, "id", "MistakeOccurenceFactorName", mistakeOccurenceFactorDetail.MistakeOccurenceFactorID);
            return View(mistakeOccurenceFactorDetail);
        }

        // GET: MistakeOccurenceFactorDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = Db.MistakeOccurenceFactorDetails.Find(id);
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
            MistakeOccurenceFactorDetail mistakeOccurenceFactorDetail = Db.MistakeOccurenceFactorDetails.Find(id);
            Db.MistakeOccurenceFactorDetails.Remove(mistakeOccurenceFactorDetail);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

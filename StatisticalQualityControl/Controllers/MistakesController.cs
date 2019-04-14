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
    public class MistakesController : Controller
    {
        // GET: Mistakes
        public ActionResult Index()
        {
            return View(Db.Mistakes.ToList());
        }

        // GET: Mistakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mistake mistake = Db.Mistakes.Find(id);
            if (mistake == null)
            {
                return HttpNotFound();
            }
            return View(mistake);
        }

        // GET: Mistakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mistakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MistakeName")] Mistake mistake)
        {
            if (ModelState.IsValid)
            {
                Db.Mistakes.Add(mistake);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mistake);
        }

        // GET: Mistakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mistake mistake = Db.Mistakes.Find(id);
            if (mistake == null)
            {
                return HttpNotFound();
            }
            return View(mistake);
        }

        // POST: Mistakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MistakeName")] Mistake mistake)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(mistake).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mistake);
        }

        // GET: Mistakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mistake mistake = Db.Mistakes.Find(id);
            if (mistake == null)
            {
                return HttpNotFound();
            }
            return View(mistake);
        }

        // POST: Mistakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mistake mistake = Db.Mistakes.Find(id);
            Db.Mistakes.Remove(mistake);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}

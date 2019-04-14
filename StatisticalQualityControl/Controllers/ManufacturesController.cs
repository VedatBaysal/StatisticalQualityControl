using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;
using static StatisticalQualityControl.Services.SingletonDbModel;
using StatisticalQualityControl.Classes;

namespace StatisticalQualityControl.Controllers
{
    public class ManufacturesController : Controller
    {
        // GET: Manufactures
        public ActionResult Index()
        {
            var manufactures = Db.Manufactures.Include(m => m.Product).Include(m => m.Staff);
            return View(manufactures.ToList());
        }

        // GET: Manufactures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = Db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            return View(manufacture);
        }

        // GET: Manufactures/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(Db.Products, "id", "ProductName");
            ViewBag.StaffID = new SelectList(Db.Staffs, "id", "Name");
            return View();
        }

        // POST: Manufactures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProductID,ManufactureDateTime,StaffID,Mistake")] Manufacture manufacture)
        {
            MadeManufactures m = new MadeManufactures();
            //MadeManufactures m2 =new MadeManufactures();
            //if (ModelState.IsValid)
            //{
            //    Db.Manufactures.Add(manufacture);
            //    Db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.ProductID = new SelectList(Db.Products, "id", "ProductName", manufacture.ProductID);
            //ViewBag.StaffID = new SelectList(Db.Staffs, "id", "Name", manufacture.StaffID);
            //return View(manufacture);
            DateTime dt = DateTime.Now.AddDays(-5);

            m.ManufactureCanBeMistakeMethod(5, manufacture.ProductID, -1, 10000, dt, DateTime.Now);
            
            //m2.ManufactureCanBeMistakeMethod(5, manufacture.ProductID, -1, 10000, dt, DateTime.Now);
            return View("Index");
        }

        // GET: Manufactures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = Db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(Db.Products, "id", "ProductName", manufacture.ProductID);
            ViewBag.StaffID = new SelectList(Db.Staffs, "id", "Name", manufacture.StaffID);
            return View(manufacture);
        }

        // POST: Manufactures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProductID,ManufactureDateTime,StaffID,Mistake")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(manufacture).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(Db.Products, "id", "ProductName", manufacture.ProductID);
            ViewBag.StaffID = new SelectList(Db.Staffs, "id", "Name", manufacture.StaffID);
            return View(manufacture);
        }

        // GET: Manufactures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = Db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            return View(manufacture);
        }

        // POST: Manufactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacture manufacture = Db.Manufactures.Find(id);
            Db.Manufactures.Remove(manufacture);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

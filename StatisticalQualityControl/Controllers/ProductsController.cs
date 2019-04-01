using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;
using StatisticalQualityControl.ViewModel;

namespace StatisticalQualityControl.Controllers
{
    public class ProductsController : Controller
    {
        StatisticalQualityControlModel _db = new StatisticalQualityControlModel();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ProductProperties productProperties = new ProductProperties()
            {
                ProductMeasurements = _db.Measurements.ToList(),
                ProductMaterials = _db.Materials.ToList(),
                ProductSectors = _db.Sectors.ToList()
            };
            return View(productProperties);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(string ProductName)
        {
            var ProductColors = Request.Params.Get("ProductColors");
            var ProductMaterials = Request.Params.Get("ProductMaterials");
            var ProductSectors = Request.Params.Get("ProductSectors");
            var ProductMeasurements = Request.Params.Get("ProductMeasurements");
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

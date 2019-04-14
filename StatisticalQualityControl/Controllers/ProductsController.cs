using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using StatisticalQualityControl.Models;
using StatisticalQualityControl.ViewModel;
using static StatisticalQualityControl.Services.SingletonDbModel;

namespace StatisticalQualityControl.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> _products = Db.Products.ToList();
            return View(_products);
        }

        //// GET: Products/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Products/Create
        public ActionResult Create()
        {
            ProductProperties productProperties = new ProductProperties()
            {
                ProductMeasurements = Db.Measurements.ToList(),
                ProductMaterials = Db.Materials.ToList(),
                ProductSectors = Db.Sectors.ToList()
            };
            return View(productProperties);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(string ProductName)
        {
            var ProductMeasurements = Request.Params.Get("MaterialMeasuresOfProduct");
            var _ProductSector = Request.Params.Get("ProductSectors");
            //Burada gelen Requestten verileri parçalıyoruz çünkü birden fazla veri gelebilir
            string[] DivideProductMeasurements = ProductMeasurements.Split(',');
            string[] DivideProductSectors = _ProductSector.Split(',');

            Product p = new Product
            {
                ProductName = ProductName,
                Discontinued = false
            };

            Material material;
            Measurement measurement;
            Sector sectors;
            ProductMaterial productMaterial;
            MaterialMeasuresOfProduct materialMeasuresOfProduct;

            foreach (var item in DivideProductMeasurements) //Burası birden fazla malzemeden oluşması durumunda gerekli
            {
                productMaterial = new ProductMaterial();
                materialMeasuresOfProduct = new MaterialMeasuresOfProduct();
                string[] Divide = item.Split('-'); //buradaki parçalama işlemi (MalzemeAdı - ÖlçüAdı - Altlimit - Üstlimit ) ayrımını yapabilmek için gerekli
                // Divide[0] MalzemeAdı , Divide[1] ÖlçüAdı , Divide[2] Alt limit Divide[3] Üst limit
               
                string materialName = Divide[0];
                string measurementName = Divide[1];
                double lowerLimit = Convert.ToDouble(Divide[2]);
                double upperLimit = Convert.ToDouble(Divide[3]);

                 material = Db.Materials.FirstOrDefault(x => x.MaterialName == materialName);
                 measurement = Db.Measurements.FirstOrDefault(x => x.MeasurementName == measurementName);
                 materialMeasuresOfProduct.LowerSpecificationLimit = lowerLimit;
                 materialMeasuresOfProduct.UpperSpecificationLimit = upperLimit;
                 materialMeasuresOfProduct.Measurement = measurement;
                 productMaterial.MaterialMeasuresOfProducts.Add(materialMeasuresOfProduct); 
                 materialMeasuresOfProduct.ProductMaterial = productMaterial;
                 materialMeasuresOfProduct.ProductMaterial.Material = material;
                 productMaterial.Material = material;
                 productMaterial.Product = p;
                 productMaterial.MaterialMeasuresOfProducts.Add(materialMeasuresOfProduct);
                 p.ProductMaterials.Add(productMaterial);
                 measurement.MaterialMeasuresOfProducts.Add(materialMeasuresOfProduct);

                 Db.ProductMaterials.Add(productMaterial);
                 Db.MaterialMeasuresOfProducts.Add(materialMeasuresOfProduct);
            }

            foreach (var item in DivideProductSectors)
            {
                int s = Convert.ToInt32(item);
                sectors = Db.Sectors.FirstOrDefault(x => x.id == s);
                sectors.Products.Add(p);
                p.Sectors.Add(sectors);
                
            }
            
            //Db.Products.Add(p);

            Db.SaveChanges();
            TempData["swal"] = "swal('Eklendi','Ürün Simülasyonu Başarıyla Oluşturuldu','success')";
            return RedirectToAction("Index");
            
        }

        //// GET: Products/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Products/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Products/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Products/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Controllers
{
    public class MaterialMistakesController : Controller
    {
        StatisticalQualityControlModel _db = new StatisticalQualityControlModel();
        // GET: MaterialMistake
        public ActionResult Index()
        {
            List<Material> _material = _db.Materials.ToList();
            return View(_material);
        }

        public ActionResult Create()
        {
            ViewBag.material = _db.Materials.ToList();
            ViewBag.mistake = _db.Mistakes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(int? MaterialID, int? MistakeID)
        {
            Material mat= _db.Materials.Find(MaterialID);
            Mistake mis = _db.Mistakes.Find(MistakeID);

            mat.Mistakes.Add(mis);
            mis.Materials.Add(mat);

            _db.SaveChanges();
            
            TempData["swal"] = "swal('Ekleme Başarılı','"+mat.MaterialName+": malzemesine "+mis.MistakeName+": hatası eklemesi gerçekleşti','success')"; //SweetAlert

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int MaterialID, int MistakeID)
        {
            //Burada Seçili malzeme ve bu malzemeye ait hata bulundu
            Material mat = _db.Materials.Find(MaterialID);
            Mistake mis = _db.Mistakes.Find(MistakeID);

            //Verileri göndermek için viewbag içerisine aldık
            ViewBag.Mat = mat;
            ViewBag.Mis = mis;
            //Tüm Malzemeleri ve Hataları göndermemiz gerektiği için viewbag ile onları da gönderdik
            ViewBag.material = _db.Materials.ToList();
            ViewBag.mistake = _db.Mistakes.ToList();

            return View();

        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(int? HiddenMaterialID, int? HiddenMistakeID, int? MaterialID, int? MistakeID)
        {
            if (HiddenMistakeID != MistakeID || HiddenMaterialID != MaterialID)
            {
                Material dbMaterial = _db.Materials.Find(HiddenMaterialID);
                Mistake dbMistake = _db.Mistakes.Find(HiddenMistakeID);
                Material SelectedMat = _db.Materials.Find(MaterialID);
                Mistake SelectedMis = _db.Mistakes.Find(MistakeID);
                dbMaterial.Mistakes.Remove(dbMistake);
                dbMistake.Materials.Remove(dbMaterial);
                SelectedMat.Mistakes.Add(SelectedMis);
                SelectedMis.Materials.Add(SelectedMat);

                _db.SaveChanges();

                TempData["swal"] = "swal('Güncelleme Başarılı',' (" +dbMaterial.MaterialName + " - " + SelectedMat.MaterialName + ") (" + dbMistake.MistakeName +" - "+ SelectedMis.MistakeName + ")  güncelleme gerçekleşti','success')"; //SweetAlert
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int MaterialID, int MistakeID)
        {
            //Burada Seçili malzeme ve bu malzemeye ait hata bulundu
            Material SelectedMaterial = _db.Materials.Find(MaterialID);
            Mistake SelectedMistake = _db.Mistakes.Find(MistakeID);

            //Burada Çoka çok ilişkili yapıya uygun olarak malzemeye ait hata silindi.
            SelectedMaterial.Mistakes.Remove(SelectedMistake);
            SelectedMistake.Materials.Remove(SelectedMaterial);

            _db.SaveChanges();

            TempData["swal"] = "swal('Silindi','Silme işlemi başarılı','success')"; //SweetAlert

            return RedirectToAction("Index");
        }
    }
}

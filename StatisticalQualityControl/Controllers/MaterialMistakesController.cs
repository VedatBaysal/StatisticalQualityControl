using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;
using static StatisticalQualityControl.Services.SingletonDbModel;

namespace StatisticalQualityControl.Controllers
{
    public class MaterialMistakesController : Controller
    {
        // GET: MaterialMistake
        public ActionResult Index()
        {
            List<Material> _material = Db.Materials.ToList();
            return View(_material);
        }

        public ActionResult Create()
        {
            ViewBag.material = Db.Materials.ToList();
            ViewBag.mistake = Db.Mistakes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(int? MaterialID, int? MistakeID)
        {
            Material mat= Db.Materials.Find(MaterialID);
            Mistake mis = Db.Mistakes.Find(MistakeID);

            mat.Mistakes.Add(mis);
            mis.Materials.Add(mat);

            Db.SaveChanges();
            
            TempData["swal"] = "swal('Ekleme Başarılı','"+mat.MaterialName+": malzemesine "+mis.MistakeName+": hatası eklemesi gerçekleşti','success')"; //SweetAlert

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int MaterialID, int MistakeID)
        {
            //Burada Seçili malzeme ve bu malzemeye ait hata bulundu
            Material mat = Db.Materials.Find(MaterialID);
            Mistake mis = Db.Mistakes.Find(MistakeID);

            //Verileri göndermek için viewbag içerisine aldık
            ViewBag.Mat = mat;
            ViewBag.Mis = mis;
            //Tüm Malzemeleri ve Hataları göndermemiz gerektiği için viewbag ile onları da gönderdik
            ViewBag.material = Db.Materials.ToList();
            ViewBag.mistake = Db.Mistakes.ToList();

            return View();

        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(int? HiddenMaterialID, int? HiddenMistakeID, int? MaterialID, int? MistakeID)
        {
            if (HiddenMistakeID != MistakeID || HiddenMaterialID != MaterialID)
            {
                Material dbMaterial = Db.Materials.Find(HiddenMaterialID);
                Mistake dbMistake = Db.Mistakes.Find(HiddenMistakeID);
                Material SelectedMat = Db.Materials.Find(MaterialID);
                Mistake SelectedMis = Db.Mistakes.Find(MistakeID);
                dbMaterial.Mistakes.Remove(dbMistake);
                dbMistake.Materials.Remove(dbMaterial);
                SelectedMat.Mistakes.Add(SelectedMis);
                SelectedMis.Materials.Add(SelectedMat);

                Db.SaveChanges();

                TempData["swal"] = "swal('Güncelleme Başarılı',' (" +dbMaterial.MaterialName + " - " + SelectedMat.MaterialName + ") (" + dbMistake.MistakeName +" - "+ SelectedMis.MistakeName + ")  güncelleme gerçekleşti','success')"; //SweetAlert
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int MaterialID, int MistakeID)
        {
            //Burada Seçili malzeme ve bu malzemeye ait hata bulundu
            Material SelectedMaterial = Db.Materials.Find(MaterialID);
            Mistake SelectedMistake = Db.Mistakes.Find(MistakeID);

            //Burada Çoka çok ilişkili yapıya uygun olarak malzemeye ait hata silindi.
            SelectedMaterial.Mistakes.Remove(SelectedMistake);
            SelectedMistake.Materials.Remove(SelectedMaterial);

            Db.SaveChanges();

            TempData["swal"] = "swal('Silindi','Silme işlemi başarılı','success')"; //SweetAlert

            return RedirectToAction("Index");
        }
    }
}

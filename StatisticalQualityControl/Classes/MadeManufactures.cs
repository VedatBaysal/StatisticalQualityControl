using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using StatisticalQualityControl.Models;
using StatisticalQualityControl.Facade;
using static StatisticalQualityControl.Services.GetDbSet;
using static StatisticalQualityControl.Services.SingletonDbModel;
using static StatisticalQualityControl.Services.SingletonRandom;
using static StatisticalQualityControl.Classes.SelectRandDateTimeInRange;

namespace StatisticalQualityControl.Classes
{
    public class MadeManufactures
    {
        private readonly object balanceLock = new object();
        private DateTime _selectedDate;
        //List<Material> _materials = new List<Material>();
        List<Mistake> _mistakes = new List<Mistake>();
        private MeasuresOfManufactureProduct _measuresOfManufactureProduct;
        private Manufacture _manufacture;
        private ManufactureMistake _manufactureMistake;
        private Product _manufactureProduct;
        private List<ProductMaterial> _productMaterials;

        private List<Manufacture> _beforeAddManufacturesDb = new List<Manufacture>();

        private List<MeasuresOfManufactureProduct> _beforeAddMeasuresOfManufactureProductsDb = new List<MeasuresOfManufactureProduct>();

        private List<ManufactureMistake> _beforeAddManufactureMistakeDb = new List<ManufactureMistake>();

        // ürünün hatalı olup olmadığı yüzdesel olarak burada belirleniyor
        public void ManufactureCanBeMistakeMethod(int mistakePercentage, int productId, int staffId, int manufactureCount, DateTime dateRangeStart, DateTime dateRangeEnd)
        {
            _manufactureProduct =  CrudProduct.GetById(productId);


            //_manufactureProduct = Db.Products.FirstOrDefault(x=> x.id == productId); //üretimi yapılacak ürün bulunur

            _productMaterials = _manufactureProduct.ProductMaterials.ToList(); //üretilecek ürünün malzemleri bulunur.

            #region UruneAitHatalar
            //Oluşabilecek hatalar listeye ekleniyor (malzemeye göre bulunur)
            foreach (var item in _productMaterials)
            {
                _mistakes.AddRange(item.Material.Mistakes);
            }

            #endregion

            #region Simülasyon

            int rnd;
            for (var i = 0; i < manufactureCount; i++) //bu döngü n adet ürün üretim simülasyonu için multi thread kullanılıp performans kazanılmalıdır.
            {
                int selectedStaffId = -1;
                if (staffId == -1)
                {
                    var selectedStaff =  CrudStaff.GetRandomElement();

                    selectedStaffId =  selectedStaff.id;
                }

                _manufacture = new Manufacture();
                _selectedDate = SelectDateTime(dateRangeStart, dateRangeEnd);
                _manufacture.ManufactureDateTime = _selectedDate;
                _manufacture.Product = _manufactureProduct;
                _manufacture.StaffID = selectedStaffId;
                _manufacture.Staff =  CrudStaff.GetById(selectedStaffId);
                rnd = Rnd.Next(1, 101);
                if (rnd > mistakePercentage
                ) //Örn: %5 hata payı durumunda rastgele gelen rnd değişkeninin 5 den büyük olaması durumda hatasız kabul edilir
                {
                    ManufactureNotMistakeMethod(productId);
                    _manufacture.Mistake = false;
                }
                else
                {
                    ManufactureMistakeMethod(productId);
                    _manufacture.Mistake = true;
                }

                //CrudManufacture.Add(_manufacture);
                _beforeAddManufacturesDb.Add(_manufacture);
            }
            #endregion

            CrudManufacture.AddRange(_beforeAddManufacturesDb);
            CrudMeasuresOfManufactureProduct.AddRange(_beforeAddMeasuresOfManufactureProductsDb);
            CrudManufactureMistake.AddRange(_beforeAddManufactureMistakeDb);
        }

        public void ManufactureMistakeMethod(int productId)
        {

            double decimals;
            do
            {
                decimals = Rnd.NextDouble();
                decimals = Math.Round(decimals, 3);

            } while (decimals > 0);

            int MistakeUpperOrLower = Rnd.Next(2);
            double materialMeasure;
            if (MistakeUpperOrLower == 0) //burada Alt limite göre Hata Yaptırıyoruz 
            {
                foreach (var item in _productMaterials)
                {
                    _measuresOfManufactureProduct = new MeasuresOfManufactureProduct(); //döngü içerisinde new yapıyoruz aksi halde son veriyi yazıyor !!!

                    //var selectedMaterialMeasuresOfProduct = item.MaterialMeasuresOfProducts.FirstOrDefault(x => x.ProductMaterial.ProductID == productId);
                    //_measuresOfManufactureProduct.MaterialMeasuresOfProduct = selectedMaterialMeasuresOfProduct;

                    MaterialMeasuresOfProduct selectedMaterialMeasuresOfProduct = null;
                    foreach (var a in  CrudMaterialMeasuresOfProduct.GetAll())
                    {
                        if (a.ProductMaterial.ProductID == productId)
                        {
                            selectedMaterialMeasuresOfProduct = a;
                        }
                    }
                    _measuresOfManufactureProduct.MaterialMeasuresOfProduct = selectedMaterialMeasuresOfProduct;
                    var selectedMaterialLowerLimit = Convert.ToInt32(selectedMaterialMeasuresOfProduct.UpperSpecificationLimit);

                    materialMeasure = selectedMaterialLowerLimit - 1 + decimals;
                    _measuresOfManufactureProduct.MaterialMeasure = materialMeasure;

                    _beforeAddMeasuresOfManufactureProductsDb.Add(_measuresOfManufactureProduct);
                    //CrudMeasuresOfManufactureProduct.Add(_measuresOfManufactureProduct);
                }
            }
            else // burada üst limite göre hata yaptırıyoruz
            {
                foreach (var item in _productMaterials)
                {
                    _measuresOfManufactureProduct = new MeasuresOfManufactureProduct(); //döngü içerisinde new yapıyoruz aksi halde son veriyi yazıyor !!!

                    //var selectedMaterialMeasuresOfProduct = item.MaterialMeasuresOfProducts.FirstOrDefault(x => x.ProductMaterial.ProductID == productId);
                    //_measuresOfManufactureProduct.MaterialMeasuresOfProduct = selectedMaterialMeasuresOfProduct;

                    MaterialMeasuresOfProduct selectedMaterialMeasuresOfProduct = null;
                    foreach (var a in  CrudMaterialMeasuresOfProduct.GetAll())
                    {
                        if (a.ProductMaterial.ProductID == productId)
                        {
                            selectedMaterialMeasuresOfProduct = a;
                        }
                    }
                    _measuresOfManufactureProduct.MaterialMeasuresOfProduct = selectedMaterialMeasuresOfProduct;
                    var selectedMaterialUpperLimit = Convert.ToInt32(selectedMaterialMeasuresOfProduct.UpperSpecificationLimit);
                    materialMeasure = selectedMaterialUpperLimit + decimals;
                    _measuresOfManufactureProduct.MaterialMeasure = materialMeasure;
                    _beforeAddMeasuresOfManufactureProductsDb.Add(_measuresOfManufactureProduct);
                    //CrudMeasuresOfManufactureProduct.Add(_measuresOfManufactureProduct);
                }
            }
            
            var selectMisOccFacDetail =  CrudMistakeOccurenceFactorDetail.GetRandomElement();

            var mistakeCount = Rnd.Next(1, _mistakes.Count + 1);

            var selectedMistake = _mistakes.OrderBy(x => x.id).Skip(mistakeCount - 1).FirstOrDefault();

            _manufactureMistake = new ManufactureMistake
            {
                ManufactureID = _manufacture.id,
                MistakeID = selectedMistake.id,
                MistakeOccurenceFactorDetailID = selectMisOccFacDetail.id
            };
            _beforeAddManufactureMistakeDb.Add(_manufactureMistake);
            //CrudManufactureMistake.Add(_manufactureMistake);


        }

        public void ManufactureNotMistakeMethod(int productId)
        {
            foreach (var item in _productMaterials)
            {
                _measuresOfManufactureProduct = new MeasuresOfManufactureProduct(); //döngü içerisinde new yapıyoruz aksi halde son veriyi yazıyor !!!

                MaterialMeasuresOfProduct selectedMaterialMeasuresOfProduct =null;
                foreach (var a in  CrudMaterialMeasuresOfProduct.GetAll())
                {
                    if (a.ProductMaterial.ProductID == productId)
                    {
                         selectedMaterialMeasuresOfProduct = a;
                    }
                }
                _measuresOfManufactureProduct.MaterialMeasuresOfProduct = selectedMaterialMeasuresOfProduct;

                var selectedMaterialLowerLimit = Convert.ToInt32(selectedMaterialMeasuresOfProduct.LowerSpecificationLimit);

                var selectedMaterialUpperLimit = Convert.ToInt32(selectedMaterialMeasuresOfProduct.UpperSpecificationLimit);

                var measure = Rnd.Next(selectedMaterialLowerLimit, selectedMaterialUpperLimit + 1);
                _measuresOfManufactureProduct.MaterialMeasure = measure;
                _beforeAddMeasuresOfManufactureProductsDb.Add(_measuresOfManufactureProduct);
                //CrudMeasuresOfManufactureProduct.Add(_measuresOfManufactureProduct);
            }
        }


    }
}
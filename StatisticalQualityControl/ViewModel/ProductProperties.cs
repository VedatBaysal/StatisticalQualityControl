using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  StatisticalQualityControl.Models;

namespace StatisticalQualityControl.ViewModel
{
    public class ProductProperties
    {
        public Product SelectedProduct { get; set; }
        public List<Material> ProductMaterials { get; set; }
        public List<Sector> ProductSectors { get; set; }
        public List<Measurement> ProductMeasurements { get; set; }
        public List<MaterialMeasuresOfProduct> MaterialMeasuresOfProducts { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
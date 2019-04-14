using StatisticalQualityControl.Services;

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeasuresOfManufactureProduct")]
    public partial class MeasuresOfManufactureProduct: EntityObject
    {
        public int id { get; set; }

        public int MaterialMeasuresOfProductID { get; set; }

        public double MaterialMeasure { get; set; }

        public virtual MaterialMeasuresOfProduct MaterialMeasuresOfProduct { get; set; }
    }
}

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeasuresOfManufactureProduct")]
    public partial class MeasuresOfManufactureProduct
    {
        public int id { get; set; }

        public int MaterialMeasuresOfProductID { get; set; }

        public double UpperSpecificationLimit { get; set; }

        public double LowerSpecificationLimit { get; set; }

        public virtual MaterialMeasuresOfProduct MaterialMeasuresOfProduct { get; set; }
    }
}

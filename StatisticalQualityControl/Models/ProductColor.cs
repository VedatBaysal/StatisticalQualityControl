namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductColor
    {
        public int id { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(7)]
        public string HexColorCode { get; set; }

        public virtual Product Product { get; set; }
    }
}

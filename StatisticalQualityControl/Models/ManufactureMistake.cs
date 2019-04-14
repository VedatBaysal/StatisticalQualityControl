using StatisticalQualityControl.Services;

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManufactureMistake")]
    public partial class ManufactureMistake: EntityObject
    {
        public int id { get; set; }

        public int ManufactureID { get; set; }

        public int MistakeID { get; set; }

        public int MistakeOccurenceFactorDetailID { get; set; }

        public virtual Manufacture Manufacture { get; set; }

        public virtual MistakeOccurenceFactorDetail MistakeOccurenceFactorDetail { get; set; }

        public virtual Mistake Mistake { get; set; }
    }
}

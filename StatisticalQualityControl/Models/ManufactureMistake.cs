namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManufactureMistake")]
    public partial class ManufactureMistake
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ManufactureID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MistakeID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MistakeOccurenceFactorDetailID { get; set; }

        public virtual Manufacture Manufacture { get; set; }

        public virtual MistakeOccurenceFactorDetail MistakeOccurenceFactorDetail { get; set; }

        public virtual Mistake Mistake { get; set; }
    }
}

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MistakeOccurenceFactorDetail")]
    public partial class MistakeOccurenceFactorDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MistakeOccurenceFactorDetail()
        {
            ManufactureMistakes = new HashSet<ManufactureMistake>();
        }

        public int id { get; set; }

        public int MistakeOccurenceFactorID { get; set; }

        [Required]
        [StringLength(150)]
        public string MistakeOccurenceFactorDetailName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureMistake> ManufactureMistakes { get; set; }

        public virtual MistakeOccurrenceFactor MistakeOccurrenceFactor { get; set; }
    }
}

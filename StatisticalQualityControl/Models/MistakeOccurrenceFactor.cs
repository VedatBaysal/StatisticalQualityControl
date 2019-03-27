namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MistakeOccurrenceFactor")]
    public partial class MistakeOccurrenceFactor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MistakeOccurrenceFactor()
        {
            MistakeOccurenceFactorDetails = new HashSet<MistakeOccurenceFactorDetail>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string MistakeOccurenceFactorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MistakeOccurenceFactorDetail> MistakeOccurenceFactorDetails { get; set; }
    }
}

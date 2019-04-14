using StatisticalQualityControl.Services;

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measurement: EntityObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Measurement()
        {
            MaterialMeasuresOfProducts = new HashSet<MaterialMeasuresOfProduct>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string MeasurementName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialMeasuresOfProduct> MaterialMeasuresOfProducts { get; set; }
    }
}

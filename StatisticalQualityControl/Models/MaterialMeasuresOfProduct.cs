using StatisticalQualityControl.Services;

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialMeasuresOfProduct")]
    public partial class MaterialMeasuresOfProduct: EntityObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialMeasuresOfProduct()
        {
            MeasuresOfManufactureProducts = new HashSet<MeasuresOfManufactureProduct>();
        }

        public int id { get; set; }

        public int ProductMaterialID { get; set; }

        public int MeasurementID { get; set; }

        public double UpperSpecificationLimit { get; set; }

        public double LowerSpecificationLimit { get; set; }

        public virtual Measurement Measurement { get; set; }

        public virtual ProductMaterial ProductMaterial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasuresOfManufactureProduct> MeasuresOfManufactureProducts { get; set; }
    }
}

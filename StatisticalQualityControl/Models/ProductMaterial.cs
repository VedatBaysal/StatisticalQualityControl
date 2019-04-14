using StatisticalQualityControl.Services;

namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductMaterial: EntityObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductMaterial()
        {
            MaterialMeasuresOfProducts = new HashSet<MaterialMeasuresOfProduct>();
        }

        public int id { get; set; }

        public int ProductID { get; set; }

        public int MaterialID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialMeasuresOfProduct> MaterialMeasuresOfProducts { get; set; }

        public virtual Material Material { get; set; }

        public virtual Product Product { get; set; }
    }
}

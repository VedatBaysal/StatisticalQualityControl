namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manufacture")]
    public partial class Manufacture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacture()
        {
            ManufactureMistakes = new HashSet<ManufactureMistake>();
        }

        public int id { get; set; }

        public int ProductID { get; set; }

        public DateTime ManufactureDateTime { get; set; }

        public int StaffID { get; set; }

        public bool Mistake { get; set; }

        public virtual Product Product { get; set; }

        public virtual Staff Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureMistake> ManufactureMistakes { get; set; }
    }
}

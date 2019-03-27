namespace StatisticalQualityControl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StaffLeaveDay
    {
        public int id { get; set; }

        public int StaffID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StaffLeaveDate { get; set; }

        public virtual Staff Staff { get; set; }
    }
}

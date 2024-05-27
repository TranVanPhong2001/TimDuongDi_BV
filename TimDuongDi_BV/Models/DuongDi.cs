namespace TimDuongDi_BV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuongDi")]
    public partial class DuongDi
    {
        public int id { get; set; }

        [StringLength(500)]
        public string diemDi { get; set; }

        [StringLength(500)]
        public string diemDen { get; set; }

        [StringLength(50)]
        public string loTrinh { get; set; }

        public int? maTang { get; set; }

        public virtual Tang Tang { get; set; }
    }
}

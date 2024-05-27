namespace TimDuongDi_BV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tang")]
    public partial class Tang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tang()
        {
            DuongDis = new HashSet<DuongDi>();
        }

        [Key]
        public int maTang { get; set; }

        [StringLength(50)]
        public string tenTang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DuongDi> DuongDis { get; set; }
    }
}

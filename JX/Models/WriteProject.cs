namespace JX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WriteProject")]
    public partial class WriteProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WriteProject()
        {
            WriteComment = new HashSet<WriteComment>();
        }

        [Key]
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public DateTime WriteTime { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Contents { get; set; }

        public int UpCount { get; set; }

        public int DownCount { get; set; }

        public int WriteState { get; set; }

        [StringLength(100)]
        public string StateInfo { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteComment> WriteComment { get; set; }

        public virtual WriteStates WriteStates { get; set; }
    }
}

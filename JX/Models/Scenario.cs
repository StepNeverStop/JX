namespace JX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Scenario")]
    public partial class Scenario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scenario()
        {
            UserScenarioComment = new HashSet<UserScenarioComment>();
        }

        [Key]
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public int Counts { get; set; }

        public DateTime WriteTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Contents { get; set; }

        public int UpCount { get; set; }

        public int DownCount { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserScenarioComment> UserScenarioComment { get; set; }
    }
}

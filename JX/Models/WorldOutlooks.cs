namespace JX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorldOutlooks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorldOutlooks()
        {
			//Projects = new HashSet<Projects>();
			UserWorldOutlookComment = new HashSet<UserWorldOutlookComment>();
        }

        [Key]
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public DateTime WriteTime { get; set; }

        public int UpCount { get; set; }

        public int DownCount { get; set; }

        [Required]
        [StringLength(1000)]
        public string Contents { get; set; }

        public char IsBelongToMe { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		//public virtual ICollection<Projects> Projects { get; set; }

		public virtual Projects Projects { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorldOutlookComment> UserWorldOutlookComment { get; set; }
    }
}

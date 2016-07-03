namespace JX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWorldOutlookComment")]
    public partial class UserWorldOutlookComment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorldOutlookID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime WriteTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContentTypeNum { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public virtual ContentTypes ContentTypes { get; set; }

        public virtual Users Users { get; set; }

        public virtual WorldOutlooks WorldOutlooks { get; set; }
    }
}

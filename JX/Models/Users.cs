namespace JX.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Scenario = new HashSet<Scenario>();
            UserScenarioComment = new HashSet<UserScenarioComment>();
            UserWorldOutlookComment = new HashSet<UserWorldOutlookComment>();
            WorldOutlooks = new HashSet<WorldOutlooks>();
            WriteComment = new HashSet<WriteComment>();
            WriteProject = new HashSet<WriteProject>();
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        public string MD5Password { get; set; }

        public int UserRole { get; set; }

        public int? AttentionCount { get; set; }

        public int? FansCount { get; set; }

        [Required]
        [StringLength(16)]
        public string Nickname { get; set; }

        public virtual Roles Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scenario> Scenario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserScenarioComment> UserScenarioComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorldOutlookComment> UserWorldOutlookComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorldOutlooks> WorldOutlooks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteComment> WriteComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WriteProject> WriteProject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects { get; set; }


    }
}

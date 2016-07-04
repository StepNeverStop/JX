namespace JX.Models {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Projects {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Projects() {
			Scenario = new HashSet<Scenario>();
			//WorldOutlooks1 = new HashSet<WorldOutlooks>();
			WriteProject = new HashSet<WriteProject>();

		}
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Users")]
		public int UserID { get; set; }
		[Required]
		[StringLength(20)]
		public string ProjectName { get; set; }

		//[Required]
		//[StringLength(3)]
		//public string ProjectTypes { get; set; }

		[Required]
		[StringLength(2)]
		public string WriteType { get; set; }

		public int ProjectState { get; set; }

		[Required]
		[StringLength(200)]
		public string ProjectIntro { get; set; }

		//[ForeignKey(nameof(WorldOutlooks))]
		//public int? WorldOutlooksID { get; set; }

		[Column(TypeName = "ntext")]
		public string ScenarioContents { get; set; }

		public virtual Users Users { get; set; }
		public virtual ProjectStates ProjectStates { get; set; }

		//public virtual WorldOutlooks WorldOutlooks { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Scenario> Scenario { get; set; }

		//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		//public virtual ICollection<WorldOutlooks> WorldOutlooks1 { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<WriteProject> WriteProject { get; set; }


		public ICollection<ProjectTypes> ProjectTypes { get; set; }
	}
}

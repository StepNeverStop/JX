namespace JX.Models {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class ProjectTypes {
		[Required]
		[StringLength(4)]
		public string TypeName { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TypeNum { get; set; }

		public ICollection<Projects> Projects { get; set; }
	}
}

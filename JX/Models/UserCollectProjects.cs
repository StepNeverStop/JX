using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JX.Models
{
    public class UserCollectProjects
    {
        [Key,Column(Order =0)]
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Key,Column(Order =1)]
        [ForeignKey("Projects")]
        public int ProjectID { get; set; }

        public virtual Users Users { get; set; }

        public virtual Projects Projects { get; set; }
    }
}

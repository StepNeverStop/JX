using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JX.Models
{
    public class UserAttentions
    {

        [Key,Column(Order =0)]
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Key,Column(Order =1)]
        [ForeignKey("BeAttentedUsers")]
        public int BeAttentedUserID { get; set; }
        
        public virtual Users Users { get; set; }
		public virtual Users BeAttentedUsers { get; set; }

	}
}

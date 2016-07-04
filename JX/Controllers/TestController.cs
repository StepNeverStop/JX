using JX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace JX.Controllers {
	public class TestController : Controller {
		// GET: Test
		public ActionResult Index() {
			EntityDbContext db = new EntityDbContext();
			var p = db.Projects.Include(t=>t.ProjectTypes).FirstOrDefault();
			string test = "";
			p.ProjectTypes.ToList().ForEach(t => {
				test += t.TypeName + " ";
			});
			return Content(test);
		}
	}
}
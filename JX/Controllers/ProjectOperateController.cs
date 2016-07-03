using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JX.Models;

namespace JX.Controllers
{
    public class ProjectOperateController : Controller
    {
        [HttpPost]
        [Authorize]
        public ActionResult ApplyForNewProject(string projectName, string projectTypes, string writeType, int projectState, string projectIntro)
        {
            EntityDbContext db = new EntityDbContext();

            if(db.Projects.Where(p=>p.ProjectName.Equals(projectName)).FirstOrDefault()==null)
            {
                db.Projects.Add(new Projects
                {
                    ProjectName = projectName,
                    ProjectTypes = projectTypes,
                    WriteType = writeType,
                    ProjectState = 3,
                    ProjectIntro = projectIntro,
                    UserID = int.Parse(User.Identity.Name)
                });
                db.SaveChanges();
                return View();//显示申请成功，待审核的页面
            }

            return View();//显示申请失败，请重新填写的页面
        }
    }
}
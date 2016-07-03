using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JX.Models;

namespace JX.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult ShowCheckProjects()
        {
            EntityDbContext db = new EntityDbContext();
            List<Projects> Projects = db.Projects.Where(p => p.ProjectState == 3).ToList();
            return View();//显示所有待审核的项目
        }

        public ActionResult CheckProjectsYes(string id)//通过审核
        {
            EntityDbContext db = new EntityDbContext();
            Projects project = db.Projects.Find(id);

            if (project.WriteType.Equals("单"))
                project.ProjectState = db.ProjectStates.Where(p => p.StateName.Equals("可创作")).FirstOrDefault().ProjectState;
            else
                project.ProjectState = db.ProjectStates.Where(p => p.StateName.Equals("征集世界观中")).FirstOrDefault().ProjectState;

            UpdateModel(project);
            db.SaveChanges();

            return RedirectToAction("ShowCheckProjects","Admin");//显示其他待审核的项目
        }

        public ActionResult CheckProjectsNo(string id)//不通过审核，直接删除
        {
            EntityDbContext db = new EntityDbContext();
            Projects project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("ShowCheckProjects", "Admin");//显示其他待审核的项目
        }
    }
}
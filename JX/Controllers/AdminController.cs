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
        public ActionResult ShowCheckProjects()//显示待审核项目
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

        public ActionResult ChooseWoForProj(int worldoutllookID)//为项目确定世界观
        {

            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wolook = db.WorldOutlooks.Find(worldoutllookID);
            wolook.IsBelongToMe = 'Y';
            Projects project = db.Projects.Find(wolook.ProjectID);
            project.ProjectState = db.ProjectStates.Where(p => p.StateName.Equals("征集故事线中")).FirstOrDefault().ProjectState;
            UpdateModel(wolook);
            UpdateModel(project);
            db.SaveChanges();

            return View();//更新项目新状态
        }
        
        public ActionResult ChooseScenarioForProj(int scenarioID)//为项目确定故事线
        {
            EntityDbContext db = new EntityDbContext();
            Scenario scenario = db.Scenario.Find(scenarioID);
            scenario.IsBelongToMe = 'Y';
            if(scenario.Contents.Equals("完结"))
            {
                Projects project = db.Projects.Find(scenario.ProjectID);
                project.ProjectState = db.ProjectStates.Where(p => p.StateName.Equals("可创作")).FirstOrDefault().ProjectState;
                UpdateModel(project);
            }
            
            UpdateModel(scenario);
            db.SaveChanges();

            return View();//更新项目新状态
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JX.Models;

namespace JX.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            EntityDbContext db = new EntityDbContext();
            List<Projects> Projects = db.Projects.Where(p=>p.ProjectState==2).ToList();//显示可创作的项目
            List<Projects> newList = new List<Models.Projects>();
            Random random = new Random();   //乱序实现随机

            Users MyAccount = db.Users.Where(p => p.Username.Equals(User.Identity.Name.ToString())).FirstOrDefault();

            if(MyAccount.UserRole==db.Roles.Where(p=>p.RoleName.Equals("总版主")).FirstOrDefault().UserRole)
            {
                ViewBag.CheckProjectsCount = db.Projects.Where(p => p.ProjectState == 3).Count();
                //如果是管理员 显示待审核项目的数目
            }

            ViewBag.Nickname = MyAccount.Nickname;

            //乱序插入
            foreach (Projects proj in Projects)
            {
                newList.Insert(random.Next(newList.Count), proj);
            }

            
            return View(newList);
        }
    }
}
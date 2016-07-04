using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JX.Models;

namespace JX.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult suibiankankan()
        {
            return RedirectToAction("HomePage", "Home");
        }

        public ActionResult ShowTextList(string typename)//显示文本页面
        {
            //虽然可以总的写一个方法，但是我就喜欢分开写 ，你咬我呀
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName.Equals(typename)).FirstOrDefault();
            ViewBag.xiaoshuolist = a.Projects;
            return View();//显示文本页面
        }
        public ActionResult ShowWeixiaoshuoList()//显示微小说列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "微小说").FirstOrDefault();
            ViewBag.weixiaoshuo = a.Projects;
            return View();//显示微小说页面
        }

        public ActionResult ShowXiuzhenList()//显示修真列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "修真").FirstOrDefault();
            ViewBag.xiuzhen = a.Projects;
            return View();
        }

        public ActionResult ShowDushiList()//显示都市列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "都市").FirstOrDefault();
            ViewBag.dushi = a.Projects;
            return View();
        }

        public ActionResult ShowYanqingList()//显示言情列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "言情").FirstOrDefault();
            ViewBag.yanqing = a.Projects;
            return View();
        }

        public ActionResult ShowXuanhuanList()//显示玄幻列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "玄幻").FirstOrDefault();
            ViewBag.xuanhuan = a.Projects;
            return View();
        }

        public ActionResult ShowJitangList()//显示鸡汤列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "鸡汤").FirstOrDefault();
            ViewBag.jitang = a.Projects;
            return View();
        }

        public ActionResult ShowBijiList()//显示笔记列表
        {
            EntityDbContext db = new EntityDbContext();
            var a = db.ProjectTypes.Include(t => t.Projects).Where(p => p.TypeName == "笔记").FirstOrDefault();
            ViewBag.biji = a.Projects;
            return View();
        }
    }
}
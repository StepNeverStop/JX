using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JX.Models;

namespace JX.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ClickUpWorldOutlook(int id)//点赞世界观
        {
            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wols = db.WorldOutlooks.Find(id);
            //找到相应条目

            wols.UpCount++;

            db.UserWorldOutlookComment.Add(new UserWorldOutlookComment
            {
                WorldOutlookID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("赞")).First().ContentTypeNum,
                Content = "赞"
            });

            UpdateModel(wols);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已赞 不刷新页面
        }

        public ActionResult CancelUpWorldOutlook(int id)//取消赞 世界观
        {
            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wols = db.WorldOutlooks.Find(id);
            //找到相应条目

            wols.UpCount--;

            UserWorldOutlookComment uwoc = db.UserWorldOutlookComment.Where(p => p.WorldOutlookID.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum==1).FirstOrDefault();
            db.UserWorldOutlookComment.Remove(uwoc);

            UpdateModel(wols);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消赞 不刷新页面
        }

        public ActionResult ClickDownWorldOutlook(int id)//踩 世界观
        {
            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wols = db.WorldOutlooks.Find(id);
            //找到相应条目

            wols.UpCount++;

            db.UserWorldOutlookComment.Add(new UserWorldOutlookComment
            {
                WorldOutlookID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("踩")).First().ContentTypeNum,
                Content = "踩"
            });

            UpdateModel(wols);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已踩 不刷新页面
        }

        public ActionResult CancelDownWorldOutlook(int id)//取消踩 世界观
        {

            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wols = db.WorldOutlooks.Find(id);
            //找到相应条目

            wols.UpCount--;

            UserWorldOutlookComment uwoc = db.UserWorldOutlookComment.Where(p => p.WorldOutlookID.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum == 2).FirstOrDefault();
            db.UserWorldOutlookComment.Remove(uwoc);

            UpdateModel(wols);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消踩 不刷新页面
            
        }

        public ActionResult WorldOutlookComment(int id, string comment)//评论 世界观
        {
            EntityDbContext db = new EntityDbContext();
            WorldOutlooks wols = db.WorldOutlooks.Find(id);
            //找到相应条目

            wols.UpCount++;

            db.UserWorldOutlookComment.Add(new UserWorldOutlookComment
            {
                WorldOutlookID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("评论")).First().ContentTypeNum,
                Content = comment
            });

            UpdateModel(wols);
            db.SaveChanges();
            return View();//应刷新页面 并显示评论内容
        }

        public ActionResult DeleteWorldOutlookComment(int id,DateTime dtime)//删除评论，应管理员才可以删，功能未想好，待写
        {
            return View();
        }

        public ActionResult SubmitWorldOutlook(int id,string content)//写世界观
        {
            EntityDbContext db = new EntityDbContext();
            db.WorldOutlooks.Add(new WorldOutlooks
            {
                ProjectID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                UpCount = 0,
                DownCount = 0,
                Contents = content
            });
            db.SaveChanges();
            return View();//返回当前项目的页面  并显示自己刚刚提交的信息
        }

        public ActionResult SubmitScenario(int id,string content)//写故事线
        {

            EntityDbContext db = new EntityDbContext();
            int count = db.Scenario.Where(p => p.ProjectID == id).ToList().Count;
            db.Scenario.Add(new Scenario
            {
                ProjectID = id,
                Counts = count++,
                Contents = content,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                UpCount = 0,
                DownCount = 0
            });
            db.SaveChanges();

            return View();//返回当前项目的页面 并显示自己刚刚提交的信息
        }

        //public ActionResult SubmitWriteProject(int id,)//创作
    }
}
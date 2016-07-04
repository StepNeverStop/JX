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
                Contents = content,
                IsBelongToMe='N'
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

        public ActionResult SubmitWriteProject(int projectID,int chapNum,string chapTitle,string contents)//创作
        {
            EntityDbContext db = new EntityDbContext();
            if(db.WriteProject.Where(p=>p.ProjectID==projectID&&p.UserID==int.Parse(User.Identity.Name)&&p.ChapNum==chapNum).FirstOrDefault()==null)
            {
                db.WriteProject.Add(new WriteProject
                {
                    ProjectID = projectID,
                    UserID = int.Parse(User.Identity.Name),
                    WriteTime = DateTime.Now,
                    UpCount = 0,
                    DownCount = 0,
                    Contents = contents,
                    WriteState = 0,
                    ChapNum = chapNum,
                    ChapTitle = chapTitle
                });
                db.SaveChanges();
            }
            return View();//显示提交成功 待审核状态
        }


        public ActionResult ClickUpScenario(int id)//点赞故事线
        {
            EntityDbContext db = new EntityDbContext();
            Scenario scenario = db.Scenario.Find(id);
            //找到相应条目

            scenario.UpCount++;

            db.UserScenarioComment.Add(new UserScenarioComment
            {
                ScenarioID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("赞")).First().ContentTypeNum,
                Content = "赞"
            });

            UpdateModel(scenario);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已赞 不刷新页面
        }
        
        public ActionResult CancelClickUpScenario(int id)//取消赞故事线
        {
            EntityDbContext db = new EntityDbContext();
            Scenario scenario = db.Scenario.Find(id);
            //找到相应条目

            scenario.UpCount--;

            UserScenarioComment uscomment = db.UserScenarioComment.Where(p => p.Scenario.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum == 1).FirstOrDefault();
            db.UserScenarioComment.Remove(uscomment);

            UpdateModel(scenario);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消赞 不刷新页面
        }

        public ActionResult ClickDownScenario(int id)//踩 故事线
        {
            EntityDbContext db = new EntityDbContext();
            Scenario scenario = db.Scenario.Find(id);
            //找到相应条目

            scenario.UpCount++;

            db.UserScenarioComment.Add(new UserScenarioComment
            {
                ScenarioID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("踩")).First().ContentTypeNum,
                Content = "踩"
            });

            UpdateModel(scenario);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已踩 不刷新页面
        }

        public ActionResult CancelClickDownScenario(int id)//取消 踩  故事线
        {
            EntityDbContext db = new EntityDbContext();
            Scenario scenario = db.Scenario.Find(id);
            //找到相应条目

            scenario.UpCount--;

            UserScenarioComment uscomment = db.UserScenarioComment.Where(p => p.ScenarioID.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum == 2).FirstOrDefault();
            db.UserScenarioComment.Remove(uscomment);

            UpdateModel(scenario);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消踩 不刷新页面
        }

        public ActionResult ClickUpWriteProject(int id)//点赞创作
        {
            EntityDbContext db = new EntityDbContext();
            WriteProject wproject = db.WriteProject.Find(id);
            //找到相应条目

            wproject.UpCount++;

            db.WriteComment.Add(new WriteComment
            {
                WriteProjectID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("赞")).First().ContentTypeNum,
                Content = "赞"
            });

            UpdateModel(wproject);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已赞 不刷新页面
        }

        public ActionResult CancelClickUpWriteProject(int id)//取消赞创作
        {
            EntityDbContext db = new EntityDbContext();
            WriteProject wproject = db.WriteProject.Find(id);
            //找到相应条目

            wproject.UpCount--;

            WriteComment wcomment = db.WriteComment.Where(p => p.WriteProject.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum == 1).FirstOrDefault();
            db.WriteComment.Remove(wcomment);

            UpdateModel(wproject);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消赞 不刷新页面
        }
        
        public ActionResult ClickDownWriteProject(int id)//踩创作
        {
            EntityDbContext db = new EntityDbContext();
            WriteProject wproject = db.WriteProject.Find(id);
            //找到相应条目

            wproject.UpCount++;

            db.WriteComment.Add(new WriteComment
            {
                WriteProjectID = id,
                UserID = int.Parse(User.Identity.Name),
                WriteTime = DateTime.Now,
                ContentTypeNum = db.ContentTypes.Where(p => p.ContentType.Equals("踩")).First().ContentTypeNum,
                Content = "踩"
            });

            UpdateModel(wproject);
            db.SaveChanges();

            return View();//不会Ajax- - 此处应标识已踩 不刷新页面
        }

        public ActionResult CancelClickDownWriteProject(int id)//取消踩 创作
        {
            EntityDbContext db = new EntityDbContext();
            WriteProject wproject = db.WriteProject.Find(id);
            //找到相应条目

            wproject.UpCount--;

            WriteComment wcomment = db.WriteComment.Where(p => p.WriteProjectID.Equals(id) && p.UserID == int.Parse(User.Identity.Name) && p.ContentTypeNum == 2).FirstOrDefault();
            db.WriteComment.Remove(wcomment);

            UpdateModel(wproject);
            db.SaveChanges();
            return View();//不会Ajax- -此处应标识取消踩 不刷新页面
        }
    }
}
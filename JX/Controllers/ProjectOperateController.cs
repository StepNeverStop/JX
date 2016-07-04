﻿using System;
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
        //提交新的项目
        //projectname项目名称  writeType写作模式：单/多    projectState项目状态    projectintro简介 projecttypes文本类型集
        public ActionResult ApplyForNewProject(string projectName, string writeType, int projectState, string projectIntro,List<string> projectTypes)
        {
            EntityDbContext db = new EntityDbContext();

            if(db.Projects.Where(p=>p.ProjectName.Equals(projectName)).FirstOrDefault()==null)
            {
                db.Projects.Add(new Projects
                {
                    ProjectName = projectName,
                    WriteType = writeType,
                    ProjectState = 3,
                    ProjectIntro = projectIntro,
                    UserID = int.Parse(User.Identity.Name),
                    //ProjectTypes=new List<ProjectTypes>
                    //{
                        //这里有一个把传进来的所有类型 一个个加入的问题 没有想到合适的方法  在这里写Foreach并不可写
                    //}
                });
                db.SaveChanges();
                return View();//显示申请成功，待审核的页面
            }

            return View();//显示申请失败，请重新填写的页面
        }
    }
}
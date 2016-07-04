using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JX.App_Start;
using JX.Models;
using System.Web.Security;

namespace JX.Controllers
{
    public class AccountController : Controller
    {
        
        [HttpPost]
        public ActionResult Register(string user,string pwd1,string pwd2)
        {
            EntityDbContext db = new EntityDbContext();
            if (pwd1.Equals(pwd2) && db.Users.Where(p => p.Username.Equals(user)).FirstOrDefault() == null)
            {
                string pwdmd5 = MD5Encipherment.MD5E(pwd1);
                db.Users.Add(new Users
                {
                    Username = user,
                    MD5Password = pwdmd5,
                    UserRole = 2,
                    Nickname = "New One!"
                });
                db.SaveChanges();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(string user,string pwd)
        {
            EntityDbContext db = new EntityDbContext();
            Users sb = db.Users.Where(p => p.Username.Equals(user)).FirstOrDefault();
            if(sb==null || !sb.MD5Password.Equals(MD5Encipherment.MD5E(pwd)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string userData = sb.Roles.ToString();
                // 将用户Id作为票据的Name
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, sb.Username, DateTime.Now,
                    DateTime.Now.AddDays(7),
                    true, userData);
                string authTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);

                cookie.Expires = ticket.Expiration;


                Response.SetCookie(cookie);
                return RedirectToAction("HomePage","Home");

            }

        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        //修改昵称
        public ActionResult ChangeNickname(string newNickname)
        {
            EntityDbContext db = new EntityDbContext();
            Users MyAccount = db.Users.Where(p => p.Username.Equals(User.Identity.Name.ToString())).FirstOrDefault();
            MyAccount.Nickname = newNickname;
            UpdateModel(MyAccount);
            db.SaveChanges();
            return View();//到修改昵称成功的页面
        }

        //修改密码
        public ActionResult ChangePassword(string oldPwd,string newPwd1, string newPwd2)
        {
            EntityDbContext db = new EntityDbContext();
            Users MyAccount = db.Users.Where(p => p.Username.Equals(User.Identity.Name.ToString())).FirstOrDefault();
            if(MD5Encipherment.MD5E(oldPwd).Equals(MyAccount.MD5Password))
            {
                //原密码验证成功
                
                if(newPwd1.Equals(newPwd2))
                {
                    //确认密码一致

                    MyAccount.MD5Password = MD5Encipherment.MD5E(newPwd1);
                    UpdateModel(MyAccount);
                    db.SaveChanges();
                    return View();//到修改密码成功的页面  并提示重新登录或下次登录请使用新密码
                }
                else
                {
                    return View();//到修改页面  提示新密码不一致
                }
            }
            else
            {
                return View();//到修改页面   提示原密码验证失败
            }
        }

        //关注其他用户
        public ActionResult AttendOtherUser(int otherUserId)
        {
            EntityDbContext db = new EntityDbContext();
            Users MyAccount = db.Users.Where(p => p.Username.Equals(User.Identity.Name.ToString())).FirstOrDefault();
            db.UserAttentions.Add(new UserAttentions
            {
                UserID = MyAccount.ID,
                BeAttentedUserID = otherUserId
            });
            MyAccount.AttentionCount++;
            UpdateModel(MyAccount);
            db.SaveChanges();

            return View();//返回关注成功的页面 
        } 

        //取消关注
        public ActionResult CancelAttend(int otherUserId)
        {

            EntityDbContext db = new EntityDbContext();
            Users MyAccount = db.Users.Where(p => p.Username.Equals(User.Identity.Name.ToString())).FirstOrDefault();
            UserAttentions uas = db.UserAttentions.Find(MyAccount.ID, otherUserId);
            db.UserAttentions.Remove(uas);
            MyAccount.AttentionCount--;
            UpdateModel(MyAccount);
            db.SaveChanges();

            return View();//返回取消关注成功的页面
        }

        public int ShowAttendCount()//获取关注的数量
        {
            EntityDbContext db = new EntityDbContext();
            return db.UserAttentions.Where(p => p.UserID == int.Parse(User.Identity.Name)).ToList().Count;
        }

        public int ShowFansCount()//获取粉丝的数量
        {

            EntityDbContext db = new EntityDbContext();
            return db.UserAttentions.Where(p => p.BeAttentedUserID == int.Parse(User.Identity.Name)).ToList().Count;
        }

        public ActionResult ShowAttendList()//显示关注页面
        {
            EntityDbContext db = new EntityDbContext();
            List<UserAttentions> uas= db.UserAttentions.Where(p => p.UserID == int.Parse(User.Identity.Name)).ToList();
            List<string> users = new List<string>();
            foreach(var item in uas)
            {
                users.Add(db.Users.Find(item.BeAttentedUserID).Nickname);
            }

            ViewBag.attendcount = uas.Count;
            ViewBag.attendlist = users;

            return View();//显示关注页面


        }

        public ActionResult ShowFansList()//显示粉丝页面
        {

            EntityDbContext db = new EntityDbContext();
            List<UserAttentions> uas = db.UserAttentions.Where(p => p.BeAttentedUserID == int.Parse(User.Identity.Name)).ToList();
            List<string> users = new List<string>();
            foreach (var item in uas)
            {
                users.Add(db.Users.Find(item.UserID).Nickname);
            }
            ViewBag.fanscount = uas.Count;
            ViewBag.fanslist = users;

            return View();//显示粉丝页面
        }
    }
}
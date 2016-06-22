using EasyEngineer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace EasyEngineer.Controllers
{
    public class NewsController : Controller
    {

        [Authorize]
        public ActionResult Index(News news, string username)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                news.Author = Author();
                news.Date_pub = DateTime.Now;
                db.Newss.Add(news);
                db.SaveChanges();

                return RedirectToAction("ListUserNews");
            }
            return View();
        }

        public ViewResult Show()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var news = db.Newss.OrderBy(e => e.Date_pub);
            return View(news);
        }
        [Authorize]
        public ViewResult ListUserNews(string username)
        {
            var CurrentUser = Author();
            ApplicationDbContext db = new ApplicationDbContext();
            var news = db.Newss.Where(e => e.Author == CurrentUser).OrderBy(e=>e.Date_pub);
            return View(news);
        }

        public ActionResult Delete(int ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            News news = db.Newss.Find(ID);
            db.Newss.Remove(news);
            db.SaveChanges();
            return RedirectToAction("ListUserNews");
        }
        public ViewResult CurrentShow(int ID)
        {
            
            ApplicationDbContext db = new ApplicationDbContext();
            News news = db.Newss.FirstOrDefault(x => x.Id == ID);
            db.Newss.Include(x => x.NewsCommentss);
            return View(news);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            News news = db.Newss.FirstOrDefault(x => x.Id == ID);
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(News news,string username)
        {
            if (ModelState.IsValid)
            {
                news.Date_pub =  DateTime.Now;
                news.Author = Author();  
                ApplicationDbContext db = new ApplicationDbContext();
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListUserNews");
            }
            return View(news);
        }

        public string Author()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            string username = user.UserName;

            return(username);

        }

        public ActionResult Like(int ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            News news = db.Newss.Find(ID);
            news.Likes += 1;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("CurrentShow",news);
        }

        public ActionResult Dislike(int ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            News news = db.Newss.Find(ID);
            news.Likes -= 1;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("CurrentShow", news);
        }

        public ActionResult AddComment(NewsComments comment,int ID,string username)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (ModelState.IsValid)
            {
                comment.NewsId = ID;
                comment.Author = Author();
                comment.DatePub = DateTime.Now;
                db.NewsCommentss.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Show");
            }
            return View();
        }

	}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.DataAccess;
using Blog.Models;

namespace Blog.Controllers
{
    public class CommentsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Comments
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                var comments = db.Comments.Include(c => c.ArticleID == id.Value).Include(c => c.User);
                return View(comments.ToList().OrderByDescending(c => c.Date));

            }

            else
            {
                var comments = db.Comments.Include(c => c.Article).Include(c => c.User);
                return View(comments.ToList());
            }
        }


        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create(int? id)
        {

            ViewBag.ArticleID = id;
            return PartialView("_AddComment");
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,Content,Date,UserID,ArticleID")] Comment comment, int? id)
        {
          if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            //Définit l'auteur du commentaire
            string name = User.Identity.Name;
            var auteur = db.Users.FirstOrDefault(c => c.Pseudo == name);
            var auteurID = auteur.UserID;
            comment.UserID = auteurID;

            //Définit la date de publication du commentaire
            comment.Date = DateTime.Now;


            //Définit l'article du commentaire
            comment.ArticleID = id.Value;

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "Articles", new { id  = comment.ArticleID } );
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", comment.ArticleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Pseudo", comment.UserID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", comment.ArticleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Pseudo", comment.UserID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Content,Date,UserID,ArticleID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ArticleID", "Title", comment.ArticleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Pseudo", comment.UserID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

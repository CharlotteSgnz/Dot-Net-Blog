using Blog.DataAccess;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private  readonly BlogContext _dbContext = new BlogContext();

        //GET: Home/Index    --> Home/
        public ActionResult Index()
        {
            var articles = _dbContext.Articles.OrderByDescending(a => a.Date);
            return View(articles.ToList());
        }

        //GET: Home/Archives   (Sert uniquement à faciliter le développement, à supprimer avant la mise en production)
        public ActionResult Database()
        {
            ViewBag.Message = "Liste des tables de la BDD (Uniquement 'Users' 'Articles' et 'Comments' sont disponibles actuellement)";

            return View();
        }

        //GET: Home/Archives
        public ActionResult Archives()
        {
            ViewBag.Message = "Liste des archives à venir";

            return View();
        }

        //GET: Home/Poster
        public ActionResult Poster()
        {
            ViewBag.Message = "Vous pourrez bientôt écrire vos posts ici :)";

            return View();
        }

        //GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //GET: Comments/ValidateComments
        public ActionResult ValidateComments()
        {
            var comments = _dbContext.Comments.Where(c => c.Validated == false);
            return View(comments.ToList());
        }

        //Affiche le bouton "Poster" si l'utilisateur a le role nécessaire ('Admin' ou 'Blogueur')
        public ActionResult ValidateButton()
        {
            if (User.Identity.IsAuthenticated)
            {
                string name = User.Identity.Name;
                string role = _dbContext.Users.SingleOrDefault(u => u.Pseudo == name).User_Role.ToString();
                ViewData["Role"] = role;
            }
            else
            {
                ViewData["Role"] = "Visiteur";
            }

            return PartialView("_ValidateCommentsButton");
        }



        //GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Home/Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            
                bool IsValidUser = _dbContext.Users
               .Any(u => u.Pseudo.ToLower() == user
               .Pseudo.ToLower() && user
               .Password == user.Password);

            if (IsValidUser)
                {
                Role role = _dbContext.Users.Single(u => u.Pseudo.ToLower() == user
               .Pseudo.ToLower() && user
               .Password == user.Password).User_Role;
                if (role == Role.Banni)
                {
                    return View("lockout");
                }

                FormsAuthentication.SetAuthCookie(user.Pseudo, false);

                return RedirectToAction("Index", "Home");
                }
            
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        // GET: Home/register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User registerUser)
        {
            registerUser.User_Role = Role.Visiteur;

            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(registerUser);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");

            }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    
    }
}
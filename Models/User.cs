using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{

    public enum Role
    {
        Admin, Blogueur, Visiteur
    }

    public class User
    {
        public int UserID { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
      //  public int? Photo { get; set; }
        public Role User_Role { get; set; }

    //    public virtual ICollection<Article> Articles { get; set; }
      //  public virtual ICollection<Comment> Comments { get; set; }


    }
}
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
        Admin, Blogueur, Inscrit, Visiteur, Banni
    }

    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Entrez un pseudo ")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "Entrez un password")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse Email n'est pas valide")]
        [Required(ErrorMessage = "Entrez un adresse mail")]
        public string Email { get; set; }
      //  public int? Photo { get; set; }
        public Role User_Role { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


    }
}
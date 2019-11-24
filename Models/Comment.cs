using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Content { get; set; }


        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int ArticleID { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
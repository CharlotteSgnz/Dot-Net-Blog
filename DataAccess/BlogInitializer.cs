using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Blog.DataAccess
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            var users = new List<User>
            {
            new User{UserID=2,Pseudo="Patrick l'étoile de mer",Password="poissons",Email="patrick@gmail.com",User_Role=Role.Blogueur},
            new User{UserID=1,Pseudo="Bob l'éponge",Password="poissons",Email="bob@gmail.com",User_Role=Role.Admin},
            new User{UserID=3,Pseudo="Carlos Tentacule",Password="poissons",Email="carlos@gmail.com",User_Role=Role.Visiteur},
            new User{UserID=4,Pseudo="Capitaine Crabe",Password="poissons",Email="capitaine@gmail.com",User_Role=Role.Visiteur}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var articles = new List<Article>
           {
            new Article{Title="La plongée c'est génial",Content="Novitates autem si spem adferunt, ut tamquam in herbis non fallacibus fructus appareat, non sunt illae quidem repudiandae, vetustas tamen suo loco conservanda; maxima est enim vis vetustatis et consuetudinis. Quin in ipso equo, cuius modo feci mentionem, si nulla res impediat, nemo est, quin eo, quo consuevit, libentius utatur quam intractato et novo. Nec vero in hoc quod est animal, sed in iis etiam quae sunt inanima, consuetudo valet, cum locis ipsis delectemur, montuosis etiam et silvestribus, in quibus diutius commorati sumus.",Date=DateTime.Parse("01/06/2013"),UserID=1},
            new Article{Title="Les îles paradisiaques",Content="Quam ob rem id primum videamus, si placet, quatenus amor in amicitia progredi debeat. Numne, si Coriolanus habuit amicos, ferre contra patriam arma illi cum Coriolano debuerunt? num Vecellinum amici regnum adpetentem, num Maelium debuerunt iuvare?",Date=DateTime.Parse("01/06/2012"),UserID=2},
            new Article{Title="Les plus beaux poissons",Content="Ego vero sic intellego, Patres conscripti, nos hoc tempore in provinciis decernendis perpetuae pacis habere oportere rationem. Nam quis hoc non sentit omnia alia esse nobis vacua ab omni periculo atque etiam suspicione belli?",Date=DateTime.Parse("01/06/2014"),UserID=3},
            new Article{Title="Les plus gros poissons",Content="Et prima post Osdroenam quam, ut dictum est, ab hac descriptione discrevimus, Commagena, nunc Euphratensis, clementer adsurgit, Hierapoli, vetere Nino et Samosata civitatibus amplis inlustris.",Date=DateTime.Parse("01/06/2018"),UserID=4}
            };

            articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();

            var comments = new List<Comment>
            {
            new Comment{Content="Mais quel super Article !!", Date=DateTime.Parse("01/06/2013"),UserID=2,ArticleID=1},
            new Comment{Content="Très intéressant", Date=DateTime.Parse("01/06/2013"),UserID=1,ArticleID=3},
            new Comment{Content="Cet article est vraiment nul", Date=DateTime.Parse("01/06/2013"),UserID=4,ArticleID=1},
            new Comment{Content="Merci j'ai adoré, et personnellement j'ai adoré les Maldives !", Date=DateTime.Parse("01/06/2013"),UserID=4,ArticleID=2},
            new Comment{Content="Mouais peut faire mieux...", Date=DateTime.Parse("01/06/2013"),UserID=3,ArticleID=4},
            new Comment{Content="J'aime pas les poissons...", Date=DateTime.Parse("01/06/2013"),UserID=2,ArticleID=1}
            };

            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

           
       
        }
    }
}
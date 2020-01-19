using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Blog.DataAccess
{
    //Changer en "DropCreateDatabaseAlways<BlogContext>" pour ne pas garder les modifications de la BDD
    public class BlogInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            var users = new List<User>
            {
            new User{UserID=1,Pseudo="admin",Password="admin",Email="admin@admin.com",User_Role=Role.Admin},
            new User{UserID=2,Pseudo="Patrick l'étoile de mer",Password="poissons",Email="patrick@gmail.com",User_Role=Role.Blogueur},
            new User{UserID=3,Pseudo="Bob l'éponge",Password="poissons",Email="bob@gmail.com",User_Role=Role.Blogueur},
            new User{UserID=4,Pseudo="Carlos Tentacule",Password="poissons",Email="carlos@gmail.com",User_Role=Role.Inscrit},
            new User{UserID=5,Pseudo="Capitaine Crabe",Password="poissons",Email="capitaine@gmail.com",User_Role=Role.Inscrit}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var articles = new List<Article>
           {
            new Article{Title="La plongée c'est génial", Cover="https://images.unsplash.com/photo-1503177847378-d2048487fa46?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=967&q=80", Resume="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras felis neque, mollis a dui at, auctor elementum nisl. Fusce nec dui ac metus tempor volutpat id non lorem. Etiam nec dui nec libero hendrerit efficitur. Morbi tempor augue eget mi pretium, non ultrices sem dignissim. Vestibulum a faucibus nisl, vel auctor nunc. Nunc mi nisi, placerat a accumsan sit amet, sagittis a lacus. Proin dictum magna at nibh viverra bibendum.", Content="Novitates autem si spem adferunt, ut tamquam in herbis non fallacibus fructus appareat, non sunt illae quidem repudiandae, vetustas tamen suo loco conservanda; maxima est enim vis vetustatis et consuetudinis. Quin in ipso equo, cuius modo feci mentionem, si nulla res impediat, nemo est, quin eo, quo consuevit, libentius utatur quam intractato et novo. Nec vero in hoc quod est animal, sed in iis etiam quae sunt inanima, consuetudo valet, cum locis ipsis delectemur, montuosis etiam et silvestribus, in quibus diutius commorati sumus. ",Date=DateTime.Parse("01/06/2013"),UserID=5},
            new Article{Title="Les îles paradisiaques", Cover="https://images.unsplash.com/photo-1527681192512-bca34fd580bb?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1051&q=80", Resume="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras felis neque, mollis a dui at, auctor elementum nisl. Fusce nec dui ac metus tempor volutpat id non lorem. Etiam nec dui nec libero hendrerit efficitur. Morbi tempor augue eget mi pretium, non ultrices sem dignissim. Vestibulum a faucibus nisl, vel auctor nunc. Nunc mi nisi, placerat a accumsan sit amet, sagittis a lacus. Proin dictum magna at nibh viverra bibendum.", Content="Quam ob rem id primum videamus, si placet, quatenus amor in amicitia progredi debeat. Numne, si Coriolanus habuit amicos, ferre contra patriam arma illi cum Coriolano debuerunt? num Vecellinum amici regnum adpetentem, num Maelium debuerunt iuvare?",Date=DateTime.Parse("01/06/2012"),UserID=2},
            new Article{Title="Les plus beaux poissons", Cover="https://images.unsplash.com/photo-1550016728-6e898923de4c?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1043&q=80", Resume="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras felis neque, mollis a dui at, auctor elementum nisl. Fusce nec dui ac metus tempor volutpat id non lorem. Etiam nec dui nec libero hendrerit efficitur. Morbi tempor augue eget mi pretium, non ultrices sem dignissim. Vestibulum a faucibus nisl, vel auctor nunc. Nunc mi nisi, placerat a accumsan sit amet, sagittis a lacus. Proin dictum magna at nibh viverra bibendum.", Content="Ego vero sic intellego, Patres conscripti, nos hoc tempore in provinciis decernendis perpetuae pacis habere oportere rationem. Nam quis hoc non sentit omnia alia esse nobis vacua ab omni periculo atque etiam suspicione belli?",Date=DateTime.Parse("01/06/2014"),UserID=3},
            new Article{Title="Les plus gros poissons", Cover="https://images.unsplash.com/photo-1502998732392-615e9b445fa4?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80", Resume="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras felis neque, mollis a dui at, auctor elementum nisl. Fusce nec dui ac metus tempor volutpat id non lorem. Etiam nec dui nec libero hendrerit efficitur. Morbi tempor augue eget mi pretium, non ultrices sem dignissim. Vestibulum a faucibus nisl, vel auctor nunc. Nunc mi nisi, placerat a accumsan sit amet, sagittis a lacus. Proin dictum magna at nibh viverra bibendum.", Content="Et prima post Osdroenam quam, ut dictum est, ab hac descriptione discrevimus, Commagena, nunc Euphratensis, clementer adsurgit, Hierapoli, vetere Nino et Samosata civitatibus amplis inlustris.",Date=DateTime.Parse("01/06/2018"),UserID=4}
            };

            articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();

            var comments = new List<Comment>
            {
            new Comment{Content="Mais quel super Article !!", Date=DateTime.Parse("01/06/2013"),UserID=2,ArticleID=1,Validated=true},
            new Comment{Content="Très intéressant", Date=DateTime.Parse("01/06/2013"),UserID=1,ArticleID=3,Validated=true},
            new Comment{Content="Cet article est vraiment nul", Date=DateTime.Parse("01/06/2013"),UserID=4,ArticleID=1,Validated=true},
            new Comment{Content="Merci j'ai adoré !", Date=DateTime.Parse("01/06/2013"),UserID=4,ArticleID=2,Validated=false},
            new Comment{Content="Mouais peut faire mieux...", Date=DateTime.Parse("01/06/2013"),UserID=3,ArticleID=4,Validated=false},
            new Comment{Content="J'aime pas les poissons...", Date=DateTime.Parse("01/06/2013"),UserID=2,ArticleID=1,Validated=false}
            };

            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

           
       
        }
    }
}
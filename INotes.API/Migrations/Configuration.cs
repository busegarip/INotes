namespace INotes.API.Migrations
{
    using INotes.API.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<INotes.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(INotes.API.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())//hiç kullanýcý yoksa bunu yapar
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = "buse@gmail.com",
                    Email = "buse@gmail.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, "Ankara1.");

                //user.Notes = new HashSet<Note>(); // baþka bir yöntem aþaðýda context demek user yerine ve yazar idlerini eklemek

                context.Notes.Add(new Note
                {
                    AuthorId=user.Id,
                    Title = "Sample Note 1",
                    Content = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit am et justo nunc tempor, metus vel.",
                    CreatedTime = DateTime.Now
                });
                context.Notes.Add(new Note
                {
                    AuthorId = user.Id,
                    Title = "Sample Note 2",
                    Content = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit am et justo nunc tempor, metus vel.",
                    CreatedTime = DateTime.Now.AddMinutes(10)
                });
                //context.Entry(user).State = EntityState.Modified;//userýn entity tarafýndan takip edilmesini saðlar
            }
        }
    }
}


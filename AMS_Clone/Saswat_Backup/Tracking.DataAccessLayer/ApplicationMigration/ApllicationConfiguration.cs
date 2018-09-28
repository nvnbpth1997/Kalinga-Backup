namespace Tracking.DataAccessLayer.ApplicationMigration
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tracking.DataAccessLayer.DbContext;

    internal sealed class ApllicationConfiguration : DbMigrationsConfiguration<Tracking.DataAccessLayer.DbContext.ApplicationDbContext>
    {
        public ApllicationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ApplicationMigration";
        }

        protected override void Seed(Tracking.DataAccessLayer.DbContext.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "PF"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "PF" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "CIS"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "CIS" };

                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "M654321", Email = "Saswat.Panda2@mindtree.com", };
                user.FirstName = "Nick";
                user.LastName = "Cerillo";
                user.IsLogged = 0;
                manager.Create(user, "M654321");
                manager.AddToRole(user.Id, "PF");
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == "co-founder"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "M123456", Email = "23ted1995@gmail.com", };
                user.FirstName = "Rittik";
                user.LastName = "Basu";
                user.IsLogged = 0;
                manager.Create(user, "M123456");
                manager.AddToRole(user.Id, "CIS");
                context.SaveChanges();
            }
        }
    }
}

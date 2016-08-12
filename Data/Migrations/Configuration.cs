using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private bool AddUserAndRole(Data.Models.ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            IdentityResult ir = rm.Create(new IdentityRole("Administrator"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                Email = "rangamo@gmail.com",
                UserName = "rangamo@gmail.com",
            };
            ir = um.Create(user, "Password@123");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "Administrator");
            return ir.Succeeded;
        }

        protected override void Seed(Data.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
        }

    }
}

using fbLudoWebFinal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fbLudoWebFinal.Startup))]
namespace fbLudoWebFinal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Mitglied"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Mitglied";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);             

                var user = new ApplicationUser();
                user.Anrede = "Herr";
                user.Vorname = "admin";
                user.Nachname = "fbWebLudo";
                user.UserName = "admin@fbWebLudo.com";
                user.Email = "admin@fbWebLudo.com";
                user.PLZ = 9444;
                user.Ort = "Diepoldsau";
                user.Adresse = "Kamorstrasse 10a";
                user.FirstLogin = false;
                string userPWD = "Test1234!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                    var result2 = UserManager.AddToRole(user.Id, "Mitglied");

                }
            }

            if (!roleManager.RoleExists("Kunde"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Kunde";
                roleManager.Create(role);            

                var user = new ApplicationUser();
                user.Anrede = "Herr";
                user.Vorname = "admin";
                user.Nachname = "fbWebLudo";
                user.UserName = "kunde@fbWebLudo.com";
                user.Email = "kunde@fbWebLudo.com";
                user.PLZ = 9444;
                user.Ort = "Diepoldsau";
                user.Adresse = "Kamorstrasse 10a";
                user.FirstLogin = false;
                string userPWD = "Test1234!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Kunde");

                }

            }

            if (!roleManager.RoleExists("Mitarbeiter"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Mitarbeiter";
                roleManager.Create(role);                 

                var user = new ApplicationUser();
                user.Anrede = "Herr";
                user.Vorname = "admin";
                user.Nachname = "fbWebLudo";
                user.UserName = "mitarbeiter@fbWebLudo.com";
                user.Email = "mitarbeiter@fbWebLudo.com";
                user.PLZ = 9444;
                user.Ort = "Diepoldsau";
                user.Adresse = "Kamorstrasse 10a";
                user.FirstLogin = false;
                string userPWD = "Test1234!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Mitarbeiter");
                    var result2 = UserManager.AddToRole(user.Id, "Mitglied");

                }

            }

        }
    }
}

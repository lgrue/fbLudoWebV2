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


        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

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

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Kunde"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Kunde";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

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

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Kunde");

                }

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Mitarbeiter"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Mitarbeiter";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

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

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Mitarbeiter");

                }

            }
        }
    }
}

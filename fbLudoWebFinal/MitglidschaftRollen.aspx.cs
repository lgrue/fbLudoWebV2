using fbLudoWebFinal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fbLudoWebFinal
{
    public partial class MitglidschaftRollen : System.Web.UI.Page
    {
        private Model.fbLudoDBEntities3 _context;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ReedemCode(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _context = new fbLudoDBEntities3();
            Code code;

            code = _context.Code.FirstOrDefault(x => x.Code1 == Code.Text && x.Aktiv == true);

            if (code == null)
            {
                FailureText.Text = "Ungültiger Code";
                ErrorMessage.Visible = true;
            }
            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = manager.FindById(User.Identity.GetUserId());
                var result = UserManager.AddToRole(currentUser.Id, "Mitglied");
                code.Aktiv = false;
                _context.Entry(code).State = EntityState.Modified;
                _context.SaveChanges();
                SuccessText.Text = "Sie sind nun Mitglied!";
                SuccessMessage.Visible = true;
                Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Response.Redirect("Account/Login.aspx?mode=logout");
            }
        }

        protected void MitarbeiterPw(object sender, EventArgs e)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _context = new fbLudoDBEntities3();
            Code code;

            code = _context.Code.FirstOrDefault(x => x.Code1 == Password1.Text && x.Aktiv == true);

            if (code == null)
            {
                FailureText1.Text = "Ungültiger Code";
                ErrorMessage1.Visible = true;
            }
            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = manager.FindById(User.Identity.GetUserId());
                var result = UserManager.AddToRole(currentUser.Id, "Mitarbeiter");
                var result2 = UserManager.AddToRole(currentUser.Id, "Mitglied");
                SuccessText1.Text = "Sie sind nun Mitarbeiter!";
                SuccessMessage1.Visible = true;
                Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Response.Redirect("Account/Login.aspx?mode=logout");
            }
        }

        protected void AdminPw(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _context = new fbLudoDBEntities3();
            Code code;

            code = _context.Code.FirstOrDefault(x => x.Code1 == Password2.Text && x.Aktiv == true);

            if (code == null)
            {
                FailureText2.Text = "Ungültiger Code";
                ErrorMessage2.Visible = true;
            }
            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = manager.FindById(User.Identity.GetUserId());
                var result = UserManager.AddToRole(currentUser.Id, "Admin");
                var result2 = UserManager.AddToRole(currentUser.Id, "Mitglied");
                Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Response.Redirect("Account/Login.aspx?mode=logout");
            }
        }
    }
}
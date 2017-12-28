using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using fbLudoWebFinal.Models;

namespace fbLudoWebFinal.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }
        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUser = manager.FindById(User.Identity.GetUserId());

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));
            Anrede.Text = currentUser.Anrede;
            Vorname.Text = currentUser.Vorname;
            Nachname.Text = currentUser.Nachname;
            PLZ.Text = currentUser.PLZ.ToString();
            Ort.Text = currentUser.Ort;
            Adresse.Text = currentUser.Adresse;

            // Option nach dem Einrichten der zweistufigen Authentifizierung aktivieren
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Zu rendernde Abschnitte ermitteln
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Rendererfolgsmeldung
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Abfragezeichenfolge aus der Aktion entfernen
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Ihr Kennwort wurde geändert."
                        : message == "SetPwdSuccess" ? "Ihr Kennwort wurde festgelegt."
                        : message == "RemoveLoginSuccess" ? "Das Konto wurde entfernt."
                        : message == "AddPhoneNumberSuccess" ? "Die Telefonnummer wurde hinzugefügt."
                        : message == "RemovePhoneNumberSuccess" ? "Die Telefonnummer wurde entfernt."
                        : message == "SaveDataSuccess" ? "Die persönlichen Daten wurden erfolgreich gespeichert."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Telefonnummer für Benutzer entfernen
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }

        protected void SaveData_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUser = manager.FindById(User.Identity.GetUserId());
            currentUser.Anrede = Anrede.Text;
            currentUser.Vorname = Vorname.Text;
            currentUser.Nachname = Nachname.Text;
            currentUser.PLZ = Convert.ToInt32(PLZ.Text);
            currentUser.Ort = Ort.Text;
            currentUser.Adresse = "HURENSOHN";

            Response.Redirect("/Account/Manage?m=SaveDataSuccess");
        }
    }
}
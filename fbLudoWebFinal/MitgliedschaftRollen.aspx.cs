using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fbLudoWebFinal
{
    public partial class MitgliedschaftRollen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RedeemCode(object sender, EventArgs e)
        {
            if (IsValid)
            {


                // Benutzerkennwort überprüfen
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Anmeldefehler werden bezüglich einer Kontosperre nicht gezählt.
                // Wenn Sie aktivieren möchten, dass Kennwortfehler eine Sperre auslösen, ändern Sie in "shouldLockout: true".
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        Response.Redirect("/AusleihenÜbersicht");
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Ungültiger Anmeldeversuch.";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fbLudoWebFinal
{
    public partial class PreiseAnpassen : Page
    {
        private Model.fbLudoDBEntities3 _context;

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (currentUser != null)
            {
                if (currentUser.FirstLogin == false)
                {
                    Response.Redirect("/Account/Manage?m=AddData");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        var userId = User.Identity.GetUserId();
                        _context = new fbLudoDBEntities3();
                        IEnumerable<Spiel> list = _context.Spiel.Where(x => x.Ausgeliehen == false).ToList();

                        RadioButtonList.DataSource = list;
                        RadioButtonList.DataTextField = "Name";
                        RadioButtonList.DataValueField = "Spiel_ID";
                        RadioButtonList.AutoPostBack = false;
                        RadioButtonList.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        public void Choose(Object sender, EventArgs e)
        {
            var userid = Context.User.Identity.GetUserId();
            var spielid = int.Parse(RadioButtonList.SelectedValue);
            var spiel = _context.Spiel.FirstOrDefault(x => x.Spiel_ID == spielid);


            //newVereinstarif.Value = spiel.Vereinstarif;
            //newNormaltarif.Value = spiel.Normaltarif;
        }

        public void Change(Object sender, EventArgs e)
        {

        }
    }
}
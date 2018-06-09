using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model;

namespace fbLudoWebFinal
{
    public partial class AusleihenÜbersicht : Page
    {

        private Model.fbLudoDBEntities _context;

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
                    LoadData(User.Identity.GetUserId());
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        public void longer(Object sender, EventArgs e)
        {
            var id = (sender as LinkButton).CommandArgument;
            var idInt = int.Parse(id);
            _context = new fbLudoDBEntities();
            var ausleihe = _context.Ausleihe.FirstOrDefault(x => x.Ausleihe_ID == idInt);
            if (ausleihe.AnzVerlaengerungen <= 2)
            {
                System.TimeSpan duration = new System.TimeSpan(7, 0, 0, 0);
                DateTime newDeadline = Convert.ToDateTime(ausleihe.DatumBis);
                newDeadline = newDeadline.Add(duration);
                ausleihe.DatumBis = newDeadline;
                ausleihe.AnzVerlaengerungen = ausleihe.AnzVerlaengerungen + 1;
                _context.Entry(ausleihe).State = EntityState.Modified;
                _context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
            
        }

        public void back(Object sender, EventArgs e)
        {
            var id = (sender as LinkButton).CommandArgument;
            var idInt = int.Parse(id);
            _context = new fbLudoDBEntities();
            var ausleihe = _context.Ausleihe.FirstOrDefault(x => x.Ausleihe_ID == idInt);
            var spiel = _context.Spiel.FirstOrDefault(x => x.Spiel_ID == ausleihe.Spiel_ID);
            spiel.Ausgeliehen = false;
            DateTime newDeadline = DateTime.Now;
            ausleihe.DatumBis = newDeadline;
            _context.Entry(ausleihe).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(spiel).State = EntityState.Modified;
            _context.SaveChanges();
            Response.Redirect(Request.RawUrl);

            Response.Redirect(Request.RawUrl);
        }

        private void LoadData(string userId)
        {
            DateTime now = DateTime.Now;
            _context = new fbLudoDBEntities();
            //get all ausleihe ids
            var listAusleiheID = _context.Ausleihe.Where(x => x.PersonenID == userId).ToList();
            
            foreach (Ausleihe ausleiheid in listAusleiheID) {
                var id = ausleiheid.Ausleihe_ID;
                IEnumerable<Ausleihe_Spiel> list = _context.Ausleihe_Spiel.Where(x => x.Ausleihe_ID == id && x.DatumBis > now).ToList();
            }
            EmployeesListView.DataSource = list;
            EmployeesListView.DataBind();

            IEnumerable<Ausleihe> list2 = _context.Ausleihe.Where(x => x.PersonenID == userId && x.DatumBis <= now).ToList();
            ListView2.DataSource = list2;
            ListView2.DataBind();
        }
    }
}
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
                    /*
                    string[] titles = new string[] { "Spiel", "Ausgelehnt am", "Zurückbringen bis", "Verlängerungen", "Verlängern", "Zurückbringen" };
                    var hrow = new TableHeaderRow();
                    foreach (string title in titles)
                    {
                        var cell = new TableHeaderCell();
                        cell.Text = title;
                        hrow.Cells.Add(cell);
                    }
                    tblAusleihenAktiv.Rows.Add(hrow);
                    titles = new string[] { "Spiel", "Ausgelehnt am", "Zurückgebracht", "Verlängerungen" };
                    hrow = new TableHeaderRow();
                    foreach (string title in titles)
                    {
                        var cell = new TableHeaderCell();
                        cell.Text = title;
                        hrow.Cells.Add(cell);
                    }
                    tblAusleihenIaktiv.Rows.Add(hrow);
                    var dataFile = Server.MapPath("~/App_Data/ausleihen.txt");
                    string[] lines = File.ReadAllLines(dataFile);
                    if (lines.Count() > 0)
                    {
                        foreach (string line in lines)
                        {
                            if (line != "")
                            {
                                var cols = line.Split(';');
                                if (cols[1] == User.Identity.GetUserId())
                                {
                                    if (Convert.ToDateTime(cols[5]) > DateTime.Now)
                                    {
                                        var row = new TableRow();
                                        for (int cIndex = 0; cIndex < 9; cIndex++)
                                        {
                                            if (cIndex != 0 && cIndex != 1 && cIndex != 2)
                                            {
                                                var cell = new TableCell();
                                                if (cIndex < 4)
                                                {
                                                    cell.Text = cols[cIndex];
                                                }
                                                else if (cIndex == 4 || cIndex == 5)
                                                {
                                                    cell.Text = Convert.ToDateTime(cols[cIndex]).ToString("dd/MM/yyyy");
                                                }
                                                else if (cIndex == 6)
                                                {
                                                    cell.Text = cols[cIndex] + "/3";
                                                }
                                                else if (cIndex == 7)
                                                {
                                                    LinkButton button = new LinkButton();
                                                    button.Text = "Verlängern";
                                                    button.ID = "v" + cols[0];
                                                    button.Click += new System.EventHandler(this.longer);
                                                    if (cols[6] == "3")
                                                    {
                                                        button.Enabled = false;
                                                        button.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
                                                        button.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
                                                    }
                                                    cell.Controls.Add(button);
                                                }
                                                else if (cIndex == 8)
                                                {
                                                    LinkButton button = new LinkButton();
                                                    button.Text = "Zurückgeben";
                                                    button.ID = "z" + cols[0];
                                                    button.Click += new System.EventHandler(this.back);
                                                    cell.Controls.Add(button);
                                                }
                                                row.Cells.Add(cell);
                                            }
                                        }

                                        tblAusleihenAktiv.Rows.Add(row);
                                    }
                                    else
                                    {
                                        var row = new TableRow();
                                        for (int cIndex = 0; cIndex < 7; cIndex++)
                                        {
                                            if (cIndex != 0 && cIndex != 1 && cIndex != 2)
                                            {
                                                var cell = new TableCell();
                                                if (cIndex < 4)
                                                {
                                                    cell.Text = cols[cIndex];
                                                }
                                                else if (cIndex == 4 || cIndex == 5)
                                                {
                                                    cell.Text = Convert.ToDateTime(cols[cIndex]).ToString("dd/MM/yyyy");
                                                }
                                                else if (cIndex == 6)
                                                {
                                                    cell.Text = cols[cIndex] + "/3";
                                                }
                                                row.Cells.Add(cell);
                                            }
                                        }

                                        tblAusleihenIaktiv.Rows.Add(row);
                                    }
                                }
                            }
                        }
                    }*/
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
            IEnumerable<Ausleihe> list = _context.Ausleihe.Where(x => x.PersonenID == userId && x.DatumBis > now).ToList();
            EmployeesListView.DataSource = list;
            EmployeesListView.DataBind();

            IEnumerable<Ausleihe> list2 = _context.Ausleihe.Where(x => x.PersonenID == userId && x.DatumBis <= now).ToList();
            ListView2.DataSource = list2;
            ListView2.DataBind();
        }
    }
}
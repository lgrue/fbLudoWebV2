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
    public partial class NeueAusleihe : Page
    {
        private Model.fbLudoDBEntities _context;

        protected string SuccessMessage
        {
            get;
            private set;
        }

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
                        _context = new fbLudoDBEntities();
                        IEnumerable<Spiel> list = _context.Spiel.Where(x => x.Ausgeliehen == false).ToList();

                        DropDownList1.DataSource = list;
                        DropDownList1.DataTextField = "Name";
                        DropDownList1.DataValueField = "Spiel_ID";
                        DropDownList1.AutoPostBack = false;
                        DropDownList1.DataBind();

                        var message = Request.QueryString["m"];
                        if (message != null)
                        {
                            // Abfragezeichenfolge aus der Aktion entfernen
                            Form.Action = ResolveUrl("~/Account/Manage");

                            SuccessMessage =
                                message == "SaveDataSuccess" ? "Die persönlichen Daten wurden erfolgreich gespeichert."
                                : String.Empty;
                            successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        public void ausleihen(Object sender, EventArgs e)
        {
            var userid = Context.User.Identity.GetUserId();
            DateTime currentTime = DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(7,0,0,0);
            DateTime deadline = currentTime.Add(duration);
            var counter = 0;
            var spielid = int.Parse(DropDownList1.SelectedValue);
            Ausleihe ausleihe = new Ausleihe()
            {
                PersonenID = userid
            };
            Ausleihe_Spiel ausleihe_spiel = new Ausleihe_Spiel()
            {
                Ausleihe_ID = ausleihe.Ausleihe_ID,
                Spiel_ID = spielid,
                DatumVon = currentTime,
                DatumBis = deadline,
                AnzVerlaengerungen = counter
            };
            _context = new fbLudoDBEntities();
            _context.Ausleihe.Add(ausleihe);
            _context.SaveChanges();

            

            var spiel = _context.Spiel.FirstOrDefault(x => x.Spiel_ID == spielid);
            spiel.Ausgeliehen = true;
            _context.Entry(spiel).State = EntityState.Modified;
            _context.SaveChanges();
            Response.Redirect("/AusleihenÜbersicht");
        }

        /*public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();

            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));

            var dataFile = Server.MapPath(filePath);
            string[] lines = File.ReadAllLines(dataFile);

            foreach (string line in lines)
            {
                var cols = line.Split(';');
                if (cols[2] == "1")
                {
                    DataRow dr = tbl.NewRow();
                    for (int cIndex = 0; cIndex < numberOfColumns; cIndex++)
                    {
                        dr[cIndex] = cols[cIndex];
                    }

                    tbl.Rows.Add(dr);
                }
            }

            return tbl;
        }*/
    }
}
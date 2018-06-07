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
                        
                        /*DataTable dataTable = ConvertToDataTable("~/App_Data/spiele.txt", 2);
                        DropDownList1.DataSource = dataTable;
                        DropDownList1.DataTextField = "Column2";
                        DropDownList1.DataValueField = "Column1";
                        DropDownList1.AutoPostBack = false;
                        DropDownList1.DataBind();*/

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
            /*var dataFile = Server.MapPath("~/App_Data/ausleihen.txt");
            string[] lines = File.ReadAllLines(dataFile);
            var id = lines.Count();*/

            var userid = Context.User.Identity.GetUserId();
            DateTime currentTime = DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(7,0,0,0);
            DateTime deadline = currentTime.Add(duration);
            var counter = 0;
            var spielid = int.Parse(DropDownList1.SelectedValue);
            Ausleihe ausleihe = new Ausleihe()
            {
                PersonenID = userid,
                Spiel_ID = spielid,
                Name = Convert.ToString(DropDownList1.SelectedItem),
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

            /*var txt = id.ToString() + ";" + userid + ";" + DropDownList1.SelectedValue + ";" + DropDownList1.SelectedItem + ";" + currentTime + ";" + deadline + ";" + counter ;
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/App_Data/ausleihen.txt"), true))
            {
                _testData.WriteLine(txt); // Write the file.
            }
            dataFile = Server.MapPath("~/App_Data/spiele.txt");
            lines = File.ReadAllLines(dataFile);
            File.WriteAllText(dataFile, String.Empty);
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/App_Data/spiele.txt"), true))
            {
                foreach (string line in lines)
                {
                    var cols = line.Split(';');
                    if (cols[0] == DropDownList1.SelectedValue) {
                        cols[2] = "0";
                        var newline = cols[0] + ";" + cols[1] + ";" + cols[2];
                        _testData.WriteLine(newline); // Write the file.var cols = line.Split(':');
                    }
                    else
                    {
                        _testData.WriteLine(line); // Write the file.var cols = line.Split(':');
                    }
                }
                
            }*/
            Response.Redirect("/AusleihenÜbersicht");
        }

        public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
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
        }
    }
}
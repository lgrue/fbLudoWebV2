using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fbLudoWebFinal
{
    public partial class NeueAusleihe : Page
    {
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
                        DataTable dataTable = ConvertToDataTable("~/App_Data/spiele.txt", 2);
                        DropDownList1.DataSource = dataTable;
                        DropDownList1.DataTextField = "Column2";
                        DropDownList1.DataValueField = "Column1";
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
            var id = 1;
            var name = Context.User.Identity.GetUserName();
            var txt = id.ToString() + ":" + name + ":" + DropDownList1.SelectedValue + ":" + DropDownList1.SelectedItem;
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/App_Data/ausleihen.txt"), true))
            {
                _testData.WriteLine(txt); // Write the file.
            }
            Server.Transfer("AusleihenÜbersicht.aspx", true);
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
                var cols = line.Split(':');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < numberOfColumns; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }
    }
}
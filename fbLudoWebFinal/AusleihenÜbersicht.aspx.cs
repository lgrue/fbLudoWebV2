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
    public partial class AusleihenÜbersicht : Page
    {
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
                    var dataFile = Server.MapPath("~/App_Data/ausleihen.txt");
                    string[] lines = File.ReadAllLines(dataFile);
                    foreach (string line in lines)
                    {
                        var cols = line.Split(':');

                        var row = new TableRow();
                        for (int cIndex = 0; cIndex < 7; cIndex++)
                        {
                            var cell = new TableCell();
                            if (cIndex < 4)
                            {
                                cell.Text = cols[cIndex];
                            }
                            else if (cIndex == 5)
                            {
                                LinkButton button = new LinkButton();
                                button.Text = "Verlängern";
                                button.ID = "v" + cols[2];
                                button.Click += new System.EventHandler(this.verlängern);
                                cell.Controls.Add(button);
                            }
                            else if (cIndex == 6)
                            {
                                LinkButton button = new LinkButton();
                                button.Text = "Zurückgeben";
                                button.ID = "z" + cols[2];
                                button.Click += new System.EventHandler(this.back);
                                cell.Controls.Add(button);
                            }
                            row.Cells.Add(cell);
                        }

                        tblAusleihenAktiv.Rows.Add(row);
                    }
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        private void verlängern(Object sender, EventArgs e)
        {
            
        }

        private void back(Object sender, EventArgs e)
        {
            var id = (sender as LinkButton).ID;
            var dataFile = Server.MapPath("~/App_Data/spiele.txt");
            string[] lines = File.ReadAllLines(dataFile);
            File.WriteAllText(dataFile, String.Empty);
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/App_Data/spiele.txt"), true))
            {
                foreach (string line in lines)
                {
                    var cols = line.Split(':');
                    if ("z" + cols[0] == id)
                    {
                        cols[2] = "1";
                        var newline = cols[0] + ":" + cols[1] + ":" + cols[2];
                        _testData.WriteLine(newline); // Write the file.var cols = line.Split(':');
                    }
                    else
                    {
                        _testData.WriteLine(line); // Write the file.var cols = line.Split(':');
                    }
                }

            }
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
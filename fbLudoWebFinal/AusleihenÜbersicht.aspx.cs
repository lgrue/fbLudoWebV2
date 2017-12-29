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
            if (!Page.IsPostBack)
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
                        }else if(cIndex == 5){
                            Button button = new Button();
                            button.Text = "Verlängern";
                            /*button.Click += verlängern();*/
                            cell.Controls.Add(button);
                        }
                        else if(cIndex == 6){
                            Button button = new Button();
                            button.Text = "Zurückgeben";
                            /*button.Click += new RoutedEventHandler(zurückbringen);*/
                            cell.Controls.Add(button);
                        }
                        row.Cells.Add(cell);
                    }

                    tblAusleihenAktiv.Rows.Add(row);
                }
            }
        }

        private void verlängern(Object sender, EventArgs e)
        {
            
        }

        private void zurückbringen(Object sender, EventArgs ee)
        {
            
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
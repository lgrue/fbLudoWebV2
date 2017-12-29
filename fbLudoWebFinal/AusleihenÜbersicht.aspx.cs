﻿using Microsoft.AspNet.Identity;
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
                    if (!Page.IsPostBack)
                    {
                        DataTable dataTable = ConvertToDataTable("~/App_Data/ausleihen.txt", 4);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("/");
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
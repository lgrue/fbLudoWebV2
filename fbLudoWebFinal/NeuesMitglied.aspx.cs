using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace fbLudoWebFinal
{
    public partial class NeuesMitglied : System.Web.UI.Page
    {
        private Model.fbLudoDBEntities3 _context;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateCode(object sender, EventArgs e)
        {
            Code code = new Code()
            {
                Code1 = Membership.GeneratePassword(10, 2),
                Aktiv = true
            };
            _context = new fbLudoDBEntities3();
            _context.Code.Add(code);
            _context.SaveChanges();
            SuccessText.Text = code.Code1;
            SuccessMessage.Visible = true;
        }
    }
}
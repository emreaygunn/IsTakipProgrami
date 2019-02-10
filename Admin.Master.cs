using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsTakipProgramı
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKullaniciAdi.Text = Session["KullaniciAdi"].ToString();

            if(Session["KullaniciYetki"].ToString() == "2")
            {
                pnlMenü.Visible = false;
            }
        }
    }
}
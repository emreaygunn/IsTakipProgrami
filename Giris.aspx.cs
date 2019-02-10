using IsTakipProgramı.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsTakipProgramı
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            DataTable dt = Kodlar.KullaniciGiris(txtKullaniciAdi.Text, txtSifre.Text);
            if (dt.Rows.Count > 0)
            {
                Session["KullaniciAdi"] = dt.Rows[0]["KullaniciAdi"].ToString();
                Session["KullaniciYetki"] = dt.Rows[0]["KullaniciYetki"].ToString();
                Session["KullaniciID"] = dt.Rows[0]["KullaniciID"].ToString();
                Response.Redirect("AnaSayfa.aspx");
            }
            else
            {
                lblDurum.Text = "Yanlış bilgi girişi yaptınız, tekrar deneyin";
            }
        }
    }
}
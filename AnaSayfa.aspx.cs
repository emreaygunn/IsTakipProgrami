using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsTakipProgramı
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uyeID = Session["KullaniciID"].ToString();

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\TakipProg.accdb;Persist Security Info = False;");
            baglanti.Open();
            OleDbCommand kullanici = new OleDbCommand("Select COUNT(*) as kullanici_sayi From tblKullanicilar", baglanti);
            OleDbCommand cagri = new OleDbCommand("Select COUNT(*) as cagri_sayi From tblCagrilar", baglanti);
            OleDbCommand departman = new OleDbCommand("Select COUNT(*) as departman_sayi From tblDepartmanlar", baglanti);
            kullanici.ExecuteNonQuery();
            cagri.ExecuteNonQuery();
            departman.ExecuteNonQuery();
            lblUyeSayi.Text = kullanici.ExecuteScalar().ToString();
            lblCagriSayi.Text = cagri.ExecuteScalar().ToString();
            lblDepartmanSayi.Text = departman.ExecuteScalar().ToString();
            baglanti.Close();
        }
    }
}
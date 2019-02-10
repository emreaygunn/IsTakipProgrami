using IsTakipProgramı.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsTakipProgramı
{
    public partial class CagriOlustur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKullaniciAdi.Text = Session["KullaniciAdi"].ToString();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            var kullaniciID = Session["KullaniciID"].ToString();
            int durum = Kodlar.CagriEkle(kullaniciID, txtBaslik.Text, txtAciklama.InnerText);
            if (durum > 0)
            {
                lblDurum.Text = "Kayıt Eklenmiştir";
                Response.AppendHeader("Refresh", "1;url=AnaSayfa.aspx");
            }
            else
            {
                lblDurum.Text = "Kayıt sırasında hata oluştu";
            }
        }
    }
}

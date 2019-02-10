using IsTakipProgramı.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IsTakipProgramı
{
    public partial class Departmanlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlKullaniciYetki.Visible = true;
            lblKullaniciYetki.Visible = false;

            if (Request.QueryString["listele"] != null)
            {
                pnlDepartmanEkle.Visible = false;
            }
            else if (!IsPostBack)
            {
                if (Session["KullaniciYetki"].ToString() != "0")
                {
                    lblKullaniciYetki.Visible = true;
                    pnlKullaniciYetki.Visible = false;
                }
                else
                {
                    if (Request.QueryString["s"] != null)
                    {
                        Kodlar.DepartmanSil(Request.QueryString["s"]);
                        Response.Redirect("Departmanlar.aspx?listele=1");
                    }
                    else if (Request.QueryString["id"] != null)
                    {
                        DataTable dt = Kodlar.DepartmanCek(Request.QueryString["id"]);
                        if (dt.Rows.Count > 0)
                        {
                            txtDepartman.Text = dt.Rows[0]["DepartmanAdi"].ToString();
                            txtAciklama.Text = dt.Rows[0]["Aciklama"].ToString();
                        }
                    }
                }
            }
            Listele();
        }

        void Listele()
        {
            rptDepartmanlar.DataSource = Kodlar.Departmanlar();
            rptDepartmanlar.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            //int durum = 0;

            if (Request.QueryString["id"] != null)
            {
                int durum = Kodlar.DepartmanDuzelt(txtDepartman.Text, txtAciklama.Text, Request.QueryString["id"]);
                if (durum > 0)
                {
                    lblDurum.Text = "Düzeltme Yapılmıştır";
                    Response.AppendHeader("Refresh", "1;url=Departmanlar.aspx?listele=1");
                }
                else
                {
                    lblDurum.Text = "Düzeltme sırasında hata oluştu";
                }
            }
            else
            {
                int durum = Kodlar.DepartmanEkle(txtDepartman.Text, txtAciklama.Text);
                if (durum > 0)
                {
                    lblDurum.Text = "Kayıt Eklenmiştir";
                    Response.AppendHeader("Refresh", "1;url=Departmanlar.aspx?listele=1");
                }
                else
                {
                    lblDurum.Text = "Kayıt sırasında hata oluştu";
                }
            }
            Listele();
        }

        public static string DurumKontrol(string durum)
        {
            if (durum == "0")
            {
                return "label label-important";
            }
            else
            {
                return "label label-success";
            }
        }

        public static string AktifKontrol(string durum, string type)// type = 1 buton, type = 2 icon
        {
            if (type == "1")
            {

                if (durum != "0")
                {
                    return "btn btn-danger";
                }
                else
                {
                    return "btn btn-success";
                }
            }
            else
            {
                if (durum != "0")
                {
                    return "icon-trash";
                }
                else
                {
                    return "icon-repeat";
                }
            }
        }
    }
}
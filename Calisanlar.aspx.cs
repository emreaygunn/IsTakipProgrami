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
    public partial class Calisanlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlKullaniciYetki.Visible = true;
            lblKullaniciYetki.Visible = false;
            

            if (Request.QueryString["listele"] != null)
            {
                pnlKullaniciEkle.Visible = false;
            }
            else if (!IsPostBack)
            {
                DepartmanDoldur();
                YetkiDoldur();

                if (Session["KullaniciYetki"].ToString() != "0")
                {
                    lblKullaniciYetki.Visible = true;
                    pnlKullaniciYetki.Visible = false;
                }
                else
                {
                    if (Request.QueryString["s"] != null)
                    {
                        Kodlar.CalisanSil(Request.QueryString["s"]);
                        Response.Redirect("Calisanlar.aspx?listele=1");
                    }
                    else if (Request.QueryString["id"] != null)
                    {
                        DataTable dt = Kodlar.CalisanCek(Request.QueryString["id"]);
                        if (dt.Rows.Count > 0)
                        {
                            txtKullaniciAdi.Text = dt.Rows[0]["KullaniciAdi"].ToString();
                            txtTelefon.Text = dt.Rows[0]["Telefon"].ToString();
                            txtEPosta.Text = dt.Rows[0]["EPosta"].ToString();
                            txtSifre.Text = dt.Rows[0]["Sifre"].ToString();
                            ddlDepartman.SelectedValue = dt.Rows[0]["DepartmanID"].ToString();
                            ddlYetki.SelectedValue = dt.Rows[0]["KullaniciYetki"].ToString();
                            lblEskiGorsel.Text = dt.Rows[0]["Gorsel"].ToString();
                        }
                    }
                }
            }
            Listele();
        }

        void DepartmanDoldur()
        {
            ddlDepartman.DataSource = Kodlar.Departmanlar();
            ddlDepartman.DataValueField = "DepartmanID";
            ddlDepartman.DataTextField = "DepartmanAdi";
            ddlDepartman.DataBind();
        }

        void YetkiDoldur()
        {
            ddlYetki.DataSource = Kodlar.Yetkiler();
            ddlYetki.DataValueField = "YetkiID";
            ddlYetki.DataTextField = "YetkiAdi";
            ddlYetki.DataBind();
        }

        void Listele()
        {
            rptCalisanlar.DataSource = Kodlar.Calisanlar();
            rptCalisanlar.DataBind();
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

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int durum = Kodlar.CalisanDuzelt(txtKullaniciAdi.Text, txtTelefon.Text, txtEPosta.Text, txtSifre.Text, ddlDepartman.SelectedValue, ddlYetki.SelectedValue, fuResim, lblEskiGorsel.Text, Request.QueryString["id"]);
                if (durum > 0)
                {
                    lblDurum.Text = "Kayıt Düzeltilmiştir";
                    Response.AppendHeader("Refresh", "1;url=Calisanlar.aspx?listele=1");
                }
                else
                {
                    lblDurum.Text = "Düzeltme sırasında hata oluştu";
                }
            }
            else
            {
                int durum = Kodlar.CalisanEkle(txtKullaniciAdi.Text, txtTelefon.Text, txtEPosta.Text, txtSifre.Text, ddlDepartman.SelectedValue, ddlYetki.SelectedValue, fuResim);
                if (durum > 0)
                {
                    lblDurum.Text = "Kayıt Eklenmiştir";
                    Response.AppendHeader("Refresh", "1;url=Calisanlar.aspx?listele=1");
                }
                else
                {
                    lblDurum.Text = "Kayıt sırasında hata oluştu";
                }
            }
            Listele();
        }       
    }
}
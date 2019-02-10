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
    public partial class Cagrilarim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlKullaniciYetki.Visible = true;
            lblKullaniciYetki.Visible = false;

            if (Request.QueryString["listele"] != null)
            {
                pnlCagrilarim.Visible = false;
            }
            else if (!IsPostBack)
            {
                UstlenenKisiDoldur();
                AsamaDoldur();

                if (Session["KullaniciYetki"].ToString() == "2")
                {
                    lblKullaniciYetki.Visible = true;
                    pnlKullaniciYetki.Visible = false;
                }
                else
                {
                    if (Request.QueryString["s"] != null)
                    {
                        Kodlar.CagriSil(Request.QueryString["s"]);
                        Response.Redirect("Cagrilarim.aspx?listele=1");
                    }
                    else if (Request.QueryString["id"] != null)
                    {
                        DataTable dt = Kodlar.CagriCek(Request.QueryString["id"]);
                        if (dt.Rows.Count > 0)
                        {
                            lblCagriNumara.Text = dt.Rows[0]["CagriID"].ToString();
                            lblBaslik.Text = dt.Rows[0]["Baslik"].ToString();
                            txtAciklama.InnerText = dt.Rows[0]["Aciklama"].ToString();
                            txtMetin.InnerText = dt.Rows[0]["Islemler"].ToString();
                            ddlUstlenenKisi.SelectedValue = dt.Rows[0]["UstlenenKisi"].ToString();
                            ddlAsama.SelectedValue = dt.Rows[0]["Durumu"].ToString();
                            lblKullaniciAdi.Text = dt.Rows[0]["KullaniciAdi"].ToString();
                        }
                    }
                }
            }
            Listele();
        }

        void UstlenenKisiDoldur()
        {
            ddlUstlenenKisi.DataSource = Kodlar.Calisanlar();
            ddlUstlenenKisi.DataValueField = "KullaniciID";
            ddlUstlenenKisi.DataTextField = "KullaniciAdi";
            ddlUstlenenKisi.DataBind();
        }

        void AsamaDoldur()
        {
            ddlAsama.DataSource = Kodlar.Asama();
            ddlAsama.DataValueField = "CagriSurecID";
            ddlAsama.DataTextField = "Ad";
            ddlAsama.DataBind();
        }

        void Listele()
        {
            rptCagrilar.DataSource = Kodlar.CagriListele(Session["KullaniciID"].ToString());
            rptCagrilar.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            //int durum = 0;

            if (Request.QueryString["id"] != null)
            {
                int durum = Kodlar.CagriDuzelt(ddlUstlenenKisi.SelectedValue, ddlAsama.SelectedValue, txtMetin.InnerText, Request.QueryString["id"]);
                if (durum > 0)
                {
                    lblDurum.Text = "Düzeltme Yapılmıştır";
                    Response.AppendHeader("Refresh", "1;url=Cagrilarim.aspx?listele=1");
                }
                else
                {
                    lblDurum.Text = "Düzeltme sırasında hata oluştu";
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
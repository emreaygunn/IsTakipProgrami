using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IsTakipProgramı.App_Code
{
    public class Kodlar
    {
        #region Kullanıcı İşlemleri

        public static DataTable KullaniciGiris(string eposta, string sifre)
        {
            string kod = "Select * From tblKullanicilar Where EPosta=@eposta and Sifre=@sifre";
            string[] veri = { eposta, sifre };
            string[] parametre = { "@eposta", "@sifre" };
            return VT.ExecuteReader(kod, veri, parametre);
        }

        public static DataTable KullaniciCek(string kullaniciID)
        {
            string kod = "Select * From tblKullanicilar Where KullaniciID=" + kullaniciID;
            return VT.ExecuteReader(kod);
        }

        #endregion

        #region Calisanlar

        public static int CalisanEkle(string kullaniciAdi, string telefon, string eposta, string sifre, string departmanID, string kullaniciYetki, FileUpload fuGorsel)
        {
            string yol = "";
            if (fuGorsel.HasFile)
            {
                yol = Araclar.ResimYukle(fuGorsel.PostedFile, 0, 0, HttpContext.Current.Server.MapPath("~/Uploads/Calisanlar/"), "", Guid.NewGuid().ToString());
            }
            string kod = "Insert Into tblKullanicilar (KullaniciAdi, Telefon, EPosta, Sifre, DepartmanID, KullaniciYetki, Gorsel) Values (@kullaniciAdi, @telefon, @eposta, @sifre, @departmanID, @kullaniciYetki, @fuGorsel)";
            string[] veri = { kullaniciAdi, telefon, eposta, sifre, departmanID, kullaniciYetki, yol };
            string[] parametre = { "@kullaniciAdi", "@telefon", "@eposta", "@sifre", "@departmanID", "@kullaniciYetki", "@fuGorsel" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static int CalisanDuzelt(string kullaniciAdi, string telefon, string eposta, string sifre, string departmanID, string kullaniciYetki, FileUpload fuGorsel, string eskiGorsel, string kullaniciID)
        {
            if (fuGorsel.HasFile)
            {
                eskiGorsel = Araclar.ResimYukle(fuGorsel.PostedFile, 0, 0, HttpContext.Current.Server.MapPath("~/Uploads/Calisanlar/"), "", Guid.NewGuid().ToString());
            }
            string kod = "Update tblKullanicilar Set KullaniciAdi=@kullaniciAdi, Telefon=@telefon, EPosta=@eposta, Sifre=@sifre, DepartmanID=@departmanID, KullaniciYetki=@kullaniciYetki, Gorsel=@fuGorsel Where KullaniciID=@kullaniciID";
            string[] veri = { kullaniciAdi, telefon, eposta, sifre, departmanID, kullaniciYetki, eskiGorsel, kullaniciID };
            string[] parametre = { "@adiSoyadi", "@telefon", "@eposta", "@sifre", "@departmanID", "@kullaniciYetki", "@fuGorsel", "@kullaniciID" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static DataTable CalisanCek(string kullaniciID)
        {
            string kod = "Select * From tblKullanicilar Where KullaniciID=@kullaniciID";
            string[] veri = { kullaniciID };
            string[] parametre = { "@kullaniciID" };
            return VT.ExecuteReader(kod, veri, parametre);
        }

        public static DataTable Calisanlar()
        {
            string kod = @"SELECT tblKullanicilar.*, tblDepartmanlar.DepartmanAdi FROM tblKullanicilar INNER JOIN tblDepartmanlar ON tblKullanicilar.DepartmanID = tblDepartmanlar.DepartmanID";
            return VT.ExecuteReader(kod);
        }

        public static int CalisanSil(string kullaniciID)
        {
            string durum = VT.ExecuteScalar("Select Aktif From tblKullanicilar Where KullaniciID=" + kullaniciID).ToString();
            if (durum == "1")
            {
                durum = "0";
            }
            else
            {
                durum = "1";
            }
            string kod = "Update tblKullanicilar Set Aktif=" + durum + " Where KullaniciID=" + kullaniciID;
            return VT.ExecuteNonQuery(kod);
        }

        public static DataTable Yetkiler()
        {
            return VT.ExecuteReader("Select * From tblYetki");
        }

        public static DataTable Asama()
        {
            return VT.ExecuteReader("Select * From tblCagriSurec");
        }
        #endregion

        #region Departmanlar

        public static int DepartmanEkle(string departmanAdi, string aciklama)
        {
            string kod = "Insert Into tblDepartmanlar (DepartmanAdi, Aciklama) Values (@departmanAdi, @aciklama)";
            string[] veri = { departmanAdi, aciklama };
            string[] parametre = { "@departmanAdi", "@aciklama" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static int DepartmanDuzelt(string departmanAdi, string aciklama, string departmanID)
        {
            string kod = "Update tblDepartmanlar Set DepartmanAdi=@departmanAdi, Aciklama=@aciklama Where DepartmanID=@departmanID";
            string[] veri = { departmanAdi, aciklama, departmanID };
            string[] parametre = { "@departmanAdi", "@aciklama", "@departmanID" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static DataTable Departmanlar()
        {
            return VT.ExecuteReader("Select * From tblDepartmanlar");
        }

        public static DataTable DepartmanCek(string departmanID)
        {
            string kod = "Select * From tblDepartmanlar Where DepartmanID=@departmanID";
            string[] veri = { departmanID };
            string[] parametre = { "@departmanID" };
            return VT.ExecuteReader(kod, veri, parametre);
        }

        public static int DepartmanSil(string departmanID)
        {
            string durum = VT.ExecuteScalar("Select Aktif From tblDepartmanlar Where DepartmanID=" + departmanID).ToString();
            if (durum == "1")
            {
                durum = "0";
            }
            else
            {
                durum = "1";
            }
            string kod = "Update tblDepartmanlar Set Aktif=" + durum + " Where DepartmanID=" + departmanID;
            return VT.ExecuteNonQuery(kod);
        }

        #endregion

        #region Cagrilar

        public static int CagriEkle(string acanKisi, string baslik, string aciklama)
        {
            string kod = "Insert Into tblCagrilar (AcanKisi, Baslik, Aciklama) Values (@acanKisi, @baslik, @aciklama)";
            string[] veri = { acanKisi, baslik, aciklama };
            string[] parametre = { "@acanKisi", "@baslik", "@aciklama" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static int CagriDuzelt(string ustlenenKisi, string asama, string islemler, string cagriID)
        {
            string kod = "Update tblCagrilar Set UstlenenKisi=@ustlenenKisi, Durumu=@asama, Islemler=@islemler Where CagriID=@cagriID";
            string[] veri = { ustlenenKisi, asama, islemler, cagriID };
            string[] parametre = { "@ustlenenKisi", "@asama", "@islemler", "@cagriID" };
            return VT.ExecuteNonQuery(kod, veri, parametre);
        }

        public static DataTable Cagrilar()
        {
            return VT.ExecuteReader(@"SELECT tblCagrilar.*, tblKullanicilar.KullaniciAdi, tblCagriSurec.Ad
FROM (tblCagrilar INNER JOIN tblKullanicilar ON tblCagrilar.AcanKisi = tblKullanicilar.KullaniciID) INNER JOIN tblCagriSurec ON tblCagrilar.Durumu = tblCagriSurec.CagriSurecID");
        }

        public static DataTable CagriListele(string calisanID)
        {
            string[] veri = { calisanID };
            string[] parametre = { "@calisanID" };
            return VT.ExecuteReader(@"SELECT tblCagrilar.*, tblKullanicilar.KullaniciAdi, tblCagriSurec.Ad From (tblCagrilar INNER JOIN tblKullanicilar ON tblCagrilar.AcanKisi = tblKullanicilar.KullaniciID) INNER JOIN tblCagriSurec ON tblCagrilar.Durumu = tblCagriSurec.CagriSurecID WHERE UstlenenKisi=@calisanID or UstlenenKisi=0", veri, parametre);
        }

        public static DataTable CagriListeleUye(string calisanID)
        {
            string[] veri = { calisanID };
            string[] parametre = { "@calisanID" };
            return VT.ExecuteReader(@"SELECT tblCagrilar.*, tblKullanicilar.KullaniciAdi, tblCagriSurec.Ad From (tblCagrilar INNER JOIN tblKullanicilar ON tblCagrilar.AcanKisi = tblKullanicilar.KullaniciID) INNER JOIN tblCagriSurec ON tblCagrilar.Durumu = tblCagriSurec.CagriSurecID WHERE AcanKisi=@calisanID", veri, parametre);
        }

        public static DataTable CagriCek(string cagriID)
        {
            string kod = @"SELECT tblCagrilar.*, tblKullanicilar.KullaniciAdi, tblCagriSurec.Ad
FROM (tblCagrilar INNER JOIN tblKullanicilar ON tblCagrilar.AcanKisi = tblKullanicilar.KullaniciID) INNER JOIN tblCagriSurec ON tblCagrilar.Durumu = tblCagriSurec.CagriSurecID Where CagriID=@cagriID";
            string[] veri = { cagriID };
            string[] parametre = { "@cagriID" };
            return VT.ExecuteReader(kod, veri, parametre);
        }

        public static int CagriSil(string cagriID)
        {
            string durum = VT.ExecuteScalar("Select Aktif From tblCagrilar Where CagriID=" + cagriID).ToString();
            if (durum == "1")
            {
                durum = "0";
            }
            else
            {
                durum = "1";
            }
            string kod = "Update tblCagrilar Set Aktif=" + durum + " Where CagriID=" + cagriID;
            return VT.ExecuteNonQuery(kod);

            #endregion
        }
    }
}
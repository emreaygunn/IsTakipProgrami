using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace IsTakipProgramı.App_Code
{
    public class VT
    {
        public static OleDbConnection Baglan()
        {
            OleDbConnection baglanti = new OleDbConnection();
            string baglantiYolu = ConfigurationManager.ConnectionStrings["TakipProg"].ConnectionString;
            baglanti.ConnectionString = baglantiYolu;
            return baglanti;
        }
        public static DataTable ExecuteReader(string sqlKod)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            OleDbDataAdapter da = new OleDbDataAdapter(kod);
            DataTable dt = new DataTable();
            da.Fill(dt);
            kod.Connection.Close();
            return dt;
        }
        public static DataTable ExecuteReader(string sqlKod, string[] veri, string[] parametre)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            for (int i = 0; i < veri.Length; i++)
            {
                kod.Parameters.AddWithValue(parametre[i], veri[i]);
            }
            OleDbDataAdapter da = new OleDbDataAdapter(kod);
            DataTable dt = new DataTable();
            da.Fill(dt);
            kod.Connection.Close();
            return dt;
        }
        public static int ExecuteNonQuery(string sqlKod)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            int durum = kod.ExecuteNonQuery();
            kod.Connection.Close();
            return durum;
        }
        public static int ExecuteNonQuery(string sqlKod, string[] veri, string[] parametre)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            for (int i = 0; i < veri.Length; i++)
            {
                kod.Parameters.AddWithValue(parametre[i], veri[i]);
            }
            int durum = kod.ExecuteNonQuery();
            kod.Connection.Close();
            return durum;
        }
        public static object ExecuteScalar(string sqlKod)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            object durum = kod.ExecuteScalar();
            kod.Connection.Close();
            return durum;
        }
        public static object ExecuteScalar(string sqlKod, string[] veri, string[] parametre)
        {
            OleDbCommand kod = new OleDbCommand();
            kod.Connection = Baglan();
            kod.Connection.Open();
            kod.CommandText = sqlKod;
            for (int i = 0; i < veri.Length; i++)
            {
                kod.Parameters.AddWithValue(parametre[i], veri[i]);
            }
            object durum = kod.ExecuteScalar();
            kod.Connection.Close();
            return durum;
        }
    }
}
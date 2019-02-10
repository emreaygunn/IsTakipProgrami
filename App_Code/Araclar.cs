using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace IsTakipProgramı.App_Code
{
    public class Araclar
    {
        #region Fotograf

        public static string ResimYukle(HttpPostedFile Dosya, int genislik, int yukseklik, string yol, string watermark, string guidID)
        {
            string durum = "yok.jpg";
            if (Dosya.ContentLength != 0)
            {
                Bitmap resim = new Bitmap(Dosya.InputStream);
                //resmin boyutu bizim vermiş olduğumuz genişlik veya yükseklikten büyükse boyutlandırma yapıyoruz.
                if (resim.Width > genislik || resim.Height > yukseklik)
                {
                    Size ebatlar = new Size(resim.Width, resim.Height);
                    //resmin genişlik ve yükseklik oranını alıyoruz.
                    double oran = ((double)resim.Width / (double)resim.Height);
                    if (resim.Width > genislik && genislik > 0)
                    {//burada genişlik parametresi 0 olarak verilmişse boyutlandırma yapılmayacak. Yani resim orijinal genişliğinde kalacak.
                        ebatlar.Width = genislik;
                        ebatlar.Height = (int)((double)genislik / oran);
                    }
                    if (ebatlar.Height > yukseklik && yukseklik > 0)
                    {//burada yükseklik parametresi 0 olarak verilmişse boyutlandırma yapılmayacak. Yani resim orijinal yükseklikte kalacak.
                        ebatlar.Height = yukseklik;
                        ebatlar.Width = (int)((double)yukseklik * oran);
                    }
                    resim = new Bitmap(resim, ebatlar);
                }

                //resmin üzerine yazı yazmak istemeyebiliriz o yüzden “watermark” parametresine boş string verebiliriz.
                if (!string.IsNullOrEmpty(watermark))
                {
                    Graphics graf = Graphics.FromImage(resim);
                    //resmin şeffaflık (alpha) değeri ve renk değerleri belirleniyor.
                    SolidBrush firca = new SolidBrush(Color.FromArgb(90, 0, 0, 0));

                    //resmin köşegen uzunluğu pisagor denklemiyle hesaplanıyor.
                    double kosegen = Math.Sqrt(resim.Width * resim.Width + resim.Height * resim.Height);
                    Rectangle kutu = new Rectangle();

                    //bu 3 satırda ise yazının başlama noktası (x,y koordinatları) ve ayrıca font boyutu ayarlanıyor.
                    //bunun için aşağıdaki gibi yaklaşık değerler kullandım 1,3..... 1,6.... gibi siz bu rakamlarla oynama yapabilirsiniz.
                    kutu.X = (int)(kosegen / 10);
                    float yazi = (float)(kosegen / watermark.Length * 1.3);
                    kutu.Y = -(int)(yazi / 1.6);

                    Font fnt = new Font("times new roman", yazi, FontStyle.Bold);//font tipi ve boyutu       
                    //can alıcı noktamız burası
                    //burada köşegen eğimini aşağıdaki formülle hesaplıyoruz.
                    float egim = (float)(Math.Atan2(resim.Height, resim.Width) * 180 / System.Math.PI);
                    graf.RotateTransform(egim);
                    StringFormat sf = new StringFormat();
                    // ve nihayet watermarkımızı resim üzerine yazdırıyoruz.
                    graf.DrawString(watermark, fnt, firca, kutu, sf);
                }
                string tamYol = yol + @"\" + guidID + "." + Dosya.FileName.Split('.')[1];
                resim.Save(tamYol);
                //dosyanın türüne göre de kayıt işlemini yaptırıyoruz.
                //if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
                //    resim.Save(yol, System.Drawing.Imaging.ImageFormat.Jpeg);
                //else if (Dosya.ContentType == "image/gif")
                //    resim.Save(yol, System.Drawing.Imaging.ImageFormat.Gif);
                //else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
                //    resim.Save(yol, System.Drawing.Imaging.ImageFormat.Png);
                resim.Dispose();
                durum = guidID + "." + Dosya.FileName.Split('.')[1];
            }
            return durum;
        }

        #endregion
    }
}
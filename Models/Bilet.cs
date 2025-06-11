namespace OtobusBiletRezervasyon.Models
{
   public class Bilet
 {
     public string YolcuAdSoyad { get; set; }
     public string KimlikNo { get; set; }
     public Sefer Sefer { get; set; }
     public int KoltukNo { get; set; }
     public DateTime SatinAlmaTarihi { get; set; }
     public Kullanici SatinAlanKullanici { get; set; } // Bileti alan kullanıcı (yolcu veya gişe görevlisi)

     // Constructor - SatinAlmaTarihi otomatik olarak atanıyor, parametre almıyor

     public Bilet(string adSoyad, string kimlikNo, Sefer sefer, int koltukNo)
     {
         YolcuAdSoyad = adSoyad;
         KimlikNo = kimlikNo;
         Sefer = sefer;
         KoltukNo = koltukNo;
         SatinAlmaTarihi = DateTime.Now;
     }

     // Constructor with user info
     public Bilet(string adSoyad, string kimlikNo, Sefer sefer, int koltukNo, Kullanici satinAlanKullanici)
         : this(adSoyad, kimlikNo, sefer, koltukNo)
     {
         SatinAlanKullanici = satinAlanKullanici;
     }

     // Bilet bilgilerini güzel formatta yazdıran metod
    public void BiletYazdir()
{
    string bilet = "------ BİLET ------\n";
    bilet += "Yolcu: " + YolcuAdSoyad + "\n";
    bilet += "Kimlik No: " + KimlikNo + "\n";
    bilet += "Sefer: " + Sefer.Nereden + " -> " + Sefer.Nereye + "\n";
    bilet += string.Format("Tarih: {0:dd.MM.yyyy}\n", Sefer.Tarih);
    bilet += "Koltuk: " + KoltukNo + "\n";
    bilet += string.Format("Alım Tarihi: {0:dd.MM.yyyy HH:mm:ss}\n", SatinAlmaTarihi);
    
    if (SatinAlanKullanici != null)
    {
        bilet += "Satışı Yapan: " + SatinAlanKullanici.KullaniciAdi + 
                 " (" + SatinAlanKullanici.Rol.RolAdi + ")\n";
    }

    bilet += "-------------------";

    Console.WriteLine(bilet);
}

 }
}

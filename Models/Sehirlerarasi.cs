namespace OtobusBiletRezervasyon.Models
{
    public class Sehirlerarasi : Sefer
  {
      public Sehirlerarasi(int no, DateTime tarih, string saat, Otobus otobus, string nereden, string nereye)
          : base(no, tarih, saat, otobus, nereden, nereye) { }
  }
}

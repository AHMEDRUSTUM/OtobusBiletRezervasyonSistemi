namespace OtobusBiletRezervasyon.Models
{
   public class Sehirici : Sefer
 {
     public Sehirici(int no, DateTime tarih, string saat, Otobus otobus, string nereden, string nereye)
         : base(no, tarih, saat, otobus, nereden, nereye) { }
 }
}

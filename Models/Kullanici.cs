namespace OtobusBiletRezervasyon.Models
{
     public class Kullanici
 {
     public int KullaniciId { get; set; }
     public string KullaniciAdi { get; set; }
     public string Sifre { get; set; }
     public Rol Rol { get; set; }

     public Kullanici(int kullaniciId, string kullaniciAdi, string sifre, Rol rol)
     {
         KullaniciId = kullaniciId;
         KullaniciAdi = kullaniciAdi;
         Sifre = sifre;
         Rol = rol;
     }
 }
}

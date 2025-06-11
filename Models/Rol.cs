namespace OtobusBiletRezervasyon.Models
{
       public class Rol
   {
       public int RolId { get; set; }
       public string RolAdi { get; set; } // "Yolcu", "GiseGorevlisi", "Admin" gibi

       public Rol(int rolId, string rolAdi)
       {
           RolId = rolId;
           RolAdi = rolAdi;
       }
   }
}

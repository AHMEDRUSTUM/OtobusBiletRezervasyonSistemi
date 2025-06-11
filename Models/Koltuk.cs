namespace OtobusBiletRezervasyon.Models
{
   public class Koltuk
 {
     public int KoltukNo { get; set; }
     public bool DoluMu { get; set; }

     public Koltuk(int no)
     {
         KoltukNo = no;
         DoluMu = false;
     }
 }
}

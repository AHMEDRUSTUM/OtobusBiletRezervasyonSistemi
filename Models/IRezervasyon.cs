namespace OtobusBiletRezervasyon.Models
{
  public interface IRezervasyon
{
    bool RezerveEt(Sefer sefer, int koltukNo, string yolcuAdSoyad, string KimlikNo);
    bool RezervasyonIptal(Sefer sefer, int koltukNo);

}
}

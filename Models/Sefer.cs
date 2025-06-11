namespace OtobusBiletRezervasyon.Models
{
  public abstract class Sefer
{
    public int SeferNo { get; set; }
    public DateTime Tarih { get; set; }
    public string Saat { get; set; }
    public Otobus Otobus { get; set; }
    public string Nereden { get; set; }
    public string Nereye { get; set; }

    public Sefer(int no, DateTime tarih, string saat, Otobus otobus, string nereden, string nereye)
    {
        SeferNo = no;
        Tarih = tarih;
        Saat = saat;
        Otobus = otobus;
        Nereden = nereden;
        Nereye = nereye;
    }
}
}

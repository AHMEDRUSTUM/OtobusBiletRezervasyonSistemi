namespace OtobusBiletRezervasyon.Models
{
    public class Otobus
{
    public string Plaka { get; set; }

    public Koltuk[] Koltuklar { get; private set; }



    // Otobüsün desteklediği maksimum koltuk sayısı (sabit)
    public const int MaksimumKoltukSayisi = 45;

    public Otobus(string plaka, int koltukSayisi)
    {
        if (koltukSayisi < 1 || koltukSayisi > MaksimumKoltukSayisi)
        {
            throw new ArgumentOutOfRangeException(nameof(koltukSayisi),
                $"Koltuk sayısı 1 ile {MaksimumKoltukSayisi} arasında olmalıdır.");
        }

        Plaka = plaka;
        Koltuklar = new Koltuk[koltukSayisi];

        for (int i = 0; i < koltukSayisi; i++)
        {
            Koltuklar[i] = new Koltuk(i + 1);
        }
    }
}
}

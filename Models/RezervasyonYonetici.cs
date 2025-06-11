namespace OtobusBiletRezervasyon.Models
{
    class RezervasyonYonetici : IRezervasyon
  {
      private List<Bilet> satislar = new List<Bilet>(); // Satılan biletlerin listesi

      public bool RezerveEt(Sefer sefer, int koltukNo, string yolcuAdSoya, string KimlikNo)
      {
          // Otobüsün koltuk dizisine eriş
          var koltuklar = sefer.Otobus.Koltuklar;

          // Koltuk numarasının geçerli olup olmadığını kontrol et
          if (koltukNo < 1 || koltukNo > koltuklar.Length)
          {
              Console.WriteLine("İşlem başarısız: Geçersiz koltuk numarası ya da tüm koltuklar rezerve edilmiş.");
              return false;
          }

          // Koltuk doluysa rezervasyon yapılamaz
          if (koltuklar[koltukNo - 1].DoluMu)
          {
              Console.WriteLine("Seçilen koltuk dolu.");
              return false;
          }

          // Koltuğu rezerve et (dolu olarak işaretle)

          koltuklar[koltukNo - 1].DoluMu = true;

          // Yeni bilet oluştur

          Bilet yeniBilet = new Bilet(yolcuAdSoya, KimlikNo, sefer, koltukNo);

          // Satış listesine ekle
          satislar.Add(yeniBilet);
          Console.WriteLine($"{yolcuAdSoya} için {koltukNo}. koltuk başarıyla rezerve edildi.");

          return true; // Rezervasyon başarılı
      }

      public bool RezervasyonIptal(Sefer sefer, int koltukNo)
      {
          var koltuklar = sefer.Otobus.Koltuklar;

          // Koltuk numarasının geçerliliğini kontrol et
          if (koltukNo < 1 || koltukNo > koltuklar.Length)
          {
              Console.WriteLine("Geçersiz koltuk numarası ");
              return false;
          }

          // Eğer koltuk zaten boşsa iptal edilemez
          if (!koltuklar[koltukNo - 1].DoluMu)
          {
              Console.WriteLine("Bu koltuk zaten boş.");
              return false;
          }

          // Koltuğu boş olarak işaretle
          koltuklar[koltukNo - 1].DoluMu = false;

          // Satışlar listesinden ilgili bileti bul ve kaldır
          Bilet bilet = satislar.FirstOrDefault(b => b.Sefer == sefer && b.KoltukNo == koltukNo);
          if (bilet != null)
          {
              satislar.Remove(bilet);
          }

          Console.WriteLine($"{koltukNo}. koltuk iptal edildi.");
          return true; // İptal başarılı
      }

      public void SatislariYazdir()
      {
          if (satislar.Count == 0)
          {
              Console.WriteLine("Henüz satılmış bilet yok.");
              return;
          }

          Console.WriteLine("----- Satılmış Biletler -----");
          foreach (var bilet in satislar)
          {
              bilet.BiletYazdir();
              Console.WriteLine("----------------------------");
          }



      }
  }
}

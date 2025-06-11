# Otobüs Bilet Rezervasyon Uygulaması

Bu proje, modern ve kullanıcı dostu bir arayüze sahip C# Windows Forms ile geliştirilmiş bir Otobüs Bilet Rezervasyon sistemidir. Uygulama, müşteri ve admin panelleriyle birlikte otobüs, koltuk, sefer ve bilet işlemlerini kapsamaktadır.

## Özellikler

- **Kullanıcı Girişi:** Güvenli login ekranı ile müşteri ve admin ayrımı
- **Müşteri Paneli:**
  - Otobüs ve sefer seçimi
  - Koltuk seçimi (görsel ve interaktif)
  - Bilet alma ve bilet iptal işlemleri
  - Satın alınan biletlerin görüntülenmesi
- **Admin Paneli:**
  - Otobüs ekleme ve silme
  - Sefer ekleme ve silme
  - Tüm biletleri listeleme ve iptal etme
  - Modern ve renkli yönetim arayüzü
- **Veritabanı Entegrasyonu:**
  - SQL Server ile bağlantı
  - Otobüs, koltuk, sefer ve bilet işlemleri doğrudan veritabanı üzerinden yönetilir
- **Model Sınıfları:**
  - `Otobus`, `Koltuk`, `Sefer`, `Bilet`, `Kullanici` vb. nesne yönelimli yapı

## Kurulum

1. **Gereksinimler:**
   - .NET 9.0 veya üzeri
   - SQL Server (örnek bağlantı: `DESKTOP-15EI2H8\SQLEXPRESS`)
2. **Veritabanı:**
   - `OtobusBileti2` isimli bir veritabanı oluşturun.
   - Gerekli tabloları ve örnek verileri ekleyin (Otobus, Koltuk, Sefer, Bilet, Kullanici, vb.)
3. **Projeyi Derleme:**
   - Proje klasöründe terminal açın:
     ```powershell
     dotnet build
     ```
   - Ardından uygulamayı başlatın:
     ```powershell
     dotnet run
     ```

## Kullanım

- Uygulama açıldığında login ekranı gelir.
- Giriş yaptıktan sonra kullanıcı rolüne göre ilgili panele yönlendirilirsiniz.
- Admin panelinden otobüs ve sefer yönetimi, müşteri panelinden bilet işlemleri yapılabilir.




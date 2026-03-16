# Console Skor Toplama Oyunu 

Bu proje, C# kullanılarak konsol ortamında geliştirilmiş temel bir skor toplama ve obje yakalama oyunudur.

##  Oyunun Amacı ve Özellikleri
Oyuncu (`@` sembolü) yön tuşlarıyla hareket ederek ekranın üst kısmından rastgele düşen objeleri (`*` ve `O`) yakalamaya çalışır. 

* **Puanlama:** Yakalanan her obje oyuncuya 5 puan kazandırır.
* **Kazanma/Kaybetme Durumu:** Oyun süresi 30 saniyedir. Süre dolduğunda veya hedef skora (50 puan) ulaşıldığında oyun biter.
* **Akıcı Ekran:** Konsol ekranındaki titremeleri önlemek için ekranı tamamen temizlemek (`Console.Clear`) yerine imleç konumlandırma (`Console.SetCursorPosition`) tekniği kullanılmıştır.

##  Nasıl Çalıştırılır?
1. Bu projeyi bilgisayarınıza indirin (ZIP olarak veya `git clone` komutu ile).
2. Proje klasöründeki `.sln` (Solution) dosyasına çift tıklayarak **Visual Studio** üzerinde açın.
3. Üst menüden `Start` (Başlat) butonuna basarak veya `F5` tuşu ile oyunu hemen oynayabilirsiniz.

##  Debug ve Loglama Sistemi
Proje isterleri doğrultusunda, oyun esnasında gerçekleşen önemli olaylar arka planda bir metin dosyasına yazdırılmaktadır. Oyun başladığında, projenin çalıştığı dizinde otomatik olarak `oyun_log.txt` adında bir dosya oluşturulur.

**Loglanan Olaylar:**
- Tuş basımı ve oyuncu konumu değişimi
- Yeni objelerin oluşması (`spawn`) ve hareketleri
- Çarpışma (yakalama) kontrolleri ve skor artışı
- Oyun bitiş sebebi



# S2PAndExcelDataApp
# S2PAndExcelDataApp

S2PAndExcelDataApp, S parametre veri formatına uygun s2p dosyalarını excele dönüştürme ve grafiğini eklemeye yardımcı olan bir uygulamadır.

## Geliştirici

- Geliştirici: Bilal Çifçi

## Kullanım

S2PAndExcelDataApp'ı kullanmak için aşağıdaki adımları takip edebilirsiniz:

1. **Excel Dosyası Açma:**
   - "File Operators" sekmesine gidin.
   - "Excel Aç" butonuna tıklayın.
   - Bir S-Parametre veri formatına uygun excel dosyasını seçin ve açın.
   - Açılan dosyanın içeriği "Tüm Veriler" adlı DataGridView'de görüntülenecektir.

2. **Sayfa Değiştirme:**
   - Açılan Excel dosyasının farklı sayfalarını görüntülemek için "Sayfa Değiştir" combobox'ını kullanın. Seçilen sayfanın içeriği DataGridView'de gösterilecektir.

3. **Mhz Aralığı Sorgulama:**
   - "Excel İşlemleri" sekmesinde, "Mhz Aralığı Seçin" kısmına gidin.
   - Minimum ve maksimum MHZ değerlerini girin.
   - "Sorgula" butonuna tıklayarak bu aralıktaki MHZ satırlarını sorgulayabilirsiniz.

4. **Sayfa Kaydetme:**
   - "Excel İşlemleri" bölümünde, "Kaydedilecek sayfa adı" textBox'ına kaydedilecek sayfa adını girin.
   - "Kaydet" butonuna basarak bu sayfayı aynı Excel dosyasına ekleyebilirsiniz.

5. **S2P Dosyalarını Excel'e Dönüştürme:**
   - "S2P To Excel" bölümüne gidin.
   - "Tek Dosya" bölümünde, "S2P Dosya Seç" butonu ile bir S2P dosyası seçin ve sorgulama işlemi yapabilirsiniz. Sonrasında "Excele Dönüştür" butonuna tıklayarak S2P dosyasını Excel'e dönüştürebilirsiniz.
   - "Tüm S2P Dosyaları" bölümünde, "S2P Klasör Seç" ve "S2P Kayıt Klasör Seç" butonları ile S2P dosyalarının bulunduğu klasörü ve kaydedileceği klasörü seçebilirsiniz. Ardından "Ayrı Excel Dosyalarına Dönüştür" veya "Tek Excel Dosyasına Dönüştür" butonları ile seçilen S2P dosyalarını Excel formatında kaydedebilirsiniz.

6. **Veri Görselleştirme:**
   - Açılan Excel ve S2P dosyalarında verilerin çizgi grafiği otomatik olarak oluşturulur ve "Data Chart" sekmesinde görüntülenir.

7. **Limitline Ekleme:**
   - "Data Chart" sekmesinde "Limitline Ekle" bölümüne gidin.
   - İlgili limitline'i seçin (örneğin, "S11_Limitline").
   - dB değeri ve Mhz aralığı girin, bu bilgilere göre iki nokta arasına kesikli çizgi eklenir.
   - Dosya kaydedilirken grafik, Excel grafiğinin altına resim olarak eklenir.

## Sürüm Geçmişi

- Sürüm: 1.0.0
  - İlk sürüm yayınlandı.


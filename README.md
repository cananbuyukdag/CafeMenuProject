Proje Bilgileri:

Bu proje, gerçek zamanlı olarak TL / Dolar / Euro bazında bir kafe menüsünün oluşturulmasını amaçlayan, Mvc .NET Framework 4.7.2 ile katmanlı mimari yapısında kurulmuş bir uygulamadır. Proje, MSSQL veri tabanı kullanılarak geliştirilmiştir.

Gerekli Adımlar:
1- Database Bağlantısı
Projenin çalışabilmesi için, Web.config dosyasına connectionStrings tagı altına SQL bağlantı bilgileri girilmelidir.

Örnek:
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=your_server_name;Database=your_database_name;Trusted_Connection=True;" />
</connectionStrings>

2- Migration İşlemleri

Visual Studio'da View > Other Windows > Package Manager Console açılmalıdır.

Katmanlı mimari kullanıldığı için Default Project olarak DataAccessLayer seçilmelidir.

Console ekranına - enable-migrations - komutu yazılmalıdır.
Eğer işlem başarılı olursa, yeni bir ekran açılır ve bu ekranı kaydedip tekrar konsola dönebilirsiniz.

Ardından, - update-database - komutu çalıştırılmalıdır.

Bu adımlardan sonra, belirtilen isimde bir database oluşacaktır.

3- Database Diagram
Proje içerisinde ilişkili tablolar bulunduğu için, veritabanı ilişkilerinin görsel olarak gösterildiği bir diagram oluşturulmalıdır.

4- Projeyi Çalıştırma
Proje çalıştırılmadan önce, UI katmanının üzerine gelip sağ tıklayarak Set as Startup Project seçilmelidir.
Daha sonra, IIS Express ile proje başlatılacaktır.

Admin Paneli Giriş Bilgileri:
Kullanıcı Adı: admin
Şifre: 123
Bu adımları takip ederek projenizi başlatabilirsiniz.

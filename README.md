Bu proje gerçek zamanlı olarak TL / Dolar / Euro bazında bir kafe menüsünün yapılmasını amaçlamıştır.
Proje Mvc .Net Framework 4.7.2 ile katmanlı mimari yapısında kurulmuştur.
Database olarak MSSQL kullanılmıştır. 
Projenin çalışabilmesi için database migration işlemi yapılmalıdır. 
Bu işlem için öncelikle MsSql bağlantısının kurulması gerekmektedir. Web.config dosyasına connectionStrings tagları içine sql connection bilgileri girilmelidir.
Migration adımı için Visual Studio üzerinde View > Other Windows > Package Manager Console açılmalıdır.
Burada katmanlı mimari kullanıldığı için Default Project DataAccessLayer olarak seçilmelidir.
Daha sonrasında console ekranına - enable-migrations - çalıştırılır. Başarılı olduğu takdirde bir ekran açılır bu ekranı kaydederek tekrar console a dönmemiz gerekir.
Console da - update-database - kodu çalıştırılmalı. Bu işlemlerden sonra database verilen isimde oluşsacaktır. Database üzerinde ilişkili tablolar olduğu için diagram oluşturulmalıdır.
Projeyi çalıştırmak için UI katmanının üzerine gelip sağ click Set as Startup Project seçilmesi gerekmektedir. Daha sonrasında IIS Express ile proje UI katmanından ayaklanacaktır.
Admin paneli için giriş bilgileri aşağıdaki gibidir;


Kullanıcı Adı: admin
Şifre: 123

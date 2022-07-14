# Kayit Rehberi Uygulaması
- :pencil2:  **Proje Hakkında Genel Bilgilendirme:** Proje Onion Architecture yaklaşımı ile inşa edilmiştir. Müşteriler ve bu müşterilere ait ticari faaliyetler kayıt edilip,
güncellenebilmekte ve silinebilmektedir. Databasede gerekli işlemler için Repository Design Pattern kullanılmıştır.
Ayrıca  CQRS Design Pattern mediatr kütüphanesiyle kullanılmıştır. Müşteri fotoğraflarına watermark eklemek için ise RabbitMq ve Drawing common kütüphanesi kullanılmıştır.
Identity kütüphanesi ile üyelik sistemi oluşturulmuş JWT ile kimlik doğrulama yapılmıştır. Ayrıca çeşitli görevlerde Admin ve editör rolü eklenmiştir.

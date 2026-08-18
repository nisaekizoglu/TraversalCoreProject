# TraversalCoreProject

## 🌍 TraversalCoreProject

TraversalCoreProject, **ASP.NET Core 8** kullanılarak geliştirilmiş, turizm ve seyahat sektörüne yönelik bir **web tabanlı tur yönetimi, destinasyon, rezervasyon ve içerik yönetim platformudur**.

Proje geliştirilirken yalnızca temel CRUD işlemlerinin gerçekleştirilmesi değil; modern .NET uygulamalarında kullanılan **katmanlı mimari, Repository Pattern, Unit of Work, Dependency Injection, DTO, Entity Framework Core, ASP.NET Core Identity, FluentValidation, AutoMapper, MediatR ve SignalR** gibi teknolojilerin birlikte kullanılması hedeflenmiştir.

Uygulama; kullanıcıların destinasyonları ve tur seçeneklerini inceleyebilmesini, rezervasyon işlemleri gerçekleştirebilmesini ve çeşitli içeriklerle etkileşim kurabilmesini sağlarken; yöneticilerin de sistem içerisindeki içerikleri, destinasyonları, kullanıcıları, rezervasyonları ve diğer verileri yönetebilmesine olanak sağlayacak şekilde tasarlanmıştır.

---

## 📌 Projenin Amacı

TraversalCoreProject'in temel amacı, bir turizm platformunda ihtiyaç duyulabilecek temel işlevleri **modüler, sürdürülebilir ve genişletilebilir bir yazılım mimarisi** içerisinde gerçekleştirmektir.

Proje geliştirilirken özellikle aşağıdaki konuların uygulanması amaçlanmıştır:

* ASP.NET Core 8 ile modern web uygulaması geliştirmek
* MVC mimarisini uygulamak
* Katmanlı mimari kullanarak sorumlulukları birbirinden ayırmak
* Entity Framework Core ile veritabanı işlemlerini gerçekleştirmek
* SQL Server üzerinde ilişkisel veri yönetimi yapmak
* Repository Pattern ile veri erişimini soyutlamak
* Unit of Work yaklaşımıyla veri işlemlerini yönetmek
* Dependency Injection kullanmak
* DTO'lar ile veri transferini kontrol etmek
* AutoMapper ile Entity/DTO dönüşümlerini kolaylaştırmak
* FluentValidation ile veri doğrulama kuralları oluşturmak
* ASP.NET Core Identity ile kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini gerçekleştirmek
* MediatR ile uygulama içerisindeki bazı işlemleri mediator yaklaşımıyla yönetmek
* SignalR kullanarak gerçek zamanlı iletişim sağlamak
* Excel ve PDF formatlarında rapor oluşturmak
* MailKit ile e-posta işlemlerini gerçekleştirmek
* Serilog altyapısıyla loglama desteği sağlamak
* Admin ve Member alanlarını ASP.NET Core Areas yapısıyla ayırmak

* **Ziyaretçi & Müşteri Paneli:**
  * Popüler tur rotalarını listeleme, filtreleme ve detaylı içerik inceleme.
  * Tur sayfalarına yorum ve puanlama bırakma.
  * ASP.NET Core Identity altyapısıyla güvenli kayıt ve giriş.
  * Geçmiş, onaylanan ve onay bekleyen tur rezervasyonlarını takip etme.

* **Rehber Modülü:**
  * Kendilerine atanan tur rotalarını ve detaylarını görüntüleme.
  * Tur katılımcı listelerine ve kullanıcı geri bildirimlerine erişim.

* **Admin Paneli:**
  * Tur rotası ekleme, düzenleme ve yayından kaldırma (CRUD).
  * Rehber atamaları ve durum yönetimi.
  * Rol bazlı yetkilendirme ve kullanıcı izin kontrolleri.
  * SignalR ile beslenen anlık ziyaretçi/rezervasyon istatistik paneli ve dinamik grafik entegrasyonu.
---

# 🏗️ Mimari

Proje, **Separation of Concerns** ve **Clean Code** ilkelerine uygun olarak 6 temel katmandan oluşmaktadır:

```text
TraversalCoreProject/
│
├── 📁 TraversalCoreProje.EntityLayer/       # Veritabanı tablolarına karşılık gelen temel Entity sınıfları
├── 📁 TraversalCoreProje.DataAccessLayer/   # DbContext, Migrations, Generic Repository & Dapper sorguları
├── 📁 TraversalCoreProje.BusinessLayer/     # İş kuralları, Manager servisleri, FluentValidation doğrulama kuralları
├── 📁 TraversalCoreProje.DTOLayer/          # Katmanlar arası güvenli veri transfer nesneleri (DTOs)
├── 📁 TraversalCoreProje.SignalRApi/        # Canlı veri akışı sağlayan SignalR Hub servisleri
└── 📁 TraversalCoreProje.PresentationLayer/ # ASP.NET Core MVC (WebUI), Admin ve Member Area yapıları
```
---

# 🗺️ Temel Fonksiyonlar

TraversalCoreProject içerisinde turizm uygulamasının farklı ihtiyaçlarını karşılayan çeşitli modüller bulunmaktadır.

### 🌍 Destinasyon Yönetimi

* Destinasyon listeleme
* Destinasyon detayları
* Destinasyon ekleme
* Destinasyon güncelleme
* Destinasyon silme
* Destinasyon içeriklerinin yönetimi

### 🧑‍🏫 Rehber Yönetimi

* Rehber bilgileri
* Rehber listeleme
* Rehber yönetimi
* Rehber içeriklerinin düzenlenmesi

### 📅 Rezervasyon

* Rezervasyon oluşturma
* Rezervasyon bilgilerini yönetme
* Rezervasyon durumlarının takip edilmesi

### 💬 Yorumlar

* Kullanıcı yorumları
* Yorum yönetimi
* Yorumların sistem içerisinde görüntülenmesi

### 👤 Kullanıcı Yönetimi

ASP.NET Core Identity ile:

* Kullanıcı kayıt
* Login
* Logout
* Kullanıcı bilgileri
* Yetkilendirme

işlemleri gerçekleştirilebilir.

### 📢 Duyurular

Sistem içerisindeki duyuru ve bilgilendirme içeriklerinin yönetilmesi.

### 📩 İletişim

Kullanıcıların sistem üzerinden iletişim formu aracılığıyla mesaj gönderebilmesi.

### 📰 Newsletter

Kullanıcıların newsletter sistemine dahil edilmesi ve e-posta iletişimi için gerekli altyapının oluşturulması.

### ⭐ Testimonial / Referanslar

Kullanıcı veya müşteri referanslarının sistem içerisinde yönetilmesi.

### 📊 Raporlama

Verilerin:

* Excel
* PDF

formatlarında raporlanabilmesi.

### ⚡ Gerçek Zamanlı Veri

SignalR kullanılarak gerçek zamanlı iletişim altyapısının uygulanması.

---

# 🛠️ Kullanılan Teknolojiler

| Teknoloji                   | Kullanım Alanı                       |
| --------------------------- | ------------------------------------ |
| **C#**                      | Ana programlama dili                 |
| **.NET 8**                  | Uygulama platformu                   |
| **ASP.NET Core MVC**        | Web uygulaması ve Presentation Layer |
| **Entity Framework Core 8** | ORM / Veri erişimi                   |
| **SQL Server**              | Veritabanı                           |
| **ASP.NET Core Identity**   | Authentication / Authorization       |
| **FluentValidation**        | Validation                           |
| **AutoMapper**              | Entity ↔ DTO mapping                 |
| **MediatR**                 | Mediator yaklaşımı                   |
| **SignalR**                 | Gerçek zamanlı iletişim              |
| **Repository Pattern**      | Veri erişim soyutlaması              |
| **Unit of Work**            | Veri işlemlerinin yönetimi           |
| **DTO**                     | Veri transferi                       |
| **ClosedXML**               | Excel raporlama                      |
| **EPPlus**                  | Excel işlemleri                      |
| **iTextSharp**              | PDF oluşturma                        |
| **MailKit**                 | E-posta işlemleri                    |
| **Serilog**                 | Logging                              |
| **Razor Views**             | UI / Presentation                    |
| **MVC Areas**               | Admin / Member ayrımı                |

Ana web projesinin `.csproj` dosyasında .NET 8 hedef framework'ü ve bu teknolojilerin önemli bölümü doğrudan tanımlanmıştır.

---

# 🔐 Güvenlik

Projede kullanıcı kimlik yönetimi için ASP.NET Core Identity kullanılmaktadır.

Uygulamanın rol bazlı erişim ihtiyaçları için Admin ve Member alanlarının ayrılması da güvenlik ve sorumlulukların ayrıştırılması açısından kullanılmaktadır.

Production ortamına alınırken aşağıdaki bilgilerin kaynak kod içerisinde tutulmaması önerilir:

```text
Connection Strings
SMTP Credentials
Database Passwords
API Keys
Secret Keys
Identity Configuration
```

Bunun yerine:

* User Secrets
* Environment Variables
* Azure Key Vault
* Secret Management çözümleri

gibi yöntemler tercih edilmelidir.

---

# 🎯 Projenin Öğrenme Hedefleri

TraversalCoreProject özellikle aşağıdaki konularda pratik kazanmak amacıyla geliştirilebilir:

### Backend Development

* ASP.NET Core
* C#
* REST API
* MVC
* Dependency Injection

### Database

* SQL Server
* Entity Framework Core
* Code First
* Migrations
* Relationships
* LINQ

### Architecture

* N-Tier Architecture
* Repository Pattern
* Unit of Work
* Dependency Inversion
* DTO
* Service/Manager Layer

### Validation & Mapping

* FluentValidation
* AutoMapper

### Authentication

* ASP.NET Core Identity
* Authentication
* Authorization
* Roles

### Advanced .NET

* MediatR
* SignalR
* Logging
* Email
* Excel Reporting
* PDF Reporting

---

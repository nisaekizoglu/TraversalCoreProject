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

---

# 🔐 ASP.NET Core Identity

Kullanıcı yönetimi için **ASP.NET Core Identity** kullanılmaktadır.

Identity sayesinde uygulamada:

* Kullanıcı oluşturma
* Login
* Logout
* Authentication
* Authorization
* Kullanıcı bilgileri
* Role tabanlı yetkilendirme

gibi işlemler framework altyapısından yararlanılarak gerçekleştirilebilir.

Projede ayrıca **Admin** ve **Member** alanlarının ayrılması için ASP.NET Core MVC Areas yapısından yararlanılmıştır.

```text
Areas
├── Admin
└── Member
```

Bu sayede yönetici işlemleri ile kullanıcıya özel işlemler birbirinden ayrılmaktadır.

---

# 🔄 Repository Pattern

Data Access Layer içerisinde Repository yaklaşımı kullanılmıştır.

Repository Pattern'in temel amacı:

> Uygulamanın veri erişim detaylarını Business Layer'dan soyutlamaktır.

Örneğin Business Layer:

```csharp
_destinationDal.GetList();
```

gibi bir abstraction üzerinden çalışırken, bu işlemin Entity Framework Core kullanılarak nasıl gerçekleştirildiği Data Access Layer tarafından yönetilir.

Böylece:

```text
Business Layer
      ↓
Repository / DAL Interface
      ↓
EF Core Implementation
      ↓
Database
```

şeklinde bir yapı oluşturulur.

---

# 🔁 Unit of Work

DataAccessLayer içerisinde **Unit of Work** yapısı da bulunmaktadır.

Unit of Work yaklaşımının amacı, bir işlem sırasında gerçekleştirilen birden fazla veri erişim operasyonunu tek bir çalışma birimi içerisinde yönetmektir.

Örneğin:

```text
Reservation
   ↓
User
   ↓
Destination
   ↓
Database
```

gibi ilişkili işlemlerin kontrollü şekilde yürütülmesini sağlar.

Bu yaklaşım Repository Pattern ile birlikte kullanılarak veri erişim katmanının daha merkezi ve yönetilebilir hale getirilmesine yardımcı olur.

---

# 🧩 Dependency Injection

ASP.NET Core'un yerleşik **Dependency Injection** mekanizmasından yararlanılmaktadır.

Örneğin:

```text
Controller
    ↓
IService
    ↓
Manager
    ↓
IDAL
    ↓
EF DAL
```

bağımlılıklarının doğrudan `new` ile oluşturulması yerine DI container üzerinden yönetilmesi hedeflenmiştir.

Bu yaklaşım:

* Loose Coupling
* Test edilebilirlik
* Bakım kolaylığı
* Modülerlik

sağlamaktadır.

---

# 🧠 MediatR

Projede **MediatR** kullanılmaktadır.

MediatR, uygulama içerisindeki bileşenler arasındaki doğrudan bağımlılığı azaltmak için mediator yaklaşımı sunar.

Genel yapı:

```text
Controller
     ↓
Mediator
     ↓
Request / Command / Query
     ↓
Handler
     ↓
Business Operation
```

Bu yapı sayesinde bazı işlemler doğrudan Controller içerisinde gerçekleştirilmek yerine mediator üzerinden ilgili handler'a yönlendirilebilir.

> Projenin ana mimarisi tamamen CQRS olarak tanımlanmamakla birlikte MediatR kullanımı sayesinde mediator/CQRS yaklaşımından yararlanılmaktadır.

---

# ✅ FluentValidation

Veri doğrulama işlemleri için **FluentValidation** kullanılmaktadır.

Validation kurallarının Controller içerisine dağılması yerine ayrı validation sınıflarında tutulması hedeflenmiştir.

Örneğin:

```text
Destination
├── City required
├── Description required
├── Price validation
└── Other business validation rules
```

gibi kurallar FluentValidation üzerinden tanımlanabilir.

Bu sayede validation logic daha okunabilir ve tekrar kullanılabilir hale gelir.

---

# 🔀 AutoMapper

Entity ve DTO modelleri arasındaki dönüşümler için **AutoMapper** kullanılmaktadır.

Örneğin:

```text
Destination Entity
       ↓
AutoMapper
       ↓
Destination DTO
```

veya:

```text
Destination DTO
       ↓
AutoMapper
       ↓
Destination Entity
```

şeklinde dönüşüm yapılabilir.

Bu yaklaşım özellikle çok sayıda property içeren modellerde manuel mapping kodunun azaltılmasını sağlar.

---

# ⚡ SignalR

Projede gerçek zamanlı iletişim için **ASP.NET Core SignalR** kullanılmaktadır.

Solution içerisinde SignalR ile ilgili üç ayrı proje bulunmaktadır:

```text
SignalRApi
SignalRApiForSql
SignalRConsume
```

SignalR'ın temel amacı HTTP request/response modelinden farklı olarak server ile client arasında **gerçek zamanlı iletişim** sağlayabilmektir.

Genel iletişim modeli:

```text
                 ┌──────────────┐
                 │    Server    │
                 └──────┬───────┘
                        │
                  SignalR Hub
                        │
            ┌───────────┴───────────┐
            ↓                       ↓
         Client 1                Client 2
```

Bu yapı sayesinde server tarafındaki değişikliklerin bağlı client'lara gerçek zamanlı olarak aktarılması mümkündür.

`SignalRApiForSql` içerisinde ayrıca `Hubs`, `DAL`, `Model` ve `Migrations` gibi klasörlerin bulunması, SignalR tarafında veritabanı destekli senaryoların da ele alındığını göstermektedir.

---

# 📊 Excel Raporlama

Projede Excel formatında rapor oluşturabilmek için:

* ClosedXML
* EPPlus

kütüphanelerinden yararlanılmaktadır.

Bu yapı sayesinde sistem içerisindeki verilerin Excel formatında dışarı aktarılması hedeflenmiştir.

Örneğin:

```text
Database
   ↓
Business Layer
   ↓
Excel Manager
   ↓
Excel File
```

şeklinde bir raporlama akışı oluşturulabilir.

---

# 📄 PDF Raporlama

Projede PDF raporlama desteği de bulunmaktadır.

PDF işlemleri için:

**iTextSharp.LGPLv2.Core**

kütüphanesi kullanılmaktadır.

Ana web projesinde PDF raporlama için ayrı bir controller ve rapor çıktılarının tutulabileceği `wwwroot/pdfreport` klasörü bulunmaktadır.

---

# 📧 E-Mail

E-posta işlemleri için **MailKit** kullanılmaktadır.

MailKit sayesinde uygulama içerisinden SMTP tabanlı e-posta gönderme işlemleri gerçekleştirilebilir.

Bu yapı:

* İletişim işlemleri
* Kullanıcı bildirimleri
* Rezervasyon bildirimleri
* Newsletter
* Sistem mesajları

gibi senaryolarda kullanılabilecek şekilde projeye dahil edilmiştir.

---

# 📝 Logging

Projede loglama için:

**Serilog.Extensions.Logging**

kullanılmaktadır.

Logging altyapısının amacı uygulamanın çalışma sırasında meydana gelen:

* Information
* Warning
* Error
* Debug

gibi olaylarının takip edilebilmesini sağlamaktır.

Production ortamlarında loglama; hata tespiti, sistem takibi ve debugging açısından önemli bir bileşendir.

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

# 📈 Projenin Geliştirilmesi

Proje, modern bir .NET uygulamasında kullanılabilecek birçok temel teknolojiyi bir araya getirecek şekilde tasarlanmıştır.

İlerleyen aşamalarda aşağıdaki geliştirmeler yapılabilir:

* RESTful API katmanının genişletilmesi
* JWT Authentication
* Redis Cache
* Docker desteği
* CI/CD pipeline
* Unit Test / Integration Test
* Global Exception Handling
* Centralized Logging
* Redis ile distributed caching
* Elasticsearch
* Cloud deployment
* Azure entegrasyonu
* Daha kapsamlı CQRS
* MediatR pipeline behaviors
* Rate limiting
* API versioning
* OpenAPI / Swagger
* Advanced role & permission management

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

# 🚀 Sonuç

TraversalCoreProject, gerçek bir turizm platformunun ihtiyaç duyabileceği temel fonksiyonları **modern .NET teknolojileri ve katmanlı mimari yaklaşımıyla** bir araya getiren bir web uygulamasıdır.

Projenin temel amacı yalnızca bir tur/rezervasyon sistemi oluşturmak değil, aynı zamanda **kurumsal ölçekte .NET uygulamalarında kullanılan mimari prensipleri ve teknolojileri pratik olarak uygulamaktır.**

Özellikle:

* **ASP.NET Core 8**
* **Entity Framework Core**
* **SQL Server**
* **N-Tier Architecture**
* **Repository Pattern**
* **Unit of Work**
* **Dependency Injection**
* **ASP.NET Core Identity**
* **DTO**
* **AutoMapper**
* **FluentValidation**
* **MediatR**
* **SignalR**
* **Excel/PDF Reporting**
* **MailKit**
* **Serilog**

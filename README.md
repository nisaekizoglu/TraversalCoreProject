<img width="1919" height="796" alt="Ekran görüntüsü 2026-08-18 171530" src="https://github.com/user-attachments/assets/0d84f15e-dde3-47b5-b008-56f15236debb" /># TraversalCoreProject

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

## Projenin Ana Sayfa Görselleri

<img width="1919" height="796" alt="Ekran görüntüsü 2026-08-18 171530" src="https://github.com/user-attachments/assets/3ab99e51-05d0-41d8-aa8b-a323d472438e" />
<img width="1918" height="789" alt="Ekran görüntüsü 2026-08-18 171941" src="https://github.com/user-attachments/assets/4e20d61b-500c-4f74-9cf0-45d8a5373c5c" />
<img width="1919" height="787" alt="Ekran görüntüsü 2026-08-18 172010" src="https://github.com/user-attachments/assets/e25e9b57-84ae-408c-8093-abb553e67d8b" />
<img width="1919" height="806" alt="Ekran görüntüsü 2026-08-18 172101" src="https://github.com/user-attachments/assets/2cfee002-f8d7-48f8-b9ef-c860b46dee6f" />
<img width="1919" height="789" alt="Ekran görüntüsü 2026-08-18 172114" src="https://github.com/user-attachments/assets/fc2e8e6b-aa37-4818-ac5d-601db7232e3a" />
<img width="1919" height="787" alt="Ekran görüntüsü 2026-08-18 172132" src="https://github.com/user-attachments/assets/0923c8ee-993e-4627-bc26-1505e544aa53" />
<img width="1919" height="799" alt="Ekran görüntüsü 2026-08-18 172155" src="https://github.com/user-attachments/assets/402feba3-e1c4-4f13-b1e5-887d6adb7eae" />
<img width="1917" height="802" alt="Ekran görüntüsü 2026-08-18 172210" src="https://github.com/user-attachments/assets/5a325c44-abb5-4694-b892-b77afecebc87" />
<img width="1919" height="783" alt="Ekran görüntüsü 2026-08-18 172224" src="https://github.com/user-attachments/assets/12dc242c-16de-4b59-bfcd-c386c3c9fa4e" />

---

## Projenin Admin Tarafı Görselleri

<img width="1918" height="814" alt="Ekran görüntüsü 2026-08-18 194251" src="https://github.com/user-attachments/assets/ba86a4ea-b34a-4ab7-9542-a5aea8aadb7d" />
<img width="1919" height="796" alt="Ekran görüntüsü 2026-08-18 194306" src="https://github.com/user-attachments/assets/d5a844d2-b7c5-40c6-a8dc-3a42aeaac40e" />
<img width="1919" height="797" alt="Ekran görüntüsü 2026-08-18 194319" src="https://github.com/user-attachments/assets/8bd1e4b3-ad90-4126-bfb1-38139f8b3910" />
<img width="1919" height="806" alt="Ekran görüntüsü 2026-08-18 194335" src="https://github.com/user-attachments/assets/2a2b08a4-bb05-49aa-83c3-c497f122e328" />
<img width="1915" height="804" alt="Ekran görüntüsü 2026-08-18 194351" src="https://github.com/user-attachments/assets/9df7ae10-02f2-4cd9-8d32-b90268db12a2" />
<img width="1919" height="593" alt="Ekran görüntüsü 2026-08-18 194419" src="https://github.com/user-attachments/assets/7a3c8fb2-7102-4362-8681-e2afabc0ad44" />
<img width="1919" height="803" alt="Ekran görüntüsü 2026-08-18 194433" src="https://github.com/user-attachments/assets/d223ec5c-f50e-4ba4-b36d-c78120fd854c" />
<img width="1919" height="801" alt="Ekran görüntüsü 2026-08-18 194453" src="https://github.com/user-attachments/assets/d501aee5-d761-47af-ab16-65ed8335ea61" />

---

## Projenin Kullanıcı Tarafı Görselleri

<img width="1919" height="895" alt="Ekran görüntüsü 2026-08-18 122807" src="https://github.com/user-attachments/assets/55a10f8f-26ec-4fa7-ba02-586c9aae1654" />
<img width="1919" height="904" alt="Ekran görüntüsü 2026-08-18 122826" src="https://github.com/user-attachments/assets/a17cac47-48ed-439c-ac74-446ed81d4979" />
<img width="1919" height="754" alt="Ekran görüntüsü 2026-08-18 171441" src="https://github.com/user-attachments/assets/6ec211d4-d8f1-4028-92bd-5bee7e82cfdd" />

---

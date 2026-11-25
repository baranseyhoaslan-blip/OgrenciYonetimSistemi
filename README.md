# 🎓 Öğrenci ve Bölüm Yönetim Sistemi

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-Code--First-0078D4?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

**Öğrenci ve Bölüm Yönetim Sistemi**, ASP.NET Core MVC mimarisi ve Entity Framework Core (Code-First) kullanılarak geliştirilmiş, ilişkisel veritabanı yapısına sahip web tabanlı bir yönetim uygulamasıdır. Temel CRUD operasyonları, bire-çok (1-N) tablo ilişkileri ve özet istatistik ekranı (Dashboard) ile akademik birimlerin öğrenci ve bölüm kayıtlarını merkezi olarak yönetmesini sağlar.

---

## ✨ Özellikler

- **Yönetim Paneli (Dashboard):** Veritabanındaki toplam bölüm ve öğrenci sayılarını LINQ sorguları ile anlık olarak hesaplar ve özet kartlar halinde sunar.
- **Bölüm Yönetimi (`BolumlerController`):** Yeni akademik bölüm ekleme, mevcut bölümleri listeleme ve silme işlemleri.
- **Öğrenci Yönetimi (`OgrenciController`):** Öğrencileri ilgili bölümlerle ilişkili (Foreign Key) olarak kaydetme, listeleme, bilgilerini güncelleme ve silme işlemleri.
- **İlişkisel Veritabanı Tasarımı:** Entity Framework Core Code-First yaklaşımı ve Migration yönetimi ile oluşturulan ilişkisel tablo mimarisi (`Bolumler`, `Ogrenciler`, `AkademikPersonel`, `Login`).
- **Duyarlı Arayüz (Responsive UI):** Bootstrap 5 ve Razor Views kullanılarak hazırlanmış sade ve erişilebilir kullanıcı arayüzü.

---

## 🛠️ Kullanılan Teknolojiler

| Katman | Teknoloji / Araç |
| :--- | :--- |
| **Backend** | C#, ASP.NET Core MVC (.NET 8) |
| **ORM & Veri Erişimi** | Entity Framework Core (Code-First, Migrations, LINQ) |
| **Veritabanı** | Microsoft SQL Server (MS SQL / SQLEXPRESS) |
| **Frontend** | HTML5, CSS3, Bootstrap 5, Razor Pages (`.cshtml`) |
| **Geliştirme Ortamı** | Visual Studio 2022, SQL Server Management Studio (SSMS) |

---

## 📂 Proje Klasör Yapısı

```text
OgrenciYonetimSistemi/
├── VizeTekrar/
│   ├── Controllers/          # HTTP isteklerini yöneten MVC Controller sınıfları
│   │   ├── HomeController.cs
│   │   ├── BolumlerController.cs
│   │   ├── OgrenciController.cs
│   │   └── LoginController.cs
│   ├── Models/               # Veritabanı varlıkları (Entities) ve DbContext
│   │   ├── VeritabaniBaglantisi.cs
│   │   ├── Bolumler.cs
│   │   ├── Ogrenciler.cs
│   │   ├── AkademikPersonel.cs
│   │   └── Login.cs
│   ├── Migrations/           # EF Core veritabanı şema geçmişi
│   ├── Views/                # Razor HTML şablonları ve paylaşılan Layout
│   ├── wwwroot/              # Statik dosyalar (CSS, JS, Bootstrap kütüphaneleri)
│   ├── appsettings.json      # Uygulama yapılandırma ayarları
│   └── Program.cs            # Uygulama başlangıç ve middleware yapılandırması
├── VizeTekrar.sln            # Visual Studio çözüm dosyası
├── .gitignore
└── README.md
```

---

## 🚀 Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin.

### Gereksinimler
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server (`SQLEXPRESS` veya `LocalDB`)
- Visual Studio 2022 (veya VS Code)

### Adım Adım Kurulum

1. **Repoyu klonlayın:**
   ```bash
   git clone [https://github.com/baranseyhoaslan-blip/OgrenciYonetimSistemi.git](https://github.com/baranseyhoaslan-blip/OgrenciYonetimSistemi.git)
   cd OgrenciYonetimSistemi
   ```

2. **Projeyi açın:**
   `VizeTekrar.sln` dosyasını Visual Studio ile açın.

3. **Veritabanı bağlantısını yapılandırın:**
   `VizeTekrar/Models/VeritabaniBaglantisi.cs` (veya `appsettings.json`) içerisindeki `ConnectionString` değerini kendi yerel SQL Server sunucu adınıza göre güncelleyin.

4. **Veritabanını oluşturun (Migration):**
   Visual Studio'da **Package Manager Console** ekranını açın ve şu komutu çalıştırın:
   ```powershell
   Update-Database
   ```
   *(Alternatif olarak terminal üzerinden `dotnet ef database update` komutunu kullanabilirsiniz.)*

5. **Uygulamayı başlatın:**
   Visual Studio üzerinden `F5` tuşuna basarak veya terminalden aşağıdaki komutla projeyi ayağa kaldırın:
   ```bash
   dotnet run --project VizeTekrar
   ```

---

## 🗺️ Geliştirme Planı (Roadmap)

- [x] Temel Bölüm ve Öğrenci CRUD işlemleri
- [x] EF Core Code-First ve ilişkisel tablo kurulumu
- [x] Dashboard özet istatistik kartları
- [ ] Cookie tabanlı kimlik doğrulama (Authentication) ve rol bazlı yetkilendirme
- [ ] Öğrenci listesinde arama, filtreleme ve sayfalama (Pagination)
- [ ] Docker ile konteynerize edilmesi (`Dockerfile` & `docker-compose.yml`)

---

## 👨‍💻 Geliştirici

**Hüseyin Baran Aslan**  
Bilgisayar Mühendisliği Öğrencisi | Backend Developer (.NET & SQL Server)

- **GitHub:** [@baranseyhoaslan-blip](https://github.com/baranseyhoaslan-blip)

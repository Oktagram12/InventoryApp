# 📦 InventoryApp - Envanter ve Stok Yönetimi API

Bu proje, Karadeniz Teknik Üniversitesi (KTÜ) Bilgisayar Mühendisliği staj programı kapsamında **Rafora Bilişim Hizmetleri** için geliştirilmiş bir RESTful API servisidir.

## 🚀 Proje Amacı ve Özellikler
Depo bazlı ürün stoklarının takip edilmesini, güncellenmesini ve stoklar kritik seviyeye düştüğünde yöneticilere otomatik e-posta bildirimleri gönderilmesini sağlar.

- **Gelişmiş Stok Yönetimi:** Ürünlerin depolara göre stok sayılarının takibi.
- **Otomatik Uyarı Sistemi:** Stok, belirlenen kritik seviye değerine veya altına düştüğünde sistem yöneticilerine anında HTML formatında uyarı maili gönderilir.
- **Güvenli ve İzole Çalışma:** Şifreler `appsettings.json` üzerinden dinamik okunur, kaynak kodda gizli tutulur.
- **Docker Desteği:** Tek bir komutla PostgreSQL veritabanı ortamı ayağa kalkar.
- **Eager Loading:** İlişkili veriler (Depo isimleri vb.) performanslı bir şekilde API yanıtlarına dahil edilir.

## 🛠️ Kullanılan Teknolojiler
- **Backend:** C# .NET 10, ASP.NET Core Web API
- **ORM:** Entity Framework Core (Code-First)
- **Veritabanı:** PostgreSQL (Npgsql)
- **Konteynerleştirme:** Docker & Docker Compose
- **Dokümantasyon:** Scalar

## ⚙️ Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

**1. Projeyi Klonlayın:**
```bash
git clone [https://github.com/Oktagram12/InventoryApp.git](https://github.com/Oktagram12/InventoryApp.git)
cd InventoryApp
```

**2. Gizli Ayarları Yapılandırın:**
Şifreler ve e-posta bilgileri depoya yazılmaz. Veritabanı şifresi için `.env.example` dosyasını `.env` olarak kopyalayıp doldurun:
```bash
cp .env.example .env
```
E-posta ve yerel bağlantı ayarlarını [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) ile girin (proje bunun için hazır):
```bash
dotnet user-secrets set "EmailSettings:SenderEmail" "gonderen@gmail.com"
dotnet user-secrets set "EmailSettings:SenderPassword" "16_haneli_uygulama_sifresi"
dotnet user-secrets set "EmailSettings:AlertRecipient" "uyari_alacak@adres.com"
dotnet user-secrets set "ConnectionStrings:PostgresConnection" "Host=localhost;Port=5433;Database=RaforaInventoryDb;Username=postgres;Password=.env_deki_sifre"
```

**3. Veritabanını Ayağa Kaldırın:**
Bilgisayarınızda Docker'ın çalıştığından emin olun ve terminalde şu komutu çalıştırın:
```bash
docker compose up -d
```

**4. Veritabanı Tablolarını Oluşturun:**
Entity Framework Migrations kullanarak tabloları inşa edin:
```bash
dotnet ef database update
```

**5. Projeyi Çalıştırın:**
Projeyi başlatın (örn: dotnet run). Ardından tarayıcınızdan https://localhost:xxxx/scalar/v1 (port numarası projeniz çalıştığında terminalde görünecektir) adresine giderek tüm API uçlarını (GET, POST, PUT, DELETE) test edebilirsiniz.

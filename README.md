# MeetingApp

Toplantı oluşturma, listeleme ve katılımcı yönetimi (katılma / katılımcıları görüntüleme) sağlayan **ASP.NET Core MVC** tabanlı bir web uygulaması.

- **Hedef kullanıcı**
  - Kurum içi ekipler, etkinlik/organizasyon sorumluları, topluluk yöneticileri ve küçük/orta ölçekli takımlar
  - Hızlıca toplantı açıp katılımcıları takip etmek isteyen herkes

## Özellikler

- **Toplantı yönetimi**
  - Toplantı oluşturma
  - Toplantıları listeleme
  - Toplantı detayı görüntüleme
- **Katılımcı yönetimi**
  - Toplantıya katılma
  - Toplantı katılımcılarını listeleme
  - Aynı kullanıcının aynı toplantıya tekrar katılmasını engelleyen benzersiz indeks (EF Core)
- **Kimlik doğrulama**
  - Kayıt olma / giriş yapma
  - Cookie tabanlı oturum yönetimi
- **Veri katmanı**
  - Entity Framework Core
  - SQLite veritabanı

## Kurulum

### Gereksinimler

- .NET SDK **8.0**
- (Opsiyonel) `dotnet-ef` aracı (migration/update işlemleri için)

### Projeyi çalıştırma

1) Repoyu klonla:

```bash
git clone https://github.com/furkanksc18/MeetingApp.git
cd MeetingApp
```

2) Bağımlılıkları yükle:

```bash
dotnet restore
```

3) Veritabanı bağlantısını kontrol et:

- Geliştirme ortamında bağlantı dizesi `appsettings.Development.json` içindedir.
- Varsayılan olarak SQLite kullanır:

```json
"ConnectionStrings": { "database": "Data Source=MeetingApp.db" }
```

4) Migration’ları uygula (önerilen):

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

5) Uygulamayı çalıştır:

```bash
dotnet run
```

Uygulama varsayılan olarak terminalde yazan URL üzerinden erişilebilir.

## Kullanım

### Temel akış

1) **Kayıt ol**

- `/Account/Register`

2) **Giriş yap**

- `/Account/Login`

3) **Toplantı oluştur**

- `/Meeting/Add`

4) **Toplantılara göz at / katıl**

- `/Meeting/Index`
- Katılım: `/Meeting/Join?MeetingId=...`

5) **Katılımcıları görüntüle**

- `/Meeting/Participants?MeetingId=...`

### Notlar

- Uygulama **Cookie Authentication** kullanır. Giriş yapılmadığında korumalı aksiyonlar login sayfasına yönlendirir.
- Geliştirme ortamında SQLite dosyası proje kökünde `MeetingApp.db` olarak oluşabilir/mevcuttur.

## Proje Yapısı

```text
MeetingApp/
  Controllers/
    AccountController.cs
    HomeController.cs
    MeetingController.cs
  Data/
    DataContext.cs
    Entity/
      Meeting.cs
      User.cs
      MeetingMapUser.cs
    Migrations/
  Views/
    Account/
    Home/
    Meeting/
    Shared/
  wwwroot/
  Program.cs
  appsettings.json
  appsettings.Development.json
  MeetingApp.csproj
  MeetingApp.sln
```

## Katkıda Bulunma

Katkılar memnuniyetle kabul edilir.

1) Bu repoyu fork’la
2) Yeni bir branch oluştur:

```bash
git checkout -b feature/my-change
```

3) Değişikliklerini yap ve test et
4) Commit at ve pushla:

```bash
git commit -m "Add: my change"
git push origin feature/my-change
```

5) Pull Request aç

Herhangi bir öneri/hata bildirimi için: `furkanksc18@gmail.com`

## Lisans

Bu proje **MIT License** ile lisanslanmıştır. Ayrıntılar için `LICENSE` dosyasına bakın.

# Promotion App

### Spesifikasi
- NetCore 3.1
- Microsoft.EntityFrameworkCore 3.1.2
- Microsoft EntityFrameworkCore.SqlServer 3.1.2
- Microsoft EntityFrameworkCore.Tools 3.1.2
- SQL Server
- EPPlus 5.5.5
- Code First

### DB Migrasi
Mohon lakukan sesuai urutan step berikut, dimulai dari point pertama :

- Sesuaikan koneksi database appsettings.json
![](https://gitlab.com/ishwhd/image/-/raw/main/Promo/Appsettingjson.JPG)

- Lakukan migrasi table, buka Package Manage Console

- Ketik perintah berikut
```
update-database
```
![](https://gitlab.com/ishwhd/image/-/raw/main/Promo/update-database.JPG)

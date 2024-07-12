# Topic Blog Projesi 
#### Topic Blog projesi, M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde tamamladığım fullstack developer eğitimi kapsamında geliştirdiğim önemli bir projedir. Bu proje, API tarafında gerçekleştirdiğimiz CRUD işlemlerini kullanarak UI tarafında blog işlemlerini yönetmemizi sağlar. API tarafında Silme, Güncelleme, Ekleme, Listeleme ve Id değerine göre getirme gibi temel CRUD işlemlerinin yanı sıra, özel entity metodlarını da entegre ettik.

#### ✓ Kullanıcılar, bu projeyi kullanarak kategorilere göre listelenen blogları görüntüleyebilir ve her bir blogun detaylarını inceleyebilirler. Ayrıca, sık sorulan sorular bölümündeki içerikleri de gözden geçirebilirler.

#### ✓ Admin panelinde ise yetkililer, sayfada listelenen kategorilerin görüntülenme durumunu true veya false olarak değiştirerek kontrol edebilirler. Aynı zamanda, kategorilere yeni bloglar ekleyebilir, mevcut blogları silebilir veya güncelleyebilirler. Sık sorulan sorular bölümüne yeni sorular ekleyebilir, var olanları silebilir veya güncelleyebilirler.

#### Bu proje, hem kullanıcıların blogları kolayca yönetmelerini hem de yöneticilerin içerikleri etkin bir şekilde idare etmelerini sağlayan güçlü bir yapı sunar.


## Projede Kullanılan Teknolojiler :
🟢  .NET Core 8.0 ile geliştirildi.

🟢  ASP.NET Core Web API

🟢  Code First yaklaşımı

🟢  Veritabanı: MSSQL

🟢  Verileri AutoMapper kullanarak API ile eşleştirme

🟢  Sıfırdan bir API yazıp WebUI ile consume etme


## Projede Oluşturduğum Katmanlar :
![image](https://github.com/user-attachments/assets/579e3992-6deb-4008-996e-2624e528fa66)


-----------------------------------------------------------------------------------------------------------------------------------------
### Proje Görselleri ve Açıklamalar

-----------------------------------------------------------------------------------------------------------------------------------------
#### UI Tarafı

![UI Anasayfa](https://github.com/user-attachments/assets/9855a10e-f1de-4fd8-9925-7cf8658f8d14)

📌 Burada kategorilerin listesi yer almaktadır ayrıca bu kısımda ilgili kategorinin kaç tane bloğa sahip olduğu bilgisi de bulunmaktadır. Kategorilere tıklandığında sadece o kategoriye ait blog sayfaları listelenmektedir.

-----------------------------------------------------------------------------------------------------------------------------------------

![Bloglar ve kategoriler](https://github.com/user-attachments/assets/c2cbfc52-b5c5-47ff-a3dd-bdd8b81072f4)
![Bilim kategorisine ait bloglar](https://github.com/user-attachments/assets/d53e634b-3c2c-43ca-8550-15ce54b8084e)

##### 📌 Burada Kategorilere tıkladığımızda o kategorilere ait bloglar listelenmektedir. 
-----------------------------------------------------------------------------------------------------------------------------------------

![Manuel alanı](https://github.com/user-attachments/assets/46e9d64d-bafa-40ff-9502-fa051180f201)

-----------------------------------------------------------------------------------------------------------------------------------------

![sık sorulanlar](https://github.com/user-attachments/assets/85591deb-ba41-48e8-8529-dec1c3a704b0)

![sık sorulanlar 2](https://github.com/user-attachments/assets/4193d59f-d1d0-4159-b72e-9b64761355c3)

##### 📌 Sık sorulan sorular alanı

-----------------------------------------------------------------------------------------------------------------------------------------
![Bilim kategorisine ait bloglar1](https://github.com/user-attachments/assets/5efa948f-8800-40b9-8356-7788fdc803ee)
![Business kategorisine ait bloglar](https://github.com/user-attachments/assets/cc474616-eb4d-4bee-9065-9ebdc8007796)

##### 📌 Burası Bilim ve Business kategorilerine ait blogların listelendiği sayfalardır

-----------------------------------------------------------------------------------------------------------------------------------------
![Blog detay1](https://github.com/user-attachments/assets/dce3cd1d-3986-4d3b-8204-495d1705005d)
![blogdetay2](https://github.com/user-attachments/assets/ed946a4d-16fe-40e5-84c2-30a65564f041)

##### 📌 Burası Bilim kategorisine ait bir blog'un detay sayfasıdır.

-----------------------------------------------------------------------------------------------------------------------------------------
#### Admin Tarafı

![Admin Dashboard istatistik](https://github.com/user-attachments/assets/c567b41b-3526-44ee-a6c5-92ce03e2f8cb)
##### 📌 Proje kapsamında, API tarafında özelleştirilmiş metodlar kullanılarak blogların sayıları, tüm kategorilerin sayıları ve yalnızca aktif olan kategorilerin sayıları gibi özel bilgiler API tarafından tüketilmektedir.

##### 📌 Admin panelinde, kategorilerin kaç bloga sahip olduğu tablo halinde gösterilmektedir.

-----------------------------------------------------------------------------------------------------------------------------------------

![kategoriler](https://github.com/user-attachments/assets/278f5976-aa6e-4354-93a9-5c05b8501849)

![Admin Blog Satfası](https://github.com/user-attachments/assets/8832070b-bd82-4879-9158-69cac3cf0707)

![sanat kategorisi güncelleme](https://github.com/user-attachments/assets/1148c948-658d-4097-aad8-a69da9ad3d15)

![sıkça sorulan sorular](https://github.com/user-attachments/assets/ce825b11-8ed2-4d13-bc31-6035b6af2f06)

-----------------------------------------------------------------------------------------------------------------------------------------
![Admin dashboard yeni blog ekleme](https://github.com/user-attachments/assets/ac793a0b-e2f8-411e-92e7-d6aac5530ef9)

##### 📌 Admin panelinde, Yeni Blog ekleme 

-----------------------------------------------------------------------------------------------------------------------------------------
#### Api Tarafı
-----------------------------------------------------------------------------------------------------------------------------------------

![Api genel görünüm 1](https://github.com/user-attachments/assets/7d9928a7-38a0-4c00-a78f-4555e3db25d9)
![Api genel görünüm 2](https://github.com/user-attachments/assets/bbad168e-3829-4e11-b01c-00d888c5840c)

##### 📌 Api Katmanı Url Genel Görünüm
-----------------------------------------------------------------------------------------------------------------------------------------

![Api Blogları getirme ](https://github.com/user-attachments/assets/393e545e-a34e-4291-9650-b5f2435f5903)

##### 📌 Api Katmanı Blogları getirme
-----------------------------------------------------------------------------------------------------------------------------------------
![Api Toplam Blog Sayısı](https://github.com/user-attachments/assets/084fe18e-e944-40b2-8a5a-dbb85cd77fb2)

##### 📌 Api Katmanı Toplam Blog sayısı
-----------------------------------------------------------------------------------------------------------------------------------------

![Api Yeni Blog Ekleme](https://github.com/user-attachments/assets/c5ba0377-0768-43de-8439-1a1ae3d41c06)
![Api Blog Başarıyla Eklendi](https://github.com/user-attachments/assets/29237d26-d158-44ed-88d1-400510b22371)

##### 📌 Api Katmanı Yeni Blog Ekleme

-----------------------------------------------------------------------------------------------------------------------------------------

![Api 12 numaralı id'ye sahip blog silindi](https://github.com/user-attachments/assets/0aeb88be-e493-48da-8ece-af20f9cbe834)

##### 📌 Api Katmanı Blog Silme (12 numaralı id ye sahip blog'u sildik

-----------------------------------------------------------------------------------------------------------------------------------------

![Api Tüm kategorilerin sayısı](https://github.com/user-attachments/assets/22c63604-fd10-43db-8d62-22b1ad34bdd0)

##### 📌 Api Katmanı Tüm Kategorilerin sayısı (aktif ve pasif halde olan)

-----------------------------------------------------------------------------------------------------------------------------------------

![Api Aktif Olan kategori sayısı](https://github.com/user-attachments/assets/1713df8d-8917-47e4-8b8a-c3066616ef83)

##### 📌 Api Katmanı Aktif olan Kategorilerin sayısı

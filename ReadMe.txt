


1.Asp.Net Core Web Application'ý açýlýp Project Name'ine NightSword.Web, Solution Name'e ise NightSword adý verilerek Proje ismi ile Solution Name'lerinin karýþmasýnýn önüne geçilmiþtir.

2.Solution Üzerinde sað týklayýp Add New Project deyip bir Asp.Net Core kütüphanesi açýlýr.Adýna NightSword.Kernel olarak atama yapýlýr.Açýlan  class silinir.
	Not:Kernel kütüphanesinin açmamýzýn amacý:Burada herþey soyut olacak ve diðer tüm katmanlara kalýtým vereceðinden hepsi soyut olur.Çekirdek anlamýndadýr.
	2.1.NightSword.Kernel üzerinde sað týklayýp Entity Folder'ý açýlýr.Entity olmasýnýn sebebi Projemdeki bütün entity'lere buradan miras verecek olmam kaynaklanmaktadýr.
		2.1.1.Entity Dosyasý içerisine Abstract ve Concrete adýnda iki klasör daha açtýk.
			2.1.1.Abstract Class'i içerisine Interface class açýlýp gerekli kodlar yazýlýr.
			2.1.2.Concrete Klasörü içerisine KernelEntity adýnda class açýlýr ve IEntity'den kalýtým alýnýr.
	2.2.NightSword.Kernel Library üzerinde sað týklayýp Add new Folder deyip Enums Klasörü açýlýr ve içerisine enum classlarý yazýlýr.
	2.3.NightSword.Kernel Library üzerinde sað týklayýp Add new Folder deyip Mapping Klasörü açýlýr ve içerisine IKernelMap class'ý açýlýr.Projemdeki diðer tüm entitylerimi map'lerken buradaki configurasyondan yararlanýcaz hemde Kernel Entity'i maplicez.Ayrýca burada yarattýðýmýz metodu override edicez.
		2.3.1.KernelMap sýnýfýn IEntityTypeConfiguration ile extend etmek için Microsoft.EntityFrameworkCore'u yüklememiz gerektiðinden bu library' Nuget Packages'dan indirilir.
	2.4.NightSword.Kernel Library üzerinde sað týklayýp Add new Folder deyip Repository Klasörü açýlýr.
		2.4.1.Repository klasörü içerisine Abstract adýnda folder açýlýr.
			2.4.1.1.Abstract folder içerisine IKernelRepository adýnda Interface classý açýlýr.Ýlgili Metodlar yazýlýr.

3. Asp .Net Core Library (NightSword.Entities) açýlýr.
	3.1. Bu katmanýn dll'lerine "Kernel" katmaný eklenir.
	3.2. Microsoft.Extensions.Identity.Stores package yüklenir. (Bu pakete "IdentityUser" için ihtiyaç duyuyoruz.)
	3.3. Entity klsörü aluþturulur.
		3.3.1. Bu klasör altýna proje içerisinde ihtiyaç duyduðumuz yada duyacaðýmýz entity'ler database tercihimize göre yaratýlýr. (Bu projede Relational Database kullandýðýmýz için entity'ler arasýnda iliþkiler kurulmuþtur.)	
	

4. Asp .Net Core Library (NightSword.Map) katmaný eklenir. 
	4.1. Bu katmanýn dll'lerine "Entities & Kernel" katmanlarýnýn dll'leri eklenir.
	4.2. Mapping klasoru açýlýr.
		4.2.1. Entities klasoru açýlýr.
			4.2.1.1. Bu klasor altýnda projemizde kullandýðýmýz entit'lerin mapping islemleri yürütülür. (Bu islem esnasýnda dikkat etmeniz gereken nokta, "Kernel katmanýnda bulunan KernelMap.cs içerisinde oluþturduðumuz ve orada virtuall olarak iþaretlediðimiz metodu override ederek iþlemler yürütülür.")


5.Solution Üzerinde sað týklayýp Add New Project deyip bir asp.net.core kütüphanesi açýlýr.Adýna (NightSword.DataAccess) olarak atama yapýlýr.Açýlan class silinir.
	5.1.NightSword.DataAccess içerisine Context Dosyasý açýlýr.
		5.1.1.Ýçerisine ApplicationDbContext adýnda Class Açýlýr.Bu class benm Db olan baðlantýmdýr DbContext ile extend etmemiz gerektiði için öncelikle proje içerisine Microsoft.EntityFrameworkCore.SqlServer'ý kurmam gerekir.Daha sonra gerekli iþlemler yapýlýr.
	5.2.ApplicationDbContext sýnýfý içerisinde gerekli iþlemler yapýldýktan sonra middleware'a eklenir.services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));Ancak AddDbContext'e ulaþabilmemiz için Projeye Microsoft.EntityFrameworkCore.SqlServer' eklememiz gerekiyor.Ayrýca ApplicationDbContext icin  referanslara eklenir.

	5.3.Startup.cs'te iþlemimiz tamamladýktan sonra appsettings.json da ConnectionString'imiz yazýlýr. Aþaðýdaki gibi
"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NSProjectDB;Trusted_Connection=True;MultipleActiveResultSets=True" }.Burda önemli olan Not:Belirtmiþ oldugumuz Database ismi ile ayný database'i oluþturlmasý önemli aksi halde program database ile baðlantý kuramaz.

	5.4. Repository klasörü açýlýr.
		5.4.1. KernelRepository kalsörü açýlýr.
			5.4.1.1. Concrete klasörü açýlýr.
				5.4.1.1.1. EfKernelRepository.cs açýlýr. (Bu sýnýf içerisinde, Kernel katmanýnda bulunan IKernelRepository arayüzü içerisinde barýndýrdýðýmýz metotlarýmýza yetenekleri kazandýrýlýr.)
		5.4.2. Abstract klasörü açýlýr.
			5.4.2.1. Bu klasör içerisinde bütün entity'ler için tek tek arayüzler hazýrlanýr. (Hazýrlanan bu interface'ler IKernelRepository<T> arayüzünden kalýtým alýr.)
		5.4.3. Concrete klasörü açýlýr.
			5.4.3.1. Abstract klasörü altýnca topladýðýmýz arayüzlerin somutlaþtýrýlma iþlemleri yürütülür. (Bu iþlem esnasýnda yaratýlan somut sýnýflar EfKernelRepository<T>, EntityNameRepository sýnýflarýndan miras alýr. Ayrýca bu sýnýfa dýþarýdan gelecek bir istek doðrultusunda gelen isteði DbContext sýnýfýmaza atacaktýr. Not: Constructor metodu inceleyiniz.)
			  Not:Bu Repository'i ayrý bir katmanda da yazabilirdim.Ancak bu katmanýn içerisinde oluþturmamýzýn sebebi referanslarý minumuma indirmek.
	 5.5.Seeding Klasoru acilir.
		5.5.2.SeedData sinifi acilir.Bunun sebebi Database olusturarak test amacýyla elimizde hazýr verilerin bulunmasýdýr.
		5.5.3 Program.cs'e gelinip SeedData class'ýný Initialize ederiz.
		var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            host.Run();
        }


6.Solution Üzerinde sað týklayýp Add new Project deyip yeni bir  asp.net.core kütüphanesi açýlýp NightSword.Associate olarak isimlendirilir.Gelen boþ class silinir.Bu katman Dtos,Helper ve VMs'lerimizi barýndýrdýðýmýz katmandýr.
	6.1. Ýlk olarak Automapper'ý bu katmanda barýndýracaðýmýz için Katmana AutoMapper indirilir.Ancak AutoMapper.Extensions.Microsoft.DependdencyInjection bu katmana indirilmesi gerekmiyor .(bunu Web proje kýsmýnda yapýcaz) çünkü  Injection bu katmanda yapýlmayacak. Core mantýðýna görede zaten ihtiyaç duyulmayan paketin tamamýný indirmeye gerek yok.
	6.2.Katman içerisine new folder ekleyip  Dto olarak Dtolarýmý barýndýracagým klasor acýlýr.
		6.2.1.EntityNameDto class'larý açýlýr.Properties'ler eklenir.
	 6.3.Katman içerisine new folder ekleyip  VMs olarak  klasor acýlýr.Proje Büyüdükçe ihtiyaç duyulacaðýndan Vm classlarý acilir.
	    6.3.1.Katman içerisine new folder ekleyip  Helper olarak adlandýrýlýr ve ihtiyaç duydukça helper classlarý acýlýr.

7.Solution Üzerinde sað týklayýp Add new Project deyip yeni bir  asp.net.core kütüphanesi açýlýp NightSword.Business olarak isimlendirilir.Gelen boþ class silinir.
	7.1.Katman üzerinde sað týklayýp add new file deyip AutoMapper dosyasi açilir.
		7.1.1.AutoMapping class'ý açýlýr.Bu sýnýf Profile'dan kalýtým alacaðýndan katmana Automapper indirilir.
	7.2.Oluþturduðum AutoMapper'ýmý Startup.cs'e eklemememiz gerekiyor bu aþamada.Burada Injection iþlemi yapýlacaðýndan Web projesine AutoMapper.Extensions.Microsoft.DependdencyInjection indirilir.Ayrýca Business katmanýda Referanslara eklenir.

	  var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            var mapper = config.CreateMapper();
            services.AddAutoMapper(typeof(Startup)); yada klasik sekilde yani services.AddAutoMapper(typeof(AutoMapping)); sekildede eklenebilir.


	7.3.Business Katmani üzerinde sag tiklayip add new file deyip Logger dosyasi açilir.
		7.3.1.LoggerKlasörü içerisine SystemLogger class'i açilir.Bu class içerisinde   IWebHostEnvironment'a ulaþabilmek için Projeye Microsoft.AspNetCore.Hosting indirilir.
		7.3.2.LoggerKlasörü içerisine LoggerProvider class'i açilir
	7.4.Business Katmani üzerinde sag tiklayip add new file deyip UnitofWork dosyasi açilir.
		7.4.1.Abstract file açýlýr.
			11.4.1.1.Abstract File içerisine Interface Class'i acilir ve IUnitOfWork olarak isimlendirilir.Zamaný geldikçe yani entity artýkça buradan miras alacak.
		7.4.2.Concrete File'ý Acilir.
			11.4.2.1 Concrete Klasörü içerisine EfUnitOfWork class'ý açýlýr.Ve IUnitofWork Interface'inden kalýtým alýr.
	7.5.Business Katmani üzerinde sag tiklayip add new file deyip Services dosyasi açilir.Bu Klasor UnitOfWork implimantation'nýn son asamasýdýr.
			7.5.1.Services klasoru icerisine Abstract Klasoru acýlýr.
				7.5.1.1.Abstract Klasorunun icerisine Interface class'i açilir.I(EntityName)Service adýnda.Herbir Entity için tek tek yapýlýr.
			7.5.2.Services klasoru icerisine Concrete Klasoru acýlýr.
				7.5.2.1.Concrete Klasoru icerisine (EntityName)Service class'i acilir ve I(EntityName)Repository'den kalýtým alýr.Gerekli Crud islemleri yapilir.
			7.6.3.Service katmanýndaki dependncy injectionslar startup.cs' eklenir.
			     services.AddScoped<IUnitOfWork, EfUnitOfWork>();
                 services.AddScoped<ICategoryService, CategoryService>();
                 services.AddScoped<IPageService, PageService>();

	7.6.Business Katmani üzerinde sag tiklayip add new file deyip Validation dosyasi açilir.
		7.6.1.Validation klasoru icerisine EntitiesValidation klasoru acilir.
			7.6.1.1.EntitiesValidation klasoru icerisine (EntityName)Validation classý acilir.Paketlerden FluentValidation.AspNetCore indirilir sebebi ise AbstractValidator ile class'ýmýzý extent etmek için.Olusacak olan her entity için yeniden eklenir.
		7.6.2.Validation klasoru icerisine ErrorResult klasoru acilir.
			7.6.2.1.ErrorResult klasoru icerisine ErrorModel classý acilir.Model alacagim class.
			7.6.2.2.ErrorResult klasoru icerisine ErrorResponse classý acilir.Ve Error Modelimin tipinde Error Listesi olustururuz.
	

	  





		
Not 1 : Yeni bir Entity girildiðinde Sýralý olarak Katmanlar Arasý Ýliþkiyi Özetlersek;

	1.Kernel Katmanýna Tekrar dokunmamýza gerek yok
	2.Entity Katmaný
	3.Mapping Katmaný
	4.DataAccess Katmaný(ApplicationDbContex'de Configure edilir Map'leme islemi. Ve Tablo Olarak ayaga kalkmasi icin Db Set edilir.)
	5.DataAccess Katmaný icerisindeki Repository Klasoru altinda Abstract ve Concreteleri olusturulur.
	6.Assosiate Katmanýnda 
	7.Business Katmaný	(UnitOfWork islemleri halledilir.Abstract ve Concrete olarak.)
	No:Gerekli Relationslar Web Projesinde Startup.cs'de belirtilir.

Not 2:UNÝT OF WORK DESÝGN PATTERN:

UnitofWork Design Pattern Nedir?
Bu pattern, iþ katmanýnda yapýlan her deðiþikliðin anlýk olarak database e yansýmasý yerine, iþlemlerin toplu halde tek bir kanaldan gerçekleþmesini saðlar.

Neden UnitofWork?

Bir e-ticaret sitesini düþünelim.Bir ürün satýn alma aþamasýnda birden fazla aþama vardýr.Sepetteki ürünlerinize göre ekstra ürün eklemek isteyeceðiniz bir sayfa, sonra kart bilgilerini gireceðiniz bir sayfa, en son alýþveriþi tamamlayacaðýnýz bir sayfa olur.Bu aþamalarýn her birinde database e kayýt atmak yerine, en son satýn alma aþamasýnda bu girilen kayýtlarýn toplu halde database e aktarýmý hem performans, hemde saðlýklý data açýsýndan önemli olacaktýr.Çünkü son aþamaya gelindiðinde satýn almadan vazgeçilmesi halinde önceki aþamalarda oluþan datalar dummy data olarak database’de ekstra yer iþgal edecektir.
Bu ve bunun gibi, birden fazla iþlemi tek bir iþlem olarak düþünmemiz gereken yerlerde bu design pattern’i kullanabiliriz.
Ýþlemler tek bir kanaldan(tek bir transaction) toplu halde yapýldýðý için performansý artý yönde etkileyecektir.Ayrýca iþlemleri geri alma(rollback), hangi tabloda ne iþlem yapýldý kaç kayýt eklendi gibi sorulara da cevap verebilir.

Nasýl Kullanýlýr?
UnitofWork genelde repository pattern ile uygulanýr.Ýlgili Kod Bloklarýný Business Katmaný icerisindeki UnitOfWork Klasoru icerisinde gorebilirsiniz.

Not 3:IQuarable ile IEnurable arasýndaki fark:

-IQuarable oluþturulan filtreye göre önce filtreleme yapýyor örneðin aktif verileri listelemek istedigimde   linq to gidiyor daha SQL'deyken filtreleme yapýyor ve benim istediðim listeyi yani aktif kullanýcýlarý Ram'e Çýkarýyor.
2.Fark ise olusturduðu listeyi oluþturup bekletiyor bu yüzden sonuna ToList() beklemez ve ben istediðim zaman çekebiliyorum.
-IEnurable bu sorgulamayý yaptýgýmda ise kullanýcýlarýn tamamýný Ram'e gereksiz yere cýkarýp sonra sorgulamayý yapýp bana döndürüyor.

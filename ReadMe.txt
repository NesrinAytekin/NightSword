


1.Asp.Net Core Web Application'� a��l�p Project Name'ine NightSword.Web, Solution Name'e ise NightSword ad� verilerek Proje ismi ile Solution Name'lerinin kar��mas�n�n �n�ne ge�ilmi�tir.

2.Solution �zerinde sa� t�klay�p Add New Project deyip bir Asp.Net Core k�t�phanesi a��l�r.Ad�na NightSword.Kernel olarak atama yap�l�r.A��lan  class silinir.
	Not:Kernel k�t�phanesinin a�mam�z�n amac�:Burada her�ey soyut olacak ve di�er t�m katmanlara kal�t�m verece�inden hepsi soyut olur.�ekirdek anlam�ndad�r.
	2.1.NightSword.Kernel �zerinde sa� t�klay�p Entity Folder'� a��l�r.Entity olmas�n�n sebebi Projemdeki b�t�n entity'lere buradan miras verecek olmam kaynaklanmaktad�r.
		2.1.1.Entity Dosyas� i�erisine Abstract ve Concrete ad�nda iki klas�r daha a�t�k.
			2.1.1.Abstract Class'i i�erisine Interface class a��l�p gerekli kodlar yaz�l�r.
			2.1.2.Concrete Klas�r� i�erisine KernelEntity ad�nda class a��l�r ve IEntity'den kal�t�m al�n�r.
	2.2.NightSword.Kernel Library �zerinde sa� t�klay�p Add new Folder deyip Enums Klas�r� a��l�r ve i�erisine enum classlar� yaz�l�r.
	2.3.NightSword.Kernel Library �zerinde sa� t�klay�p Add new Folder deyip Mapping Klas�r� a��l�r ve i�erisine IKernelMap class'� a��l�r.Projemdeki di�er t�m entitylerimi map'lerken buradaki configurasyondan yararlan�caz hemde Kernel Entity'i maplicez.Ayr�ca burada yaratt���m�z metodu override edicez.
		2.3.1.KernelMap s�n�f�n IEntityTypeConfiguration ile extend etmek i�in Microsoft.EntityFrameworkCore'u y�klememiz gerekti�inden bu library' Nuget Packages'dan indirilir.
	2.4.NightSword.Kernel Library �zerinde sa� t�klay�p Add new Folder deyip Repository Klas�r� a��l�r.
		2.4.1.Repository klas�r� i�erisine Abstract ad�nda folder a��l�r.
			2.4.1.1.Abstract folder i�erisine IKernelRepository ad�nda Interface class� a��l�r.�lgili Metodlar yaz�l�r.

3. Asp .Net Core Library (NightSword.Entities) a��l�r.
	3.1. Bu katman�n dll'lerine "Kernel" katman� eklenir.
	3.2. Microsoft.Extensions.Identity.Stores package y�klenir. (Bu pakete "IdentityUser" i�in ihtiya� duyuyoruz.)
	3.3. Entity kls�r� alu�turulur.
		3.3.1. Bu klas�r alt�na proje i�erisinde ihtiya� duydu�umuz yada duyaca��m�z entity'ler database tercihimize g�re yarat�l�r. (Bu projede Relational Database kulland���m�z i�in entity'ler aras�nda ili�kiler kurulmu�tur.)	
	

4. Asp .Net Core Library (NightSword.Map) katman� eklenir. 
	4.1. Bu katman�n dll'lerine "Entities & Kernel" katmanlar�n�n dll'leri eklenir.
	4.2. Mapping klasoru a��l�r.
		4.2.1. Entities klasoru a��l�r.
			4.2.1.1. Bu klasor alt�nda projemizde kulland���m�z entit'lerin mapping islemleri y�r�t�l�r. (Bu islem esnas�nda dikkat etmeniz gereken nokta, "Kernel katman�nda bulunan KernelMap.cs i�erisinde olu�turdu�umuz ve orada virtuall olarak i�aretledi�imiz metodu override ederek i�lemler y�r�t�l�r.")


5.Solution �zerinde sa� t�klay�p Add New Project deyip bir asp.net.core k�t�phanesi a��l�r.Ad�na (NightSword.DataAccess) olarak atama yap�l�r.A��lan class silinir.
	5.1.NightSword.DataAccess i�erisine Context Dosyas� a��l�r.
		5.1.1.��erisine ApplicationDbContext ad�nda Class A��l�r.Bu class benm Db olan ba�lant�md�r DbContext ile extend etmemiz gerekti�i i�in �ncelikle proje i�erisine Microsoft.EntityFrameworkCore.SqlServer'� kurmam gerekir.Daha sonra gerekli i�lemler yap�l�r.
	5.2.ApplicationDbContext s�n�f� i�erisinde gerekli i�lemler yap�ld�ktan sonra middleware'a eklenir.services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));Ancak AddDbContext'e ula�abilmemiz i�in Projeye Microsoft.EntityFrameworkCore.SqlServer' eklememiz gerekiyor.Ayr�ca ApplicationDbContext icin  referanslara eklenir.

	5.3.Startup.cs'te i�lemimiz tamamlad�ktan sonra appsettings.json da ConnectionString'imiz yaz�l�r. A�a��daki gibi
"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NSProjectDB;Trusted_Connection=True;MultipleActiveResultSets=True" }.Burda �nemli olan Not:Belirtmi� oldugumuz Database ismi ile ayn� database'i olu�turlmas� �nemli aksi halde program database ile ba�lant� kuramaz.

	5.4. Repository klas�r� a��l�r.
		5.4.1. KernelRepository kals�r� a��l�r.
			5.4.1.1. Concrete klas�r� a��l�r.
				5.4.1.1.1. EfKernelRepository.cs a��l�r. (Bu s�n�f i�erisinde, Kernel katman�nda bulunan IKernelRepository aray�z� i�erisinde bar�nd�rd���m�z metotlar�m�za yetenekleri kazand�r�l�r.)
		5.4.2. Abstract klas�r� a��l�r.
			5.4.2.1. Bu klas�r i�erisinde b�t�n entity'ler i�in tek tek aray�zler haz�rlan�r. (Haz�rlanan bu interface'ler IKernelRepository<T> aray�z�nden kal�t�m al�r.)
		5.4.3. Concrete klas�r� a��l�r.
			5.4.3.1. Abstract klas�r� alt�nca toplad���m�z aray�zlerin somutla�t�r�lma i�lemleri y�r�t�l�r. (Bu i�lem esnas�nda yarat�lan somut s�n�flar EfKernelRepository<T>, EntityNameRepository s�n�flar�ndan miras al�r. Ayr�ca bu s�n�fa d��ar�dan gelecek bir istek do�rultusunda gelen iste�i DbContext s�n�f�maza atacakt�r. Not: Constructor metodu inceleyiniz.)
			  Not:Bu Repository'i ayr� bir katmanda da yazabilirdim.Ancak bu katman�n i�erisinde olu�turmam�z�n sebebi referanslar� minumuma indirmek.
	 5.5.Seeding Klasoru acilir.
		5.5.2.SeedData sinifi acilir.Bunun sebebi Database olusturarak test amac�yla elimizde haz�r verilerin bulunmas�d�r.
		5.5.3 Program.cs'e gelinip SeedData class'�n� Initialize ederiz.
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


6.Solution �zerinde sa� t�klay�p Add new Project deyip yeni bir  asp.net.core k�t�phanesi a��l�p NightSword.Associate olarak isimlendirilir.Gelen bo� class silinir.Bu katman Dtos,Helper ve VMs'lerimizi bar�nd�rd���m�z katmand�r.
	6.1. �lk olarak Automapper'� bu katmanda bar�nd�raca��m�z i�in Katmana AutoMapper indirilir.Ancak AutoMapper.Extensions.Microsoft.DependdencyInjection bu katmana indirilmesi gerekmiyor .(bunu Web proje k�sm�nda yap�caz) ��nk�  Injection bu katmanda yap�lmayacak. Core mant���na g�rede zaten ihtiya� duyulmayan paketin tamam�n� indirmeye gerek yok.
	6.2.Katman i�erisine new folder ekleyip  Dto olarak Dtolar�m� bar�nd�racag�m klasor ac�l�r.
		6.2.1.EntityNameDto class'lar� a��l�r.Properties'ler eklenir.
	 6.3.Katman i�erisine new folder ekleyip  VMs olarak  klasor ac�l�r.Proje B�y�d�k�e ihtiya� duyulaca��ndan Vm classlar� acilir.
	    6.3.1.Katman i�erisine new folder ekleyip  Helper olarak adland�r�l�r ve ihtiya� duyduk�a helper classlar� ac�l�r.

7.Solution �zerinde sa� t�klay�p Add new Project deyip yeni bir  asp.net.core k�t�phanesi a��l�p NightSword.Business olarak isimlendirilir.Gelen bo� class silinir.
	7.1.Katman �zerinde sa� t�klay�p add new file deyip AutoMapper dosyasi a�ilir.
		7.1.1.AutoMapping class'� a��l�r.Bu s�n�f Profile'dan kal�t�m alaca��ndan katmana Automapper indirilir.
	7.2.Olu�turdu�um AutoMapper'�m� Startup.cs'e eklemememiz gerekiyor bu a�amada.Burada Injection i�lemi yap�laca��ndan Web projesine AutoMapper.Extensions.Microsoft.DependdencyInjection indirilir.Ayr�ca Business katman�da Referanslara eklenir.

	  var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            var mapper = config.CreateMapper();
            services.AddAutoMapper(typeof(Startup)); yada klasik sekilde yani services.AddAutoMapper(typeof(AutoMapping)); sekildede eklenebilir.


	7.3.Business Katmani �zerinde sag tiklayip add new file deyip Logger dosyasi a�ilir.
		7.3.1.LoggerKlas�r� i�erisine SystemLogger class'i a�ilir.Bu class i�erisinde   IWebHostEnvironment'a ula�abilmek i�in Projeye Microsoft.AspNetCore.Hosting indirilir.
		7.3.2.LoggerKlas�r� i�erisine LoggerProvider class'i a�ilir
	7.4.Business Katmani �zerinde sag tiklayip add new file deyip UnitofWork dosyasi a�ilir.
		7.4.1.Abstract file a��l�r.
			11.4.1.1.Abstract File i�erisine Interface Class'i acilir ve IUnitOfWork olarak isimlendirilir.Zaman� geldik�e yani entity art�k�a buradan miras alacak.
		7.4.2.Concrete File'� Acilir.
			11.4.2.1 Concrete Klas�r� i�erisine EfUnitOfWork class'� a��l�r.Ve IUnitofWork Interface'inden kal�t�m al�r.
	7.5.Business Katmani �zerinde sag tiklayip add new file deyip Services dosyasi a�ilir.Bu Klasor UnitOfWork implimantation'n�n son asamas�d�r.
			7.5.1.Services klasoru icerisine Abstract Klasoru ac�l�r.
				7.5.1.1.Abstract Klasorunun icerisine Interface class'i a�ilir.I(EntityName)Service ad�nda.Herbir Entity i�in tek tek yap�l�r.
			7.5.2.Services klasoru icerisine Concrete Klasoru ac�l�r.
				7.5.2.1.Concrete Klasoru icerisine (EntityName)Service class'i acilir ve I(EntityName)Repository'den kal�t�m al�r.Gerekli Crud islemleri yapilir.
			7.6.3.Service katman�ndaki dependncy injectionslar startup.cs' eklenir.
			     services.AddScoped<IUnitOfWork, EfUnitOfWork>();
                 services.AddScoped<ICategoryService, CategoryService>();
                 services.AddScoped<IPageService, PageService>();

	7.6.Business Katmani �zerinde sag tiklayip add new file deyip Validation dosyasi a�ilir.
		7.6.1.Validation klasoru icerisine EntitiesValidation klasoru acilir.
			7.6.1.1.EntitiesValidation klasoru icerisine (EntityName)Validation class� acilir.Paketlerden FluentValidation.AspNetCore indirilir sebebi ise AbstractValidator ile class'�m�z� extent etmek i�in.Olusacak olan her entity i�in yeniden eklenir.
		7.6.2.Validation klasoru icerisine ErrorResult klasoru acilir.
			7.6.2.1.ErrorResult klasoru icerisine ErrorModel class� acilir.Model alacagim class.
			7.6.2.2.ErrorResult klasoru icerisine ErrorResponse class� acilir.Ve Error Modelimin tipinde Error Listesi olustururuz.
	

	  





		
Not 1 : Yeni bir Entity girildi�inde S�ral� olarak Katmanlar Aras� �li�kiyi �zetlersek;

	1.Kernel Katman�na Tekrar dokunmam�za gerek yok
	2.Entity Katman�
	3.Mapping Katman�
	4.DataAccess Katman�(ApplicationDbContex'de Configure edilir Map'leme islemi. Ve Tablo Olarak ayaga kalkmasi icin Db Set edilir.)
	5.DataAccess Katman� icerisindeki Repository Klasoru altinda Abstract ve Concreteleri olusturulur.
	6.Assosiate Katman�nda 
	7.Business Katman�	(UnitOfWork islemleri halledilir.Abstract ve Concrete olarak.)
	No:Gerekli Relationslar Web Projesinde Startup.cs'de belirtilir.

Not 2:UN�T OF WORK DES�GN PATTERN:

UnitofWork Design Pattern Nedir?
Bu pattern, i� katman�nda yap�lan her de�i�ikli�in anl�k olarak database e yans�mas� yerine, i�lemlerin toplu halde tek bir kanaldan ger�ekle�mesini sa�lar.

Neden UnitofWork?

Bir e-ticaret sitesini d���nelim.Bir �r�n sat�n alma a�amas�nda birden fazla a�ama vard�r.Sepetteki �r�nlerinize g�re ekstra �r�n eklemek isteyece�iniz bir sayfa, sonra kart bilgilerini girece�iniz bir sayfa, en son al��veri�i tamamlayaca��n�z bir sayfa olur.Bu a�amalar�n her birinde database e kay�t atmak yerine, en son sat�n alma a�amas�nda bu girilen kay�tlar�n toplu halde database e aktar�m� hem performans, hemde sa�l�kl� data a��s�ndan �nemli olacakt�r.��nk� son a�amaya gelindi�inde sat�n almadan vazge�ilmesi halinde �nceki a�amalarda olu�an datalar dummy data olarak database�de ekstra yer i�gal edecektir.
Bu ve bunun gibi, birden fazla i�lemi tek bir i�lem olarak d���nmemiz gereken yerlerde bu design pattern�i kullanabiliriz.
��lemler tek bir kanaldan(tek bir transaction) toplu halde yap�ld��� i�in performans� art� y�nde etkileyecektir.Ayr�ca i�lemleri geri alma(rollback), hangi tabloda ne i�lem yap�ld� ka� kay�t eklendi gibi sorulara da cevap verebilir.

Nas�l Kullan�l�r?
UnitofWork genelde repository pattern ile uygulan�r.�lgili Kod Bloklar�n� Business Katman� icerisindeki UnitOfWork Klasoru icerisinde gorebilirsiniz.

Not 3:IQuarable ile IEnurable aras�ndaki fark:

-IQuarable olu�turulan filtreye g�re �nce filtreleme yap�yor �rne�in aktif verileri listelemek istedigimde   linq to gidiyor daha SQL'deyken filtreleme yap�yor ve benim istedi�im listeyi yani aktif kullan�c�lar� Ram'e ��kar�yor.
2.Fark ise olusturdu�u listeyi olu�turup bekletiyor bu y�zden sonuna ToList() beklemez ve ben istedi�im zaman �ekebiliyorum.
-IEnurable bu sorgulamay� yapt�g�mda ise kullan�c�lar�n tamam�n� Ram'e gereksiz yere c�kar�p sonra sorgulamay� yap�p bana d�nd�r�yor.

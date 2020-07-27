using AutoMapper;
using NightSword.Associate.Dtos;
using NightSword.Entities.Entity;


namespace NightSword.Business.AutoMapper
{
   public class AutoMapping:Profile //AutoMapper kurmamız gerekir Profile'a ulasabilmemiz icin ama sorun değil Assosiate katmanınında AutoMapper'ı indirmistik ol yuzden Assosiated katmanının dll'lerini Business katmanına eklersek yani referanslarına eklersek AutoMapper'a ulasmıs oluruz yada bu katmanda tekrar indirme islemi yapılabilir.
    {
        

        public AutoMapping()
        {
            //Projeye dair bütün entity'ler burada mapping edilecek.


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
//Bu asamadan sonra AutoMapper'ı Startup.cs'eklememiz gerekiyor.
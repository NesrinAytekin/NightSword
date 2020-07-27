using Microsoft.AspNetCore.Identity;
using NightSword.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Entities.Entity
{
    //IdentityUser ile extend edebilmemiz icin EntityFramework.Identity yüklememiz gerekir

    //Biz clasik .Net 'te appuser'la alakalı herseyi buraya kendimiz yazıyorduk ama core sayesinde AppUser 'u IdentityUser ile extend ettiğimizde biz bu şekilde herşey hazır user propertylerini sağladıgı gibi aşagıdaki gibi meslek yani Occupation gibi özel istediğimiz property'leride ekleyebiliriz.Bunu tamamladıktan sonra Context'te migrations işlemini yapıyoruz.

    //Biz burada bir yapı oluşturduk ama AppUser'a dokunmuyoruz burada herşeyi User'ı model alarak işlem yapıyoruz.
    public class AppUser:IdentityUser
    {
        //IdentityUser sınıfımızı IdentityUser ile extend ettiğimizde,kalıtım vasıtasıyla IdentityUser'ın yetenek ve özelliklerini elde etmiş oluyoruz.Lakin IdentitiyUser'ın içermediği özellikleri aşağıda  görüldüğü gibi ekleyebiliriz. 
        public string Occupation { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace NightSword.Associate.Helpers
{
   public class FileExtension : ValidationAttribute //ValidationAttribute'den kalıtım alır 
    {
        //Daha sonra kalıtım aldıgım classdan bir Attribute'ü ezicez yani override edicez.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Biz burada kendi custom Attribute yazdık aynı sekilde custom validationResult'da yazabiliriz.ÖNEMLİ
            var file = value as IFormFile;//Bu şekilde IFormFile yerine  file demem yeterli olacak.

            if (file != null)//Eğer bu file null yani boş değilse
            {
                var extension = Path.GetExtension(file.FileName);//Path.GetExtension=Path yani system İo'dan Uzantıyı al ve benm yukarıda tanımladığım ve IFormFile anlamına gelen file'ın ismine bu uzantıyı ekle diyoruz.


                string[] extensions = { ".jpg", ".png", ".jpeg" };//String tipte adı extensions olan bir dizi oluşturuyoruz ve uzantısını kabul ettiğim uzantı isimlerini yazıyorum.
                bool result = extensions.Any(x => x.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Alowed extension are .jpg, .png, and .jpeg");//Ve sadece bu uzantılarda resmi kaydedeceğini söyleyen bir error mesajı döndür diyorum.
                }
            }

            return ValidationResult.Success;
        }
    }
}

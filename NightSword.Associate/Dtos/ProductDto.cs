using Microsoft.AspNetCore.Http;
using NightSword.Associate.Helpers;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NightSword.Associate.Dtos
{
    public class ProductDto:BaseDto
    {
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [NotMapped]//Tabloda ayağa kalkma sutun olarak diyorum bu Attribute ile
        [FileExtension]// FileExtension'ı biz yazdık.Assosiate Katmanında Helpers klasörü içerisine FileExtension adında bir class açtık orada bu attribute biz yazdık
        public IFormFile ImageUpload { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = " Choose a Category")]//Min Değeri 1 ve int'rın max değerine kadar değer alabilir kullanıcı bir category seçmezse error mesajı vermesi için
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using NightSword.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NightSword.Entities.Entity
{
    public class Product:KernelEntity
    {
        
        public string Name { get; set; }
        public string Slug { get; set; }    
        public string Description { get; set; }       
        public decimal Price { get; set; }
        public string Image { get; set; }

        [NotMapped]//Tabloda ayağa kalkma sutun olarak diyorum bu Attribute ile
        public IFormFile ImageUpload { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

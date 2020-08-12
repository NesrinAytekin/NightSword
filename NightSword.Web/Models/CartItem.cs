using NightSword.Associate.Dtos;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightSword.Web.Models
{

    //Bu class BaseEntity 'den kalıtım almayacak bu yüzden kendine ait Id'si olmayacak aynı command gibi .En son sept onaylama işleminde Db'ye göndereceğiz.Aksi halde her ürün ekleyenin bilgileri Db'ye gitse Db şişer. Db Set işlemlerini tabi tutulmayacak Client side tarafı için yapıcaz.
    public class CartItem//Sepetteki veriler nelerse o property'leri ekliyoruz.
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
        public string Image { get; set; }

        public CartItem()
        { }

        //Bu Contractor metodu ikikere yaptık.1. Constractor Alma işlemini ikincisi ise Atama işlemlerini gerçekleştirecek.
        public CartItem(ProductDto product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
        }
    }
}

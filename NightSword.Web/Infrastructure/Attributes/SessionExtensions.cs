using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightSword.Web.Infrastructure.Attributes
{
    public static class SessionExtensions
    {

        //Amacımız bizim burada sepete dinamik olarak ürün ekleme çıkarma silme işlemlerini yapmak aynı like command yaptıgımız gibi
        public static void SetJson(this ISession session, string key, object value)
        {
            //Web ortamında harici kaynaklarda , aynı yada farklı cihazlar arasında konuşmasını sağlayan formattır Json.O yüzden burada 2 method olusturulacak birincisi Get işlemini ikincisi ise set işlemini gerçekleştirecek.

            session.SetString(key, JsonConvert.SerializeObject(value));

            //Serialize:.Net'teki objemi yani buradaki value'yu Json tipine dönüştürüyor(convert) ediyor.
        }

        public static T GetJson<T>(this ISession session, string key)//T GetJson : Buradki "T" Tipini belirtiyor herhangi bir tipte olabilir.2. "T" ise jenerik tipte oldugunu belirtiyor.
        {
            var sessionData = session.GetString(key);

            //sessionData' yı bana dön null olabilir dafault T Tipindeyse yada Json tipindeki veriyi .Net ortamına dönüştürüp bana geri dön diyoruz.

            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);// (:) =iki nokta else anlamındadır
        }
    }
}

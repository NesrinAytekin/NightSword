using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NightSword.DataAccess.Context;
using NightSword.Entities.Entity;
using NightSword.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightSword.DataAccess.Seeding
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Categories.Any() && context.Pages.Any())
                {
                    return;
                }
                context.Categories.AddRange(
                      new Category
                      {
                          Name = "Kadın",
                          Status = Status.Active,
                          Sorting = 5,
                          CreateDate = DateTime.Now,
                          CreatedIp = "123",
                          CreatedBy = "Admin",
                          CreatedComputerName = "Naytekin",



                      },
                      new Category
                      {
                          Name = "Erkek",
                          Status = Status.Active,
                          Sorting = 6,
                          CreateDate = DateTime.Now,
                          CreatedIp = "123",
                          CreatedBy = "Admin",
                          CreatedComputerName = "Naytekin",


                      }
                  );
                context.Pages.AddRange(
                   new Page //Instance alıp Page Sınıfından verileri ekliyoruz.
                   {
                       Title = "Home",
                       Slug = "home",
                       Content = "home Page",
                       Sorting = 0,
                       CreateDate = DateTime.Now,
                       CreatedIp = "123",
                       CreatedBy = "Admin",
                       CreatedComputerName = "Naytekin",
                   },
                   new Page
                   {
                       Title = "About Us",
                       Slug = "about-us",
                       Content = "about us page",
                       Sorting = 100,
                       CreateDate = DateTime.Now,
                       CreatedIp = "123",
                       CreatedBy = "Admin",
                       CreatedComputerName = "Naytekin",
                   },
                   new Page
                   {
                       Title = "Services",
                       Slug = "services",
                       Content = "services page",
                       Sorting = 100,
                       CreateDate = DateTime.Now,
                       CreatedIp = "123",
                       CreatedBy = "Admin",
                       CreatedComputerName = "Naytekin",
                   },
                   new Page
                   {
                       Title = "Contact",
                       Slug = "contact",
                       Content = "contact page",
                       Sorting = 100,
                       CreateDate = DateTime.Now,
                       CreatedIp = "123",
                       CreatedBy = "Admin",
                       CreatedComputerName = "Naytekin",
                   }
                   );


                context.SaveChanges();
                //Test Datası kullanmak istedigimiz her yerde tohumlama yani seedin işlemi yapılır.
                //Bu asamadan sonra Program.cs'e gidilip run edildiginde database eklenmiş olarak calıssın.

            }
        }
    }
}

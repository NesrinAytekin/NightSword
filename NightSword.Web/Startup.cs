using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NightSword.Associate.Dtos;
using NightSword.Business.AutoMapper;
using NightSword.Business.Services.Abstract;
using NightSword.Business.Services.Concrete;
using NightSword.Business.UnitofWork.Abstract;
using NightSword.Business.UnitofWork.Concrete;
using NightSword.Business.Validation.EntitiesValidation;
using NightSword.DataAccess.Context;
using NightSword.DataAccess.Repository.Abstract;
using NightSword.DataAccess.Repository.Concrete;

namespace NightSword.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
               .AddFluentValidation();
            services.AddTransient<IValidator<CategoryDto>, CategoryValidation>();
            services.AddTransient<IValidator<PageDto>, PageValidation>();
            services.AddTransient<IValidator<ProductDto>, ProductValidation>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IProductService, ProductService>();




            //============AutoMapper===========
            //AutoMapper.Extensions.Microsoft.DependcyInjection Paketi indirilir.Inject Edebilmemiz icin AutoMapper'ý
            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutoMapping());
            //});

            //var mapper = config.CreateMapper();
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapping));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   "page",
                   "{slug?}",
                   defaults: new { controller = "Page", action = "Page" });

                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using AppMVC01.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC01
{
    public class Startup
    {
        public static string ContentRootPath { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentRootPath = env.ContentRootPath;
            Console.WriteLine(ContentRootPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // dang ky vao ung dung dung cac dich vu de hoat dong theo mo hinh MVC
            services.AddRazorPages(); // dang ky vao he thong cac dich vu lien quan den trang Razor
            //services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); // Logger mac dinh da duoc tu dong dky nhu nay
            services.Configure<RazorViewEngineOptions>(options =>
            {
                // mac dinh tim duong dan  /View/Controller/Action.cshtml
                // tin them o duong dan /MyView/Controller/Action.cshtml

                //{0} --> ten Action
                //{1} --> ten Controller
                //{2} --> ten Area
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
            });


            services.AddSingleton<ProductServices, ProductServices>();
            //services.AddSingleton<ProductServices>();
            //services.AddSingleton(typeof(ProductServices), typeof(ProductServices));
            //services.AddSingleton(typeof(ProductServices));

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // xac dinh danh tinh
            app.UseAuthorization(); // xac thuc quyen truy cap

            app.UseEndpoints(endpoints =>
            {
                //ptich URL:/{controller/{action}/{id?}
                // URL : Abc/Xyz => Controller = Abc , goi method Xyz
                // Home/Index => khi truy cap URL ,khoi tao HomeController thi hanh method Index()
                endpoints.MapControllerRoute(
                    name: "default",// tren url ko chi {controller} hoac {action} thi mac dinh ko can
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //truy cap First/Index


                endpoints.MapRazorPages();
            }); // tao ra anh xa voi truy van co dia chi URL vao Controller tuong ung

            
        }
    }
}

using AppMVC01.ExtendMethods;
using AppMVC01.Models;
using AppMVC01.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            services.AddDbContext<AppDBContext>(options =>
            {
                string connectString = Configuration.GetConnectionString("AppMvcConnectString");
                options.UseSqlServer(connectString);
            }
               );

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

            //Dang ky Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<ProductServices, ProductServices>();
            //services.AddSingleton<ProductServices>();
            //services.AddSingleton(typeof(ProductServices), typeof(ProductServices));
            //services.AddSingleton(typeof(ProductServices));

            //Truy cập IdentityOptions
            services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
                options.SignIn.RequireConfirmedAccount = true;
            }

            );

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/login/";
                option.LogoutPath = "/logout";
                option.AccessDeniedPath = "/khongduoctruycap.html";
            });

            // dang ky xac thuc Dependenci injecttion 
            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    // Đọc thông tin Authentication:Google từ appsettings.json
                    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là https://localhost:5001/signin-google)
                    googleOptions.CallbackPath = "/dang-nhap-tu-google";

                })
                .AddFacebook(facebookOptions =>
                {
                    IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                    facebookOptions.AppId = facebookAuthNSection["AppId"];
                    facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                    facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
                });


            services.AddSingleton(typeof(PlanetService), typeof(PlanetService));

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
            app.AddStatusCodePage(); // phuong thuc mo rong , tuy bien responde loi tu 400 - 599
            app.UseRouting();

            app.UseAuthentication(); // xac dinh danh tinh
            app.UseAuthorization(); // xac thuc quyen truy cap

            app.UseEndpoints(endpoints =>
            {
                //ptich URL:/{controller/{action}/{id?}
                // URL : Abc/Xyz => Controller = Abc , goi method Xyz
                // Home/Index => khi truy cap URL ,khoi tao HomeController thi hanh method Index()
                //chi thuc hien tren controller ko co Area
                endpoints.MapControllerRoute(
                    name: "default",// tren url ko chi {controller} hoac {action} thi mac dinh ko can
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapAreaControllerRoute(
                    name :"product",
                    pattern: "/{controller=Home}/{action=Index}/{id?}",
                    areaName: "ProductManage"
                    );
                
                //URL = start-here/Ten Controller/Action/id
                //VD: url: star-here/First/HelloView
                //controller => 
                //action =>
                //area => 
                endpoints.MapControllerRoute(
                    name: "firstroute",
                    pattern:"star-here/{controller}/{action=Index}/{id?}" // trong TH ko nhap id -se nhan id =3, neu URL ko chi ro action thi mac dinh la Index 
                    //defaults:new
                    //{
                    //    controller = "First",
                    //    action = "ViewProduct",
                    //    id =3,
                    //}
                    );

                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct"
                    },
                    constraints: new
                    {
                        //url = new StringRouteConstraint("xemsanpham"),
                        url = new RegexInlineRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
                        //id = new RangeRouteConstraint(2, 4) // id trong khoang 2-4
                    }
                    );

                

                endpoints.MapRazorPages();


            }); // tao ra anh xa voi truy van co dia chi URL vao Controller tuong ung

            
        }
    }
}

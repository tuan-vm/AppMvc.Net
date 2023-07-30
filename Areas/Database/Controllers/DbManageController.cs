using App.Data;
using App.Models;
using AppMVC01.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC01.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManageController(AppDBContext dBContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dBContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }   

        public IActionResult Index()
        {
            Console.WriteLine("dddhhh");
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();  
        }

        [HttpPost]  
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success = await _dbContext.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xoa Database thanh cong" : "Khong xoa duoc Database";
            return RedirectToAction(nameof(Index));   
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _dbContext.Database.MigrateAsync();
            StatusMessage = "Cap nhap Database thanh cong";
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> SeedDataAsync()
        {
            Console.WriteLine("hhhhhh");
            // Create Roles
            var rolenames = typeof(RoleName).GetFields().ToList();
            
            foreach(var r in rolenames)
            {
                var rolename = (string) r.GetRawConstantValue();
                var rfound = await _roleManager.FindByNameAsync(rolename);
                if (rfound == null) 
                {
                    await _roleManager.CreateAsync(new IdentityRole(rolename)); // cap nhap Role trong database
                }
            }

            //admin, pass = admin123, admin@example
            var useradmin = await _userManager.FindByEmailAsync("admin@example.com");
            if (useradmin == null) 
            {
                useradmin = new AppUser() 
                {
                    UserName= "admin",
                    Email = "admin@example.com",
                    EmailConfirmed= true,
                };
                await _userManager.CreateAsync(useradmin, "admin123"); // add user co Role Admin
                await _userManager.AddToRoleAsync(useradmin, RoleName.Administrator);
                
            }
            StatusMessage = "Vua seed Database";
            return RedirectToAction("Index"); // chuyen huong ve controller Index
        }
    }

}

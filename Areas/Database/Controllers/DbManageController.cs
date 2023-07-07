using AppMVC01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppMVC01.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDBContext _dbContext;

        public DbManageController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [TempData]
        public string StatusMessage { get; set; }   

        public IActionResult Index()
        {
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
    }

}

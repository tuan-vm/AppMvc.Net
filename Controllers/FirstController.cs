using AppMVC01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

namespace AppMVC01.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductServices _productServices;

        public FirstController(ILogger<FirstController> logger, ProductServices productService)
        {
            _logger = logger;
            _productServices = productService;  

        }
        public string Index()
        {
            //Doc duoc this.HttpContext, this.Request , this.Respond , this.RouteData , this.User , this.ModelState , this.ViewData , this.ViewBag , this.Url, this. TempData
            _logger.LogWarning("Thong bao abc");
            _logger.LogError("Thong bao");
            _logger.LogInformation("Index Action");
            return "Toi la Index cua First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] { 1, 2, 3 };

        /*
            ContentResult               | Content()
            EmptyResult                 | new EmptyResult()
            FileResult                  | File()
            ForbidResult                | Forbid()
            JsonResult                  | Json()
            LocalRedirectResult         | LocalRedirect()
            RedirectResult              | Redirect()
            RedirectToActionResult      | RedirectToAction()
            RedirectToPageResult        | RedirectToRoute()
            RedirectToRouteResult       | RedirectToPage()
            PartialViewResult           | PartialView()
            ViewComponentResult         | ViewComponent()
            StatusCodeResult            | StatusCode()
            ViewResult                  | View()
         */
        //IActionResult

        public IActionResult Readme()
        {
            var content = @"
             Xin chao cac ban ,
             cac ban dang hoc ve ASP.NET MVC
             VMT     
                ";

            return Content(content, "text/plain");
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Birds.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            return Json(new
            {
                productName = "Iphone X",
                Price = 1000
            }) ;
        }

        public IActionResult Privacy() 
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); 
        }

        public IActionResult Google()
        {
            var url = "https://google.com.vn";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                username = "Khach";
            }
            // View() --> Razor Engine , doc va thi hanh file .cshtml (template)

            //return View("/MyView/xinchao1.cshtml", username);

            //======xinchao2.cshtml -> /View/First/xinchao2.cshtml
            //return View("xinchao2", username);

            //=====HelloView.cshtml -> /View/First/HelloView.cshtml
            // /View/Controller/Action.cshtml
            //return View((object)username);


            return View("xinchao3", username);
        }

        [TempData]
        public string StatusMessage { get; set; }   


        public IActionResult ViewProduct(int? id)
        {
            var product = _productServices.Where(p => p.Id == id).FirstOrDefault();
            if(product == null)
            {
                //TempData["StatusMessage"] = "San pham ban yeu cau khong co"; ---- tuong duong voi dong code
                StatusMessage= "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index" , "Home"));
            }

            // tim duong dan /View/First/ViewProduct.cshtml
            //Model
            //return View((product));

            //ViewData
            //this.ViewData["product"] = product;
            //ViewData["Title"] = product.Name;
            //return View("ViewProduct2");

            

            ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
}

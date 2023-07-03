using AppMVC01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppMVC01.Areas.ProductManage.Controllers
{

    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [Route("/cac-san-pham/{id?}")]
        public IActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml
            var products = _productServices.OrderBy(p => p.Name).ToList();
            return View(products); // Areas/ProductManage/Views/Product/Index.cshtml
        }
    }
}

using AppMVC01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppMVC01.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }


        //route : action
        [BindProperty(SupportsGet = true , Name = "action")] // binding gia tri action tren route va gan cho Name
        public string Name { get; set; }   // action ~ PlanetModel 

        [Route("/danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index() //route: he-mat-troi/danh-sach-cac-hanh-tinh.html
        {
            return View();
        }

        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);  
        }

        [Route("sao/[action]", Order = 1, Name ="neptune1")] //co the dung ca 3 route mot luc
        [Route("sao/[controller]/[action]", Order = 2, Name = "neptune2")] //url: sao/Planet/Neptune
        [Route("[controller]-[action].html", Order = 3, Name = "neptune3")] // Planet-Neptune.html
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [HttpGet("/saomoc.html")]
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        //controller , action , area => [controller] [action] [area]
        [Route("hanhtinh/{id:int}")] // route: /hanhtinh/1
        public IActionResult PlanetInfo(int id) 
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
